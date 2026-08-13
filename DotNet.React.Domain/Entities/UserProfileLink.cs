using DotNet.React.Domain.Common;
using DotNet.React.Domain.Enums;

namespace DotNet.React.Domain.Entities
{
    public class UserProfileLink : AuditableEntity
    {
        private UserProfileLink()
        {
        }

        internal UserProfileLink(
            Guid userProfileId,
            SocialPlatform platform,
            string url,
            int orderIndex,
            string? displayName = null)
        {
            if (userProfileId == Guid.Empty)
                throw new DomainException("User profile is required.");

            if (string.IsNullOrWhiteSpace(url))
                throw new DomainException("Link URL is required.");

            if (!Uri.TryCreate(url, UriKind.Absolute, out _))
                throw new DomainException("Link URL must be a valid absolute URL.");

            if (orderIndex < 0)
                throw new DomainException("Order index cannot be negative.");

            UserProfileId = userProfileId;
            Platform = platform;
            Url = url;
            OrderIndex = orderIndex;
            DisplayName = displayName;
        }

        public Guid UserProfileId { get; private set; }
        public SocialPlatform Platform { get; private set; }
        public string Url { get; private set; } = default!;
        public string? DisplayName { get; private set; }
        public int OrderIndex { get; private set; }

        public void UpdateUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new DomainException("Link URL is required.");

            if (!Uri.TryCreate(url, UriKind.Absolute, out _))
                throw new DomainException("Link URL must be a valid absolute URL.");

            Url = url;
        }

        public void UpdateDisplayName(string? displayName)
        {
            DisplayName = displayName;
        }

        public void Reorder(int orderIndex)
        {
            if (orderIndex < 0)
                throw new DomainException("Order index cannot be negative.");

            OrderIndex = orderIndex;
        }
    }
}
