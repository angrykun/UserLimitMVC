using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;

namespace UserLimitMVC.IDAL
{
    public interface IBaseRepository<T> where T : class
    {
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T AddEntity(T entity);

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool UpdateEntity(T entity);

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool DeleteEntity(T entity);

        /// <summary>
        /// 实现数据库查询
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda);

        /// <summary>
        /// 分页查数据
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <param name="whereLambda"></param>
        /// <param name="isAsc"></param>
        /// <param name="orderByLambda"></param>
        /// <returns></returns>
        IQueryable<T> LoadPageEntities<S>(int pageIndex, int pageSize, out int total, Expression<Func<T, bool>> whereLambda, bool isAsc, Expression<Func<T, S>> orderByLambda);
    }
}