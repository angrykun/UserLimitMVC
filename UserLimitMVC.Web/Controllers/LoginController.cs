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
            string userInfoError = string.Empty;
            switch (loginUserInfo)
            {
                case LoginResult.PwdError:
                    userInfoError = "密码输入错误";
                    break;
                case LoginResult.PwdIsNull:
                    userInfoError = "密码不能为空";
                    break;
                case LoginResult.UserIsNull:
                    userInfoError = "用户名不能为空";
                    break;
                case LoginResult.UserNotExist:
                    userInfoError = "用户不存在";
                    break;
                case LoginResult.OK:
                    userInfoError = "OK";
                    break;
                default:
                    userInfoError = "未知错误,请检查您的数据库";
                    break;

            }
            return Content(userInfoError);
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