using DotNet.React.Domain.Common;
using DotNet.React.Domain.Enums;

namespace DotNet.React.Domain.Entities
{
    public class ContentFlag : AuditableEntity
    {
        private ContentFlag() { }

        public ContentFlag(string targetType, Guid targetId, Guid reportedBy, string reason)
        {
            TargetType = targetType;
            TargetId = targetId;
            ReportedBy = reportedBy;
            Reason = reason;
            Status = FlagStatus.Pending;
        }

        public string TargetType { get; private set; } = default!;
        public Guid TargetId { get; private set; }
        public Guid ReportedBy { get; private set; }
        public string Reason { get; private set; } = default!;
        public FlagStatus Status { get; private set; }
        public string? Resolution { get; private set; }
        public Guid? ResolvedBy { get; private set; }

        public void Resolve(string resolution, Guid resolvedBy)
        {
            Status = FlagStatus.Resolved;
            Resolution = resolution;
            ResolvedBy = resolvedBy;
            MarkUpdated(resolvedBy);
        }

        public void Dismiss(Guid dismissedBy)
        {
            Status = FlagStatus.Dismissed;
            ResolvedBy = dismissedBy;
            MarkUpdated(dismissedBy);
        }
    }
}
