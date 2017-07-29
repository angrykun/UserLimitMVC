using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLimitMVC.Model.User;
using UserLimitMVC.DAL;
using UserLimitMVC.IDAL;
using UserLimitMVC.IBLL;

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
    }
}