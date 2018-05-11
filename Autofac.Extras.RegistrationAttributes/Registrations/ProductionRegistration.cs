using System;

namespace Autofac.Extras.RegistrationAttributes.Registrations
{
    public class ProductionRegistration : IAutofacCustomRegistration
    {
        public void Register(Type type, ContainerBuilder builder)
        {
#if Release
            builder.AutoRegistrationSkipCustomRegistration(type);
#endif
        }
    }
}