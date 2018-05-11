using System;

namespace Autofac.Extras.RegistrationAttributes
{
    public interface IAutofacCustomRegistration
    {
        void Register(Type type, ContainerBuilder builder);
    }
}