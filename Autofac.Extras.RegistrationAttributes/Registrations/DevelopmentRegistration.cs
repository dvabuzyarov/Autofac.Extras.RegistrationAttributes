using System;

namespace Autofac.Extras.RegistrationAttributes.Registrations
{
    public class DevelopmentRegistration : IAutofacCustomRegistration
    {
        public void Register(Type type, ContainerBuilder builder)
        {
#if Development
            builder.AutoRegistrationSkipCustomRegistration(type);
#endif
        }
    }
}