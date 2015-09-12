using System;

namespace Autofac.Extras.RegistrationAttributes.Registrations
{
    public class DebugRegistration : IAutofacCustomRegistration
    {
        public void Register(Type type, ContainerBuilder builder)
        {
#if DEBUG
            builder.AutoRegistrationSkipCustomRegistration(type);
#endif
        }
    }
}