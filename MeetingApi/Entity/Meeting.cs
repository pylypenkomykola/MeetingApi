using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingApi.Entity
{
    [Table("meetings", Schema = "xkom_task")]
    public class Meeting
    {
        [Column("id_meeting")]
        [Key]
        public int IdMeeting { get; set; }

        [Required]
        [Column("users_limit")]
        public int UsersLimit { get; set; }

        public virtual ICollection<UserMeeting> Meetings { get; set; }
    }
}
