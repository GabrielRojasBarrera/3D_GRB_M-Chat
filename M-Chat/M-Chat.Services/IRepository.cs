using M_Chat.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace M_Chat.Services
{
    public interface IRepository<T> where T : Tutor
    {
        public IEnumerable<T> GetAll();

        public T Get(string Email);

        public string Insert(T obj);

        public void Update(T obj);

        public void Delete(T obj);
    }
}
