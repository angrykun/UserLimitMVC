using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLimitMVC.Common
{
    class EnumClass
    {
    }

    public enum LoginResult
    {     //密码错误
        PwdError,
        //用户不存在
        UserNotExist,
        //用户名 为空
        UserIsNull,
        //密码为空
        PwdIsNull,
        //登录成功
        OK,
    }
}
