using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PaystackPaymentIntegration.Models
{
    public class BaseRepository<T> : IDisposable where T : DbContext, new()
    {
        private T _dataContext;

        public virtual T DataContext
        {
            get
            {
                if (_dataContext == null)
                {
                    _dataContext = new T();
                    Allowerialization = true;
                }
                return _dataContext;
            }
        }

        public virtual bool Allowerialization
        {
            get
            {
                return _dataContext.Configuration.ProxyCreationEnabled;
            }
            set
            {
                _dataContext.Configuration.ProxyCreationEnabled = !value;
            }
        }

        public void Dispose()
        {
            if (DataContext != null) DataContext.Dispose();
        }
    }
}