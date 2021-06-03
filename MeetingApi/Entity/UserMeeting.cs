using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingApi.Entity
{
    [Table("users_meetings", Schema = "xkom_task")]
    public class UserMeeting
    {
        [Key, ForeignKey("id_user"), Column("id_user")]
        public int IdUser { get; set; }

        [Key, ForeignKey("id_meeting"), Column("id_meeting")]
        public int IdMeeting { get; set; }

        public virtual User User { get; set; }
        public virtual Meeting Meeting { get; set; }
    }
}
