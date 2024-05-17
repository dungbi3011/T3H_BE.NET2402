using System.Web;
using System.Web.Mvc;

namespace Buoi15_BTVN__BookManager_
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
