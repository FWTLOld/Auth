﻿using System;
using System.ComponentModel.DataAnnotations;
using Auth.FWT.Core.Entities.Identity;

namespace Auth.FWT.Core.Entities
{
    public class TelegramSession : BaseEntity<int>
    {
        public DateTime ExpireDateUtc { get; set; }

        public byte[] Session { get; set; }

        [Required]
        public virtual User User { get; set; }

        public int UserId { get; set; }
    }
}
