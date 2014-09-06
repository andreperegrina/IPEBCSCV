using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;

namespace Common.Data
{
    public interface IDataAccess<TEntity> where TEntity : class
    {
        int Save(TEntity entityObject);
        int Delete(TEntity entityObject);
        TEntity Find(Expression<Func<TEntity, bool>> predicate);
        List<TEntity> FindAll();
        int executeProcedure(String procedureName);
        int executeProcedure(String procedureName, List<ObjectParameter> parameters);
        int SaveOrUpdate(TEntity entityObject);
        List<TEntity> ExecuteQuery(String query);
        List<TEntity> GetByCriteria(Dictionary<String, ArrayList> criteria);
    }
}
