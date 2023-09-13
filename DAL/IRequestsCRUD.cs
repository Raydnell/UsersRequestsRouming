using UsersRequestsRouming.Models;

namespace UsersRequestsRouming.DAL
{
    public interface IRequestsCRUD
    {
        public void Create(Request request);
        public void Delete(int id);
        public Request GetRequest(int id);
        public void Update();
        public RequestsDB GetRequestsDB();
    }
}