﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLimitMVC.IDAL;

namespace UserLimitMVC.DAL
{
    /// <summary>
    /// 应用程序和数据库之间的一次会话
    /// 是访问数据层的统一入口
    /// </summary>
    public class DbSession : IDbSession
    {
        public IRoleRepository RoleRepository
        {
            get { return new RoleRepository(); }
        }

        public IUserInfoRepository UserInfoRepository
        {
            get { return new UserInfoRepository(); }
        }

        //当前应用程序和数据库的会话内所有实体的变化，更新回数据库
        public int SaveChanges()
        {
            //调用EF上下文的SaveChange方法
            return EFContextFactory.GetCurrentDbContext().SaveChanges();
        }

        public int ExcuteSql(string strSql, DbParameter[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}