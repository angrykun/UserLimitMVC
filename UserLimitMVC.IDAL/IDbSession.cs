using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLimitMVC.IDAL
{
    public interface IDbSession
    {
        IRoleRepository RoleRepository { get; }
        IUserInfoRepository UserInfoRepository { get; }

        //将当前应用程序跟数据库会话内所有实体的变化更新回数据库
        int SaveChanges();

        //执行sql语法
        int ExcuteSql(string strSql, DbParameter[] parameters);
    }
}