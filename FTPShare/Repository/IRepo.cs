using System;
using System.Collections.Generic;

namespace FTPShare.Repository
{
    public interface IRepo<T> where T: class
    {
        IEnumerable<T> GetAll();
        T GetById(object Id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(Object Id);
        void Save();
    }
}