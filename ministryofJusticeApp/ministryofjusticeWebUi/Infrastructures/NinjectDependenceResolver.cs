using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ministryofjusticeDomain.IdentityEntities;
using ministryofjusticeDomain.Interfaces;
using ministryofjusticeDomain.Repositories;
using ministryofjusticeDomain.Services;

namespace ministryofjusticeWebUi.Infrastructures
{
    public class NinjectDependenceResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependenceResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind(typeof(ApplicationDbContext)).ToSelf();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
            kernel.Bind<IDepartmentRepo>().To<DepartmentRepo>();
            kernel.Bind<IUserManagerRepo>().To<UserManagerRepo>();
            kernel.Bind<IProfileRepo>().To<ProfileRepo>();
            kernel.Bind<IRoleService>().To<RoleService>();
        }
    }
}