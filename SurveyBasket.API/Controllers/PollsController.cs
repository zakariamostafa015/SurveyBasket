
namespace SurveyBasket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollsController(IPollService pollService) : ControllerBase
    {
        private readonly IPollService _pollService = pollService;

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_pollService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Poll> GetById(int id)
        {
            var poll = _pollService.GetById(id);

            return poll is not null ? Ok(poll) : NotFound();
        }

        [HttpPost]
        public ActionResult Post(Poll poll)
        {
            var createdPoll = _pollService.Add(poll);
            return CreatedAtAction(nameof(GetById), new { id = createdPoll.Id }, createdPoll);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, Poll poll)
        {
            var isUpdated = _pollService.Update(id, poll);
            return isUpdated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var poll = _pollService.GetById(id);
            if (poll is null) return NotFound();
            _pollService.Delete(id);
            return NoContent();
        }
    }
}
