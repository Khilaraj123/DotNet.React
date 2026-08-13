using DotNet.React.Domain.Common;
using DotNet.React.Domain.DomainEvents;
using DotNet.React.Domain.ValueObjects;

namespace DotNet.React.Domain.Entities
{
    public class FileAttachment : SoftDeleteEntity
    {
        private FileAttachment() { }

        public FileAttachment(
            string fileUrl,
            FileMetadata metadata,
            Guid uploadedById,
            Guid? questionId = null,
            Guid? assignmentId = null,
            Guid? submissionId = null,
            Guid? lessonId = null)
        {
            if (string.IsNullOrWhiteSpace(fileUrl))
                throw new DomainException("File URL is required.");

            if (metadata is null)
                throw new DomainException("File metadata is required.");

            if (uploadedById == Guid.Empty)
                throw new DomainException("Uploader is required.");

            var contextCount = new[] { questionId, assignmentId, submissionId, lessonId }
                .Count(id => id.HasValue);

            if (contextCount == 0)
                throw new DomainException("File must be attached to at least one context.");

            if (contextCount > 1)
                throw new DomainException("File cannot be attached to more than one context.");

            Id = Guid.NewGuid();
            FileUrl = fileUrl;
            Metadata = metadata;
            UploadedById = uploadedById;
            QuestionId = questionId;
            AssignmentId = assignmentId;
            SubmissionId = submissionId;
            LessonId = lessonId;

            AddDomainEvent(new FileUploadedEvent(Id, uploadedById, fileUrl, metadata.FileName));
        }
        public string FileUrl { get; private set; } = default!;
        public FileMetadata Metadata { get; private set; } = default!;
        public Guid UploadedById { get; private set; }
        public Guid? QuestionId { get; private set; }
        public Guid? AssignmentId { get; private set; }
        public Guid? SubmissionId { get; private set; }
        public Guid? LessonId { get; private set; }

        public void UpdateUrl(string fileUrl)
        {
            if (string.IsNullOrWhiteSpace(fileUrl))
                throw new DomainException("File URL is required.");

            if (IsDeleted)
                throw new DomainException("Cannot update a deleted file.");

            FileUrl = fileUrl;
            MarkUpdated();
        }

        public void Delete(Guid deletedById)
        {
            if (deletedById == Guid.Empty)
                throw new DomainException("Deleter is required.");

            if (IsDeleted)
                throw new DomainException("File is already deleted.");

            IsDeleted = true;

            AddDomainEvent(new FileDeletedEvent(Id, deletedById, FileUrl));
        }
    }
}
