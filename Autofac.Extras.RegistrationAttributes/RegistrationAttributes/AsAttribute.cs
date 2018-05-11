using System;
using Autofac.Builder;

namespace Autofac.Extras.RegistrationAttributes.RegistrationAttributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class AsAttribute : Attribute, IAutofacRegistrationAttribute
    {
        private readonly Type[] _asTypes;

        public AsAttribute(Type asType)
        {
            _asTypes = new[] { asType };
        }

        public AsAttribute(Type[] asTypes)
        {
            _asTypes = asTypes;
        }

        public IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> Register
            <TLimit, TActivatorData, TRegistrationStyle>(
            IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> builder)
        {
            return builder.As(_asTypes).ExternallyOwned();
        }
    }
}