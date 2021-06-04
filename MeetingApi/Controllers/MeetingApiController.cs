using MeetingApi.Data;
using MeetingApi.Dto;
using MeetingApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MeetingApi.Controllers
{
    [Route("api/meetings")]
    [ApiController]
    public class MeetingApiController : ControllerBase
    {
        private readonly string uri = "http://localhost:5000/api/meetings";
        private readonly IMeetingRepository meetingRepository = null;

        public MeetingApiController(IMeetingRepository _meetingRepository)
        {
            meetingRepository = _meetingRepository;
        }

        [HttpGet]
        public ActionResult<List<MeetingDto>> GetAllMeetings()
        {
            List<MeetingDto> _result = null;

            _result = meetingRepository.GetAllMeetings();

            return Ok(_result);
        }

        [HttpPost("create")]
        public ActionResult CreateMeeting()
        {
            MeetingDto _result = null;

            _result = meetingRepository.CreateMeeting(25);

            return Created(uri,_result);
        }

        [HttpDelete("{meetingId}")]
        public ActionResult DeleteMeeting(int meetingId)
        {
            ResponseDto _result = null;

            _result = meetingRepository.DeleteMeeting(meetingId);

            if (!_result.IsSuccess)
            {
                return NotFound(_result.ResponseText);
            }

            return Ok(_result.ResponseText);
        }

        [HttpPost("{meetingId}/sign-up")]
        public ActionResult SignUserForMeeting(int meetingId, [FromBody] UserSignUp _data)
        {
            ResponseDto _result = null;

            _result = meetingRepository.SignForMeeting(meetingId, _data);

            if (!_result.IsSuccess)
            {
                return NotFound(_result.ResponseText);
            }

            return Ok(_result.ResponseText);
        }
    }
}
