using System;
using Autofac.Builder;

namespace Autofac.Extras.RegistrationAttributes.RegistrationAttributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class NamedAttribute : Attribute, IAutofacRegistrationAttribute
    {
        private readonly string _name;
        private readonly Type _asType;

        public NamedAttribute(Type asType, string name)
        {
            _name = name;
            _asType =  asType;
        }

        public IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> Register
            <TLimit, TActivatorData, TRegistrationStyle>(
            IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> builder)
        {
            return builder.Named(_name, _asType);
        }
    }
}