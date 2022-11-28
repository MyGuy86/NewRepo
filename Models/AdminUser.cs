using System;
using System.Collections.Generic;

namespace RestAPI.Models
{
    public partial class AdminUser
    {
        public long Id { get; set; }
        public string Email { get; set; } = null!;
        public string EncryptedPassword { get; set; } = null!;
        public string? ResetPasswordToken { get; set; }
        public DateTime? ResetPasswordSentAt { get; set; }
        public DateTime? RememberCreatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
