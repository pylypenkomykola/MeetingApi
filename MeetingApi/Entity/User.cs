using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingApi.Entity
{
    [Table("users", Schema = "xkom_task")]
    public class User
    {
        [Column("id_user")]
        [Key]
        public int IdUser { get; set; }

        [Required]
        [Column("firstname")]
        public string FirstName { get; set; }

        [Required]
        [Column("email")]
        public string Email { get; set; }

        public virtual ICollection<UserMeeting> Meetings { get; set; }
    }
}
