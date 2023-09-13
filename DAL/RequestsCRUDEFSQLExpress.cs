using Microsoft.AspNetCore.Mvc;
using UsersRequestsRouming.Models;

namespace UsersRequestsRouming.DAL
{
    public class RequestsCRUDEFSQLExpress : Controller, IRequestsCRUD
    {
        private RequestsDB _requestsDB = new RequestsDB();

        public void Create(Request request)
        {
            _requestsDB.Requests.Add(request);
            _requestsDB.SaveChanges();
        }

        public void Delete(int id)
        {
            var request = GetRequest(id);
            _requestsDB.Requests.Remove(request);
            _requestsDB.SaveChanges();
        }

        public Request GetRequest(int id)
        {
            var request = _requestsDB.Requests.Find(id);
            
            if (request != null)
            {
                return request;
            }
            else
            {
                throw new Exception("Обращение с таким id не найдено");
            }
        }

        public void Update()
        {
            _requestsDB.SaveChanges();
        }

        public RequestsDB GetRequestsDB()
        {
            return _requestsDB;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _requestsDB.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}