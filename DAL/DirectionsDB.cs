using Microsoft.AspNetCore.Mvc.Rendering;

namespace UsersRequestsRouming.DAL
{ 
    public class DirectionsDB
    {
        public List<SelectListItem> Directions = new List<SelectListItem>
        {
            new SelectListItem
            {
                Text = "Офис обслуживания",
                Value = "Офис обслуживания"
            },
            new SelectListItem
            {
                Text = "Контакт-Центр",
                Value = "Контакт-Центр"
            }
        };
    }
}