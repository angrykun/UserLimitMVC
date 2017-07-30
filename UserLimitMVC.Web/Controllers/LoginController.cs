using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserLimitMVC.IBLL;
using UserLimitMVC.BLL;
using UserLimitMVC.Common;
using UserLimitMVC.Model.User;

namespace UserLimitMVC.Web.Controllers
{
    public class LoginController : Controller
    {
        private IUserInfoService _userInfoService = new UserInfoService();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CheckUserInfo(UserInfo userINfo, string Code)
        {
            string sessionCode = this.TempData["ValidateCode"] == null
                ? new Guid().ToString()
                : TempData["ValidateCode"].ToString();

            //将验证码去掉，避免暴力破解
            TempData["ValidateCode"] = new Guid();

            if (sessionCode != Code)
            {
                return Content("验证码输入不正确");
            }

            var loginUserInfo = _userInfoService.CheckUserInfo(userINfo);
            if (loginUserInfo == null)
            {
                return Content("用户名或密码错误");
            }
            else
            {
                return Content("OK");
            }
        }

        #region 生成验证码

        //生成验证码
        public ActionResult CheckCode()
        {
            KenceryValidateCode validateCode = new KenceryValidateCode();
            //生成验证码指定长度
            string code = validateCode.CreateValidateCode(5);
            //将验证码赋值给Session变量
            TempData["ValidateCode"] = code;
            byte[] bytes = validateCode.CreateValidateGraphic(code);
            //最后将验证码返回
            return File(bytes, @"image/jpeg");
        }

        #endregion 生成验证码
    }
}