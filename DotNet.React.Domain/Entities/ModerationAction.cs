using DotNet.React.Domain.Common;

namespace DotNet.React.Domain.Entities
{
    public class ModerationAction : AuditableEntity
    {
        private ModerationAction() { }

        public ModerationAction(string action, string targetType, Guid targetId, Guid moderatorId, string reason, string? notes)
        {
            Action = action;
            TargetType = targetType;
            TargetId = targetId;
            ModeratorId = moderatorId;
            Reason = reason;
            Notes = notes;
        }

        public string Action { get; private set; } = default!;
        public string TargetType { get; private set; } = default!;
        public Guid TargetId { get; private set; }
        public Guid ModeratorId { get; private set; }
        public string Reason { get; private set; } = default!;
        public string? Notes { get; private set; }
    }

}
