using Microsoft.AspNetCore.Mvc;
using System.Data;
using UsersRequestsRouming.DAL;
using UsersRequestsRouming.Models;

namespace UsersRequestsRouming.Controllers
{
    public class RequestController : Controller, IRequestController
    {
        private DirectionsDB _directionsDB = new DirectionsDB();
        private IRequestsCRUD _requestsCRUD = new RequestsCRUDEFSQLExpress();

        [HttpGet, ActionName("Create")]
        public ActionResult Create()
        { 
            ViewBag.Books = _directionsDB.Directions;
            return View(); 
        }

        [HttpPost, ActionName("Create")]
        public ActionResult Create([Bind("Country, City, Region, PhoneNumber, RequestReason, Direction")]Request request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    request.RequestDateTime = DateTime.Now;
                    _requestsCRUD.Create(request);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.ToString());
            }

            return RedirectToAction("AllRequests");
        }

        [HttpGet, ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            return CheckRequest(id);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeletePost(int id)
        {
            try
            {
                _requestsCRUD.Delete(id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.ToString());
            }
            
            return RedirectToAction("AllRequests");
        }

        [HttpGet, ActionName("Update")]
        public ActionResult Update(int id)
        {
            ViewBag.Books = _directionsDB.Directions;
            return CheckRequest(id);
        }
        
        [HttpPost, ActionName("Update")]
        public async Task<ActionResult> UpdatePost(int id)
        {
            try
            {
                var request = _requestsCRUD.GetRequest(id);

                if (await TryUpdateModelAsync(request))
                {
                    _requestsCRUD.Update();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.ToString());
            }

            return RedirectToAction("AllRequests");
        }

        public ActionResult AllRequests(string sortOrder = "id_asc")
        {
            ViewBag.id_desc = sortOrder == "id_desc" ? "id_asc" : "id_desc";
            ViewBag.country_desc = sortOrder == "country_desc" ? "country_asc" : "country_desc";
            ViewBag.city_desc = sortOrder == "city_desc" ? "city_asc" : "city_desc";
            ViewBag.region_desc = sortOrder == "region_desc" ? "region_asc" : "region_desc";
            ViewBag.phone_desc = sortOrder == "phone_desc" ? "phone_asc" : "phone_desc";
            ViewBag.reason_desc = sortOrder == "reason_desc" ? "reason_asc" : "reason_desc";
            ViewBag.direction_desc = sortOrder == "direction_desc" ? "direction_asc" : "direction_desc";
            ViewBag.datetime_desc = sortOrder == "datetime_desc" ? "datetime_asc" : "datetime_desc";

            var requests = from r in _requestsCRUD.GetRequestsDB().Requests select r;

            switch (sortOrder)
            {
                case "id_desc":
                    requests = requests.OrderByDescending(s => s.Id);
                    break;

                default:
                case "id_asc":
                    requests = requests.OrderBy(s => s.Id);
                    break;

                case "country_desc":
                    requests = requests.OrderByDescending(s => s.Country);
                    break;

                case "country_asc":
                    requests = requests.OrderBy(s => s.Country);
                    break;

                case "city_desc":
                    requests = requests.OrderByDescending(s => s.City);
                    break;

                case "city_asc":
                    requests = requests.OrderBy(s => s.City);
                    break;

                case "region_desc":
                    requests = requests.OrderByDescending(s => s.Region);
                    break;

                case "region_asc":
                    requests = requests.OrderBy(s => s.Region);
                    break;

                case "phone_desc":
                    requests = requests.OrderByDescending(s => s.PhoneNumber);
                    break;

                case "phone_asc":
                    requests = requests.OrderBy(s => s.PhoneNumber);
                    break;

                case "reason_desc":
                    requests = requests.OrderByDescending(s => s.RequestReason);
                    break;

                case "reason_asc":
                    requests = requests.OrderBy(s => s.RequestReason);
                    break;

                case "direction_desc":
                    requests = requests.OrderByDescending(s => s.Direction);
                    break;

                case "direction_asc":
                    requests = requests.OrderBy(s => s.Direction);
                    break;

                case "datetime_desc":
                    requests = requests.OrderByDescending(s => s.RequestDateTime);
                    break;

                case "datetime_asc":
                    requests = requests.OrderBy(s => s.RequestDateTime);
                    break;
            }

            return View(requests.ToList());
        }

        private ActionResult CheckRequest(int id)
        {
            try
            {
                var request = _requestsCRUD.GetRequest(id);
                return View(request);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.ToString());
            }

            return RedirectToAction("AllRequests");
        }
    }
}
