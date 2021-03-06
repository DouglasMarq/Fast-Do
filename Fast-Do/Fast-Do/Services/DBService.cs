﻿using SQLite;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Fast_Do.Services
{
    public class DBService<T> where T : new()
    {
        protected static SQLiteConnection DB;

        public DBService()
        {
            if (DB == null)
                DB = DBGetConnection.GetConnection();

            DB.CreateTable<T>();
        }

        public virtual int Insert(T obj)
        {
            return DB.InsertOrReplace(obj);
        }

        public virtual void InsertList(List<T> lista)
        {
            DB.InsertAll(lista);
        }

        public virtual List<T> SelectAll()
        {
            return DB.Table<T>().ToList();
        }

        public virtual T SelectOne()
        {
            return DB.Table<T>().FirstOrDefault();
        }

        public void Update(T obj)
        {
            DB.Update(obj);
        }

        public virtual void Delete(int id)
        {
            DB.Delete<T>(id);
        }

        public int Count()
        {
            return DB.Table<T>().Count();
        }

        public void DeleteAll()
        {
            DB.DeleteAll<T>();
        }
    }
}
