using System.Web;
using System.Web.Mvc;

namespace ARSM___Avtobusi_R.S.Makedonija
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
