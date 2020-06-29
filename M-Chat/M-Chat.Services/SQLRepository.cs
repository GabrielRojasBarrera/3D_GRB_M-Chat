using M_Chat.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace M_Chat.Services
{
    public class SQLRepository<T> :  IRepository<T> where T : Tutor
    {
        protected readonly AppDBContext context;
        private DbSet<T> entity;
        public SQLRepository(AppDBContext context)
        {
            this.context = context;
            entity = context.Set<T>();
        }

        public void Delete(T obj)
        {
            if (obj == null) throw new ArgumentException("Usuario");

            if (obj.Email == null) throw new ArgumentException("Email es requerido");

            

            var temp = entity.Attach(obj);
            temp.State = EntityState.Modified;

            context.SaveChanges();
        }

        public T Get(string Email)
        {
            return entity.SingleOrDefault(x => x.Email == Email);
        }

        public IEnumerable<T> GetAll()
        {
            return entity.AsEnumerable();
        }

        public string Insert(T obj)
        {
            if (obj == null) throw new ArgumentNullException("Usuari");

            entity.Add(obj);
            context.SaveChanges();
            return obj.Email;
        }

        public void Update(T obj)
        {
            if (obj == null) throw new ArgumentException("Usuario");

            if (obj.Email == null) throw new ArgumentException("Usuario");

            obj.Contraseña = string.Empty;

            var temp = entity.Attach(obj);
            temp.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
