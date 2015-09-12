using System;
using Autofac.Builder;

namespace Autofac.Extras.RegistrationAttributes.RegistrationAttributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class ExternallyOwnedAttribute : Attribute, IAutofacRegistrationAttribute
    {
        public IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> Register
            <TLimit, TActivatorData, TRegistrationStyle>(
            IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> builder)
        {
            return builder.ExternallyOwned();
        }
    }
}