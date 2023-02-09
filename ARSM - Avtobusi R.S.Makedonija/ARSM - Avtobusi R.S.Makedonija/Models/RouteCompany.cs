using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ARSM___Avtobusi_R.S.Makedonija.Models

{
    public class RouteCompany
    {
        public RouteCompany()
        {
            routes = new List<Route>();
        }
        public int CompanyId { get; set; }
        public int RouteId { get; set; }
        public Company company { get; set; }
        public List<Route> routes { get; set; }
    }
}