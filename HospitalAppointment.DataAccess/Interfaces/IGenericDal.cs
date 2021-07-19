using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace HospitalAppointment.DataAccess.Interfaces
{
    public interface IGenericDal<TEntity> where TEntity : new()
    {
        TEntity AddWithRetObject(TEntity entity);
        void Add(TEntity entity);
        void Remove(TEntity entity);
        void Update(TEntity entity);

        TEntity GetById(int id);
        List<TEntity> GetAll();
    }
}
