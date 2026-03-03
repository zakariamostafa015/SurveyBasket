namespace SurveyBasket.API.Services
{
    public class PollService : IPollService
    {
        private static readonly List<Poll> _polls =
        [
           new Poll { Id = 1, Title = "Favorite Programming Language", Description = "Vote for your favorite programming language." },
           new Poll { Id = 2, Title = "Best Web Framework", Description = "Vote for the best web framework." },
           new Poll { Id = 3, Title = "Preferred Database", Description = "Vote for your preferred database." }
        ];



        public IEnumerable<Poll> GetAll() => _polls;
        public Poll? GetById(int id) => _polls.FirstOrDefault(p => p.Id == id);
        public Poll Add(Poll poll)
        {
            _polls.Add(poll);
            return poll;
        }

        public bool Update(int id, Poll poll)
        {
            var currentPoll = GetById(id);
            if (currentPoll is null) return false;

            currentPoll.Title = poll.Title;
            currentPoll.Description = poll.Description;
            return true;
        }

        public void Delete(int id)
        {
            var poll = GetById(id);
            if (poll is not null) _polls.Remove(poll);
        }
    }
}
