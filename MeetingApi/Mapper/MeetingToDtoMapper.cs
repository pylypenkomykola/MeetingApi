using MeetingApi.Dto;
using MeetingApi.Entity;

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
