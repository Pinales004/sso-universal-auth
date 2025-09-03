using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_BASE.Application.Settings
{
    public class SecurityPoliciesSettings
    {
        public int PasswordMinLength { get; set; }
        public bool PasswordRequireUpper { get; set; }
        public bool PasswordRequireLower { get; set; }
        public bool PasswordRequireDigit { get; set; }
        public bool PasswordRequireSpecial { get; set; }
        public int MaxLoginAttempts { get; set; }
        public int LockoutMinutes { get; set; }
        public int HistoryCount { get; set; }
        public bool MfaEnabled { get; set; }
    }
}
