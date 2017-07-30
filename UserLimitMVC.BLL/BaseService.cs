using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLimitMVC.IBLL;
using UserLimitMVC.DAL;
using System.Linq.Expressions;

namespace UserLimitMVC.BLL
{
    public abstract class BaseService<T> : IBaseService<T> where T : class, new()
    {
        //当前仓储
        public IDAL.IBaseRepository<T> CurrentRepository { get; set; }

        //DbSession存放
        public DbSession _DbSession = new DbSession();

        public BaseService()
        {
            SetCurrentRepostory();
        }

        public abstract void SetCurrentRepostory();

        public T AddEntity(T entity)
        {
            //调用T对应的仓储来添加工作
            var AddEntity = CurrentRepository.AddEntity(entity);
            _DbSession.SaveChanges();
            return AddEntity;
        }

        public bool UpdateEntity(T entity)
        {
            CurrentRepository.UpdateEntity(entity);
            return _DbSession.SaveChanges() > 0;
        }

        public bool DeleteEntity(T entity)
        {
            CurrentRepository.DeleteEntity(entity);

            return _DbSession.SaveChanges() > 0;
        }

        /// <summary>
        /// 实现数据库查询
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda)
        {
            return CurrentRepository.LoadEntities(whereLambda);
        }

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
        public IQueryable<T> LoadPageEntities<S>(int pageIndex, int pageSize, out int total, Expression<Func<T, bool>> whereLambda, bool isAsc, Expression<Func<T, S>> orderByLambda)
        {
            return CurrentRepository.LoadPageEntities(pageIndex, pageSize, out total, whereLambda, isAsc, orderByLambda);
        }
    }
}