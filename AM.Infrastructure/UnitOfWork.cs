﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using static AM.ApplicationCore.Interfaces.IGenericRepository;


namespace AM.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext context;

        public UnitOfWork(DbContext ctx)
        {
            context = ctx;
        }

        public IGenericRepository<T> Repository<T>() where T : class
        {
            return new GenericRepository<T>(context);
        }
        public int Save()
        {
            return context.SaveChanges();
        }

        /////////////Disposable/////////////////
        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    context.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }


    }
}
