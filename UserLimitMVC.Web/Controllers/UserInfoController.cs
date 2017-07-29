using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserLimitMVC.Model;
using UserLimitMVC.Model.User;
using UserLimitMVC.IBLL;
using UserLimitMVC.BLL;

namespace UserLimitMVC.Web.Controllers
{
    public class UserInfoController : Controller
    {
        //依赖接口编程
        private IUserInfoService _userInfoService = new UserInfoService();

        // GET: UserInfo
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllUserInfos()
        {
            int pageIndex = Request["page"] == null ? 1 : int.Parse(Request["page"]);
            int pageSize = Request["rows"] == null ? 10 : int.Parse(Request["rows"]);
            int total = 0;

            var data = _userInfoService.LoadPageEntities(pageIndex, pageSize, out total, u => true, true, u => u.ID);

            var result = new { total = total, rows = data };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}