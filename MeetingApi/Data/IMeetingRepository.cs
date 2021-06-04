using MeetingApi.Dto;
using MeetingApi.Models;
using System.Collections.Generic;

namespace MeetingApi.Data
{
    public interface IMeetingRepository
    {
        public ResponseDto SignForMeeting(int _meetingId, UserSignUp _data);
        public List<MeetingDto> GetAllMeetings();
        public MeetingDto CreateMeeting(int _userLimit);
        public ResponseDto DeleteMeeting(int _meetingId);
    }
}
