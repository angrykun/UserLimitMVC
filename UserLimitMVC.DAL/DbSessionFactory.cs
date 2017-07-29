using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using UserLimitMVC.IDAL;

namespace UserLimitMVC.DAL
{
    public class DbSessionFactory
    {
        public static IDbSession GetCurrentDbSession()
        {
            IDbSession _dbSession = CallContext.GetData("DbSession") as DbSession;
            if (_dbSession == null)
            {
                _dbSession = new DbSession();
                //将值设置到数据槽里面
                CallContext.SetData("DbSession", _dbSession);
            }
            return _dbSession;
        }
    }
}