using SportLize.Talk.Api.Talk.Repository.Abstraction;

namespace SportLize.Talk.Api.Talk.Repository
{
    public class Repository : IRepository
    {
        private TalkDbContext _talkDbContext;
        public Repository(TalkDbContext talkDbContext) 
        {
            _talkDbContext = talkDbContext;
        }
    }
}
