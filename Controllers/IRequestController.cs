using Microsoft.AspNetCore.Mvc;
using UsersRequestsRouming.Models;

namespace UsersRequestsRouming.Controllers
{
    public interface IRequestController
    {
        public ActionResult Create();
        public ActionResult Create(Request request);
        public ActionResult Update(int id);
        public Task<ActionResult> UpdatePost(int id);
        public ActionResult AllRequests(string sortOrder = "id_desc");
        public ActionResult DeletePost(int id);
        public ActionResult Delete(int id);
    }
}