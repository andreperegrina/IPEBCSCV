using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using Common.Data;
using IPEBCSCV.BusinessEntity;

namespace Common.Data
{

    public class DataAccess<TEntity> : IDataAccess<TEntity>
          where TEntity : class
    {
        private static ipebc_scvEntities _dbContext;
        private static ipebc_scvEntities dbContext
        {
            get
            {
                if (_dbContext == null)
                {
                    _dbContext = new ipebc_scvEntities();
                }
                return _dbContext;
            }
            set
            {
                _dbContext = value;
            }
        }


        #region Singleton
        private static readonly object TheLock = new Object();
        public DataAccess()
        {
            // DataContext.SavingChanges += new EventHandler(context_SavingChanges);
        }

        protected static ipebc_scvEntities GetCurrentContext()
        {

            HttpContext httpContext = HttpContext.Current;

            if (httpContext != null)
            {

                //string contextTypeKey = dbContext + typeof(TEntity).Name;
                string contextTypeKey = "Contexto";
                if (httpContext.Items[contextTypeKey] == null)
                {

                    httpContext.Items.Add(contextTypeKey, new ipebc_scvEntities());

                }

                return httpContext.Items[contextTypeKey] as ipebc_scvEntities;
            }
            throw new ApplicationException("There is no Http Context available");

        }

        public static DataAccess<TEntity> Instance
        {
            get
            {
                //lock (TheLock)
                //{
                //    if (_instance == null)
                //    {
                //        _instance = new DataAccess<TEntity>();
                //    }
                //}
                return new DataAccess<TEntity>();
            }
        }

        #endregion

        public bool ExistObject(Func<TEntity, bool> predicate)
        {
            return GetCurrentContext().Set<TEntity>().Where<TEntity>(predicate).Count() > 0;
        }

        public int Save(TEntity entityObject)
        {
            try
            {
                GetCurrentContext().Set<TEntity>().Add(entityObject);
                return GetCurrentContext().SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public int Save(List<TEntity> listEntityObject)
        {

            try
            {
                foreach (var item in listEntityObject)
                {
                    GetCurrentContext().Set<TEntity>().Add(item);
                }
                return GetCurrentContext().SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public int Update(TEntity entityObject)
        {
            try
            {
                GetCurrentContext().Entry<TEntity>(entityObject).State = EntityState.Modified;
                return GetCurrentContext().SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int Delete(TEntity entityObject)
        {
            try
            {
                GetCurrentContext().Set<TEntity>().Remove(entityObject);
                return GetCurrentContext().SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<TEntity> FindAll()
        {
            //using (SGO_TEPEntities contexto = new SGO_TEPEntities())
            //{
            //    contexto.Configuration.LazyLoadingEnabled = false;
            //    return contexto.Set<TEntity>().ToList<TEntity>();
            //}
            try
            {
                return GetCurrentContext().Set<TEntity>().ToList<TEntity>();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                IQueryable<TEntity> getCurrentContextSetWhere = GetCurrentContext().Set<TEntity>().Where<TEntity>(predicate);
                if (getCurrentContextSetWhere.Count() > 0)
                    return getCurrentContextSetWhere.First<TEntity>();
                else
                    return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int SaveOrUpdate(TEntity entityObject)
        {
            try
            {
                DbEntityEntry<TEntity> dbContextEntry = GetCurrentContext().Entry<TEntity>(entityObject);
                dbContextEntry.State = (dbContextEntry.State == EntityState.Detached) ? EntityState.Added : EntityState.Modified;
                return GetCurrentContext().SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<TEntity> Search(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return GetCurrentContext().Set<TEntity>().Where<TEntity>(predicate).ToList<TEntity>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int executeProcedure(string procedureName)
        {
            return GetCurrentContext().Database.ExecuteSqlCommand(procedureName);
        }

        public int executeProcedure(string procedureName, List<ObjectParameter> parameters)
        {
            return GetCurrentContext().Database.ExecuteSqlCommand(procedureName, parameters);
        }


        public List<TEntity> GetByCriteria(Dictionary<string, ArrayList> criteria)
        {
            try
            {
                return GetCurrentContext().Set<TEntity>().Where<TEntity>(CreatePredicate(criteria)).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Este metodo obtiene el tipo de una expresión.
        /// </summary>
        /// <param name="property">Expresión que se requiere obtener su tipo</param>
        /// <returns>Regresa el tipo de dato de una expresión</returns>
        protected Type getTypeOfProperty(Expression property)
        {
            try
            {
                var body = property as MemberExpression;
                if (body == null)
                {
                    throw new ArgumentException("'expression' should be a member expression");
                }
                var propertyInfo = (PropertyInfo)body.Member;
                return propertyInfo.PropertyType;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Este metodo crea una expresión lambda de igualdad.
        /// </summary>
        /// <param name="nameProperty">nombre de la propiedad que se busca</param>
        /// <param name="value">valor que se busca</param>
        /// <returns>Regresa una expresión lambda</returns>
        private Expression CreateEqualExpression(Expression nameProperty, Object value)
        {
            //Este metodo crea una nueva expression  de igualdad Ej: id==4
            Type propertyType = getTypeOfProperty(nameProperty); //Esta instruccion se utiliza para verificar el tipo de la propiedad
            /*
             *En caso de que la propiedad no encuentre el método Constant creara una constante 
             *Expression con el tipo de dato que crea que pertenece la razón por la cual se utiliza 
             *el anterior método es para asegurar que se esté utilizando el tipo correcto para la constante, 
             *como puede ser el caso de los tipo bool? que permiten un valor null, en caso de que el valor 
             *sea bool el método Constant lo interpretara como un tipo bool causando un error en el método equal de Expression
             */
            Expression constantValue;
            if (propertyType == null)
            {
                constantValue = Expression.Constant(value);
            }
            else
            {
                constantValue = Expression.Constant(value, propertyType);
            }
            return Expression.Equal(nameProperty, constantValue);
        }

        /// <summary>
        /// Este metodo crea una expresión lambda apartir de un diccionario de criterios
        /// </summary>
        /// <param name="criteria">Criterios para la creación de la expresión</param>
        /// <returns>Regresa una expresión lambda de los criterios</returns>
        private Expression<Func<TEntity, bool>> CreatePredicate(Dictionary<String, ArrayList> criteria)
        {
            try
            {
                ParameterExpression argParam = Expression.Parameter(typeof(TEntity), "s");
                bool isFirstExpressionCreated = true;
                BinaryExpression orExpression = null;
                Expression newExpression1 = null;
                foreach (KeyValuePair<String, ArrayList> elementCriteria in criteria)
                {
                    //Este foreach se utiliza para obtener cada elemento del diccionario
                    foreach (Object elementList in elementCriteria.Value)
                    {
                        //En este foreach se obtendra cada elemento del arraylist
                        Expression newExpression2 = null;
                        if (isFirstExpressionCreated)
                        {
                            newExpression1 = CreateEqualExpression(Expression.Property(argParam, elementCriteria.Key), elementList);
                            isFirstExpressionCreated = false;
                        }
                        else
                        {
                            if (orExpression == null)
                            {
                                //En caso de que no se haya creado la expresión binaria se crea una.
                                newExpression2 = CreateEqualExpression(Expression.Property(argParam, elementCriteria.Key), elementList);
                                orExpression = Expression.Or(newExpression1, newExpression2);
                            }
                            else
                            {
                                //Si ya existe una expresión binaria se modifica para seguir agregando parametros de busqueda.
                                newExpression2 = CreateEqualExpression(Expression.Property(argParam, elementCriteria.Key), elementList);
                                Expression<Func<TEntity, bool>> leftexp = Expression.Lambda<Func<TEntity, bool>>(orExpression, argParam);
                                Expression<Func<TEntity, bool>> rightexp = Expression.Lambda<Func<TEntity, bool>>(newExpression2, argParam);
                                orExpression = Expression.Or(leftexp.Body, rightexp.Body);
                            }
                        }
                    }
                }
                if (orExpression == null)
                {
                    if (newExpression1 != null)
                    {
                        return Expression.Lambda<Func<TEntity, bool>>(newExpression1, argParam);
                    }
                    else
                    {
                        return e => 0 == 0;
                    }
                }
                return Expression.Lambda<Func<TEntity, bool>>(orExpression, argParam);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int ModifySpecificProperties(TEntity entityObjectUpdate, System.Collections.ArrayList updatePropertyNameList)
        {
            try
            {
                DbEntityEntry<TEntity> getCurrentContextEntry = GetCurrentContext().Entry<TEntity>(entityObjectUpdate);
                foreach (String updatePropertyName in updatePropertyNameList)
                {
                    getCurrentContextEntry.Property(updatePropertyName).IsModified = true;
                }
                int couldSave = GetCurrentContext().SaveChanges();
                return couldSave;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<TEntity> ExecuteQuery(string query)
        {
            try
            {
                return GetCurrentContext().Database.SqlQuery<TEntity>(query).ToList();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<EntityWrapper> ExecuteQueryCommand<EntityWrapper>(string query) where EntityWrapper : class
        {
            try
            {
                ////ipebc_scvEntities
                //using (var con = new EntityConnection("name=ipebc_scvEntities"))
                //{
                //    con.Open();
                //    EntityCommand cmd = con.CreateCommand();
                //    cmd.CommandText = query;
                //    Dictionary<int, string> dict = new Dictionary<int, string>();
                //    return cmd.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.CloseConnection);
                //}
                return GetCurrentContext().Database.SqlQuery<EntityWrapper>(query).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<TEntity> GetByCriteria(Dictionary<string, List<Expression<Func<TEntity, bool>>>> criteria)
        {
            try
            {
                return GetCurrentContext().Set<TEntity>().Where<TEntity>(CreatePredicate(criteria)).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private Expression<Func<TEntity, bool>> CreatePredicate(Dictionary<string, List<Expression<Func<TEntity, bool>>>> criteria)
        {
            try
            {

                Expression<Func<TEntity, bool>> masterPredicate = null;
                foreach (KeyValuePair<String, List<Expression<Func<TEntity, bool>>>> elementCriteria in criteria)
                {

                    Expression<Func<TEntity, bool>> tempPredicate = null;
                    //Este foreach se utiliza para obtener cada elemento del diccionario
                    foreach (Expression<Func<TEntity, bool>> elementList in elementCriteria.Value)
                    {
                        if (tempPredicate == null)
                            tempPredicate = elementList;
                        else
                            tempPredicate = PredicateBuilder.Or<TEntity>(tempPredicate, elementList);
                    }
                    if (masterPredicate == null)
                        masterPredicate = tempPredicate;
                    else
                        masterPredicate = PredicateBuilder.And<TEntity>(masterPredicate, tempPredicate);
                }

                return masterPredicate;

                //Expression<Func<TEntity, bool>> masterPredicate = null;
                //foreach (KeyValuePair<String, List<Expression<Func<TEntity, bool>>>> elementCriteria in criteria)
                //{

                //    Expression<Func<TEntity, bool>> tempPredicate = null;
                //    Este foreach se utiliza para obtener cada elemento del diccionario
                //    foreach (Expression<Func<TEntity, bool>> elementList in elementCriteria.Value)
                //    {
                //        if (tempPredicate == null)
                //            tempPredicate = elementList;
                //        else
                //            tempPredicate = Expression.Lambda<Func<TEntity, bool>>(Expression.Or(tempPredicate, elementList), tempPredicate.Parameters);
                //    }
                //    if (masterPredicate == null)
                //        masterPredicate = tempPredicate;
                //    else
                //        masterPredicate = Expression.Lambda<Func<TEntity, bool>>(Expression.And(masterPredicate, tempPredicate), masterPredicate.Parameters);
                //}

                //return masterPredicate;

            }
            catch (Exception)
            {
                throw;
            }
        }



    }
}
