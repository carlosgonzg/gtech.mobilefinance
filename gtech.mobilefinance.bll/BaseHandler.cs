using gtech.mobilefinance.dal;
using gtech.mobilefinance.bll.Util;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace gtech.mobilefinance.bll
{

    public class BaseHandler<T> where T : Model, new()
    {
        protected DataContext _dbContext = new DataContext();
        public DbSet<T> _set;

        public BaseHandler()
        {
            _set = _dbContext.Set<T>();
        }

        public async Task<T> Create(T baseObject)
        {
            //Creo
            baseObject.Validate();
            _set.Add(baseObject);
            await _dbContext.SaveChangesAsync();
            return baseObject;
        }

        public async Task<List<T>> Retrieve(T baseObject = null)
        {
            //Filtro segun los datos en baseObject, si todo esta en null traigo todo
            List<T> list = new List<T>();
            try
            {
                list = await (from bs in _set
                              select bs).ToListAsync();
            }
            catch (Exception e)
            {
                throw new ErrorException(CodeStatus.ErrorOnReceive, e.Message);
            }
            return list;
        }

        public async Task Update(int id, T baseObject)
        {
            //Update segun ID, si no trae ID entonces tiro excepcion
            try
            {
                //baseObject.Validate();
                T auxObj = await _set.FirstAsync(x => x.Id == id);
                if (auxObj != null)
                {
                    foreach (var property in baseObject.GetType().GetProperties())
                    {
                        var propertyName = property.Name;
                        var propertyValue = property.GetValue(baseObject, null);
                        if (propertyName != "Id" && propertyValue != null && !propertyValue.Equals("") && !propertyValue.Equals(0))
                        {
                            
                            auxObj.GetType().GetProperty(propertyName).SetValue(auxObj, propertyValue, null);
                        }
                    }
                    _dbContext.Entry(auxObj).State = EntityState.Modified;
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception("The object {" + baseObject.GetType().Name + "} with the Id: " + id + " wasn't found.");
                }
            }
            catch (Exception e)
            {
                throw new ErrorException(CodeStatus.ErrorOnUpdate, e.Message);
            }
        }

        public async Task Delete(int id)
        {
            //Borro segun Id, si no trae ID entonces tiro excepcion
            try
            {
                T auxObj = await _set.FirstAsync(x => x.Id == id);
                _set.Remove(auxObj);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new ErrorException(CodeStatus.ErrorOnDelete, e.Message);
            }
        }
    }
}