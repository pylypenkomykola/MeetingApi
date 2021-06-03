using MeetingApi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingApi.Mapper
{
    public class MeetingToDtoMapper : Converter<Meeting, MeetingDto>
    {
        public MeetingDto convert(Meeting from)
        {
            return new MeetingDto() { IdMeeting = from.IdMeeting, UsersLimit = from.UsersLimit };
        }
    }
}
