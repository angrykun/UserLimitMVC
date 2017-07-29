using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLimitMVC.Model;
using UserLimitMVC.Model.User;
using System.Data.Entity;
using UserLimitMVC.IDAL;

namespace UserLimitMVC.DAL
{
    /// <summary>
    /// 实现对数据库的增删改查的基类
    /// </summary>
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        //创建EF上下文
        private UserLimitContext db = new UserLimitContext();

        /// <summary>
        /// 新增实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T AddEntity(T entity)
        {
            db.Set<T>().Add(entity);

            //保存更改
            db.SaveChanges();
            return entity;
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool UpdateEntity(T entity)
        {
            db.Set<T>().Attach(entity);
            db.Entry<T>(entity).State = EntityState.Modified;

            return db.SaveChanges() > 0;
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool DeleteEntity(T entity)
        {
            db.Set<T>().Attach(entity);
            db.Entry<T>(entity).State = EntityState.Deleted;
            return db.SaveChanges() > 0;
        }

        /// <summary>
        /// 实现对数据库的查询
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public IQueryable<T> LoadEntities(Func<T, bool> whereLambda)
        {
            return db.Set<T>().Where<T>(whereLambda).AsQueryable();
        }

        /// <summary>
        /// 分页查询数据
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <param name="whereLambda"></param>
        /// <param name="isAsc"></param>
        /// <param name="orderByLambda"></param>
        /// <returns></returns>
        public IQueryable<T> LoadPageEntities<S>(int pageIndex, int pageSize, out int total, Func<T, bool> whereLambda, bool isAsc, Func<T, S> orderByLambda)
        {
            var temp = db.Set<T>().Where<T>(whereLambda);
            total = temp.Count();//得到总条数

            if (isAsc)
            {
                temp = temp.OrderBy<T, S>(orderByLambda)
                    .Skip<T>(pageSize * (pageIndex - 1))
                    .Take<T>(pageSize).AsQueryable();
            }
            else
            {
                temp = temp.OrderByDescending<T, S>(orderByLambda)
                     .Skip<T>(pageSize * (pageIndex - 1))
                     .Take<T>(pageSize).AsQueryable();
            }
            return temp.AsQueryable();
        }
    }
}