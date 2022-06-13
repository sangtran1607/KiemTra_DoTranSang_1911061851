using System.Web;
using System.Web.Mvc;

namespace KiemTra_DoTranSang_1911061851
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
