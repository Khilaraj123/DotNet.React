using DotNet.React.Domain.Common;

namespace DotNet.React.Domain.ValueObjects
{
    public sealed record FileMetadata
    {
        private FileMetadata() { FileName = null!; ContentType = null!; }

        public string FileName { get; }
        public string ContentType { get; }
        public long FileSize { get; }

        public FileMetadata(
            string fileName,
            string contentType,
            long fileSize)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                throw new DomainException(
                    "File name is required.");

            if (fileSize <= 0)
                throw new DomainException(
                    "File size must be greater than zero.");

            FileName = fileName;
            ContentType = contentType;
            FileSize = fileSize;
        }
    }
}
