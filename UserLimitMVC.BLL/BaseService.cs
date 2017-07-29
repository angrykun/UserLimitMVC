using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLimitMVC.IBLL;

namespace UserLimitMVC.BLL
{
    public abstract class BaseService<T> : IBaseService<T> where T : class, new()
    {
        public IDAL.IBaseRepository<T> CurrentRepository { get; set; }

        public BaseService()
        {
            SetCurrentRepostory();
        }

        public abstract void SetCurrentRepostory();

        public T AddEntity(T entity)
        {
            //调用T对应的仓储来添加工作
            return CurrentRepository.AddEntity(entity);
        }

        public bool UpdateEntity(T entity)
        {
            return CurrentRepository.UpdateEntity(entity);
        }

        public bool DeleteEntity(T entity)
        {
            return CurrentRepository.DeleteEntity(entity);
        }

        /// <summary>
        /// 实现数据库查询
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public IQueryable<T> LoadEntities(Func<T, bool> whereLambda)
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
        public IQueryable<T> LoadPageEntities<S>(int pageIndex, int pageSize, out int total, Func<T, bool> whereLambda, bool isAsc, Func<T, S> orderByLambda)
        {
            return CurrentRepository.LoadPageEntities(pageIndex, pageSize, out total, whereLambda, isAsc, orderByLambda);
        }
    }
}