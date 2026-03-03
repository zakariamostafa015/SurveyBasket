namespace SurveyBasket.API.Services
{
    public interface IPollService
    {
        public IEnumerable<Poll> GetAll();
        public Poll? GetById(int id);
        public Poll Add(Poll poll);
        public bool Update(int id, Poll poll);
        public void Delete(int id);
    }
}
