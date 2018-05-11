using System;

namespace Autofac.Extras.RegistrationAttributes
{
    public interface IAutofacCustomRegistrationAttribute
    {
        void Register(Type type, ContainerBuilder builder);
    }
}