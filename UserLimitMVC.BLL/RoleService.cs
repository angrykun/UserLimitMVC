using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLimitMVC.Model;
using UserLimitMVC.Model.User;
using UserLimitMVC.IBLL;

namespace UserLimitMVC.BLL
{
    public class RoleService : BaseService<Role>, IRoleService
    {
        //重写抽象方法，设置当前仓储为Role仓储
        public override void SetCurrentRepostory()
        {
            //设置当前仓储为Role仓储
            CurrentRepository = DAL.RepositoryFactory.RoleRepository;
        }
    }
}