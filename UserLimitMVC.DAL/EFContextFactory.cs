using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Runtime.Remoting.Messaging;

namespace UserLimitMVC.DAL
{
    public class EFContextFactory
    {
        //帮我们返回当前线程内的数据库上下文，如果当前线程内没有上下文，那么创建一个，并保证上下文实例在线程内是唯一的
        public static DbContext GetCurrentDbContext()
        {
            //CallContext:是线程内唯一的独用的数据槽(一块内存空间)
            //传递DBContext进去获取实例的信息，在这里进行强制转换
            DbContext dbContext = CallContext.GetData("DbContext") as DbContext;

            //线程在数据槽里面没有此上下文
            if (dbContext == null)
            {
                dbContext = new UserLimitMVC.Model.UserLimitContext();
                CallContext.SetData("DbContext", dbContext);
            }
            return dbContext;
        }

        #region CallContext 说明

        /*
         * CallContext 是类似于方法调用的线程本地存储区的专用集合对象，
         * 并提供对每个逻辑执行线程内都唯一的数据槽，数据槽不在其他逻辑
         * 线程上的调用上下文之间共享，当调用CallContext 沿执行代码路径
         * 返回传播并且该路径的各个对象检查时，可以将其对象添加其中。
         *
         * ***/

        #endregion CallContext 说明
    }
}