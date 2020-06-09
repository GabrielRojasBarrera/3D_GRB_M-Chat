
using M_Chat.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace M_Chat.Services
{
    public interface IRepository<T> where T : BaseEntity
    {
        public IEnumerable<Models.Container> GetAll();

        public T GetT(int id);

        public int Insert(T obj);

        public void Update(T obj);

        public int Delete(T obj);

    }
}
