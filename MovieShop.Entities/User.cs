﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieShop.Entities
{
    [Table("User")]
    public class User
    {
        public int Id { get; set; }
        [StringLength(128)]
        public string FirstName { get; set; }
        [StringLength(128)]
        public string LastName { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? DateOfBirth { get; set; }

        [StringLength(256)]
        public string Email { get; set; }
        [StringLength(1024)]
        public string HashedPassword { get; set; }
        [StringLength(1024)]
        public string Salt { get; set; }
        [StringLength(16)]
        public string PhoneNumber { get; set; }
        public bool? TwoFactorEnabled { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? LockoutEndDate { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? LastLoginDateTime { get; set; }
        public bool? IsLocked { get; set; }
        public int? AccessFailedCount { get; set; }

        public ICollection<Role> Roles { get; set; }
    }
}
