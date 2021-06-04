using MeetingApi.Entity;
using MeetingApi.Mapper;
using MeetingApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingApi.Data
{
    public class SqlRepository : IMeetingRepository
    {
        private readonly int userLimit = 25;
        private readonly MeetingContext context = null;
        private readonly Mapper.Converter<Meeting, MeetingDto> meetingToDtoMapper = null;


        public SqlRepository(MeetingContext _context, Mapper.Converter<Meeting, MeetingDto> _meetingToDtoMapper)
        {
            context = _context;
            meetingToDtoMapper = _meetingToDtoMapper;
        }

        public Meeting CreateMeeting(int _userLimit)
        {
            Meeting _meeting = context.Meetings.Add(new Meeting() {UsersLimit = userLimit}).Entity;
            context.SaveChanges();

            return _meeting;
        }

        public void DeleteMeeting(int _meetingId)
        {
            Meeting _meeting = context.Meetings.FirstOrDefault(meeting => meeting.IdMeeting == _meetingId);

            if (_meeting == null)
            {
                return;
            }
            IEnumerable<UserMeeting> usersInMeeting = context.UsersMeetings.Where(elm => elm.IdMeeting == _meeting.IdMeeting);

            foreach(UserMeeting userMeeting in usersInMeeting)
            {
                context.UsersMeetings.Remove(userMeeting);
            }

            context.Meetings.Remove(_meeting);
            context.SaveChanges();
        }

        public List<MeetingDto> GetAllMeetings()
        {
            IEnumerable<Meeting> _meetings = context.Meetings.ToList();
            List<MeetingDto> _meetingsDto = new List<MeetingDto>(); 

            foreach(Meeting _meeting in _meetings)
            {
                MeetingDto _meetingDto = meetingToDtoMapper.convert(_meeting);
                _meetingsDto.Add(_meetingDto);
            }

            return _meetingsDto;
        }

        public void SignForMeeting(int _meetingId, UserSignUp _data)
        {
            User _user = context.Users.FirstOrDefault(elm => elm.Email == _data.email);
            Meeting _meeting = context.Meetings.FirstOrDefault(meeting => meeting.IdMeeting == _meetingId);

            if (_user == null)
            {
                _user = context.Users.Add(new User() { FirstName = _data.firstname, Email = _data.email }).Entity;
            }

            if (context.UsersMeetings.Count(elm => elm.IdMeeting == _meeting.IdMeeting) >= _meeting.UsersLimit || context.UsersMeetings.Any(elm => elm.IdMeeting == _meetingId && elm.IdUser == _user.IdUser))
            {
                return;
            }

            context.UsersMeetings.Add(new UserMeeting() { IdMeeting = _meetingId, IdUser = _user.IdUser, Meeting = _meeting, User = _user});
            context.SaveChanges();
        }
    }
}
