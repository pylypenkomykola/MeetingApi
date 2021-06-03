using MeetingApi.Entity;
using MeetingApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingApi.Data
{
    public interface IMeetingRepository
    {
        public User GetUserByEmail(string _email);

        public void SignForMeeting(UserSignUp _data);
        public List<MeetingDto> GetAllMeetings();
        public Meeting CreateMeeting(int _userLimit);
        public void DeleteMeeting(int _meetingId);
    }
}
