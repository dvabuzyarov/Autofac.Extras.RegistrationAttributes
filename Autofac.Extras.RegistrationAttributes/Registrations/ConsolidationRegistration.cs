using System;

namespace Autofac.Extras.RegistrationAttributes.Registrations
{
    public class ConsolidationRegistration : IAutofacCustomRegistration
    {
        public void Register(Type type, ContainerBuilder builder)
        {
#if Consolidation
            builder.AutoRegistrationSkipCustomRegistration(type);
#endif
        }
    }
}