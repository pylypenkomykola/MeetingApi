using MeetingApi.Data;
using MeetingApi.Entity;
using MeetingApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            Meeting _result = null;

            _result = meetingRepository.CreateMeeting(25);

            return Created(uri,_result);
        }

        [HttpDelete("{meetingId}")]
        public ActionResult DeleteMeeting(int meetingId)
        {
            meetingRepository.DeleteMeeting(meetingId);

            return Ok();
        }

        [HttpPost("{meetingId}/sign-up")]
        public ActionResult SignUserForMeeting(int meetingId, [FromBody] UserSignUp _data)
        {
            meetingRepository.SignForMeeting(meetingId, _data);

            return Ok();
        }
    }
}
