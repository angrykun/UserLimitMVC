using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLimitMVC.Model.User;
using UserLimitMVC.DAL;
using UserLimitMVC.IDAL;
using UserLimitMVC.IBLL;
using UserLimitMVC.Common;

namespace UserLimitMVC.BLL
{
    /// <summary>
    /// UserInfo业务逻辑
    /// </summary>
    public class UserInfoService : BaseService<UserInfo>, IUserInfoService
    {
        //重写抽象方法，设置当前仓储为UserInfo
        public override void SetCurrentRepostory()
        {                               

            //设置当前仓储为UserInfo仓储
            CurrentRepository = DAL.RepositoryFactory.UserRepository;
        }

        //校验用户
        public LoginResult CheckUserInfo(UserInfo userInfo)
        {
            if (string.IsNullOrEmpty(userInfo.UName))
            {
                return LoginResult.UserIsNull;
            }

            if (string.IsNullOrEmpty(userInfo.Pwd))
            {
                return LoginResult.PwdIsNull;
            }
            var LoginUserInfoCheck = _DbSession.UserInfoRepository.LoadEntities(u => u.UName == userInfo.UName && u.Pwd == userInfo.Pwd).FirstOrDefault();

            if (LoginUserInfoCheck == null)
            {
                return LoginResult.UserIsNull;
            }
            else if (LoginUserInfoCheck.Pwd != userInfo.Pwd)
            {
                return LoginResult.PwdError;
            }
            else
            {
                return LoginResult.OK;
            }
        }
    }
}