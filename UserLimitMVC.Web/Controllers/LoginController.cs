using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserLimitMVC.Common;

namespace UserLimitMVC.Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        #region 生成验证码

        //生成验证码
        public ActionResult CheckCode()
        {
            KenceryValidateCode validateCode = new KenceryValidateCode();
            //生成验证码指定长度
            string code = validateCode.CreateValidateCode(5);
            //将验证码赋值给Session变量
            Session["ValidateCode"] = code;
            byte[] bytes = validateCode.CreateValidateGraphic(code);
            //最后将验证码返回
            return File(bytes, @"image/jpeg");
        }

        #endregion 生成验证码
    }
}