using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessBanking.Domain.Entity
{
    [Table("Users")]
    public class User
    {
        [Column("ID", Order = 1)]
        public int ID { get; set; }
        [Column("UniversityID", Order = 2)]
        public int UniversityID { get; set; }
        [Column("Login", Order = 3, TypeName = "char(64)")]
        public string Login { get; set; }

        [Column("Password", Order = 4, TypeName = "nvarchar(max)")]
        public string Password { get; set; }
        [Column("CreatedDate", Order = 5, TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }
        [Column("IsEnabled", Order = 6, TypeName = "bit")]
        public bool IsEnabled { get; set; }
    }
}
