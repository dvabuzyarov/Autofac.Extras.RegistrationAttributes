using System;

namespace Autofac.Extras.RegistrationAttributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class AsCustomAttribute : Attribute, IAutofacCustomRegistrationAttribute
    {
        private readonly Type _customRegistrationHandler;

        public AsCustomAttribute(Type customRegistrationHandler)
        {
            _customRegistrationHandler = customRegistrationHandler;
        }

        public void Register(Type type, ContainerBuilder builder)
        {
            var registration = (IAutofacCustomRegistration)Activator.CreateInstance(_customRegistrationHandler);
            registration.Register(type, builder);
        }
    }
}