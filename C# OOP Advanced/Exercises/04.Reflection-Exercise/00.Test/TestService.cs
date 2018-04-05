using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace _00.Test
{
    public class TestService : IServiceContainer
    {
        public object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public void AddService(Type serviceType, ServiceCreatorCallback callback)
        {
            throw new NotImplementedException();
        }

        public void AddService(Type serviceType, ServiceCreatorCallback callback, bool promote)
        {
            throw new NotImplementedException();
        }

        public void AddService(Type serviceType, object serviceInstance)
        {
            throw new NotImplementedException();
        }

        public void AddService(Type serviceType, object serviceInstance, bool promote)
        {
            throw new NotImplementedException();
        }

        public void RemoveService(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public void RemoveService(Type serviceType, bool promote)
        {
            throw new NotImplementedException();
        }
    }
}
