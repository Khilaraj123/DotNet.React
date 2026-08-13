using System;
using System.Collections.Generic;
using System.Text;

namespace DotNet.React.Infrastructure.Settings
{
    public sealed class EmailSettings
    {
        public string Host { get; set; } = string.Empty;
        public int Port { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
