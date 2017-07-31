using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLimitMVC.Model;
using UserLimitMVC.Model.User;
using UserLimitMVC.Common;

namespace UserLimitMVC.IBLL
{
    public interface IUserInfoService : IBaseService<UserInfo>
    {
        //添加一个用户登录信息约束
        LoginResult CheckUserInfo(UserInfo userInfo);
    }
}