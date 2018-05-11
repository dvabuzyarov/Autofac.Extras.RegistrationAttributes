using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac.Extras.RegistrationAttributes.RegistrationAttributes;

namespace Autofac.Extras.RegistrationAttributes
{
    public static class ContainerBuilderExtensions
    {
        public static void AutoRegistration(this ContainerBuilder builder, params Assembly[] assemblies)
        {
            var types = from assembly in assemblies
                        from type in assembly.GetTypes()
                        select type;

            builder.AutoRegistration(types.ToArray());
        }

        public static void AutoRegistration(
            this ContainerBuilder builder,
            params Type[] types)
        {
            foreach (Type type in types)
            {
                var customRegistrations = type
                    .GetCustomAttributes(typeof(IAutofacCustomRegistrationAttribute), false)
                    .OfType<IAutofacCustomRegistrationAttribute>().ToArray();

                if (customRegistrations.Any())
                {
                    foreach (var registration in customRegistrations)
                    {
                        registration.Register(type, builder);
                    }
                }
                else
                {
                    AutoRegistrationSkipCustomRegistration(builder, type);
                }
            }
        }

        public static void AutoRegistrationSkipCustomRegistration(this ContainerBuilder builder, Type type)
        {
            var attributes = type
                .GetCustomAttributes(typeof(IAutofacRegistrationAttribute), false)
                .OfType<IAutofacRegistrationAttribute>()
                .ToArray();

            if (attributes.Any() == false) return;

            if (type.IsGenericType)
                RegisterGenericType(builder, type, attributes);
            else
                RegisterType(builder, type, attributes);
        }

        private static void RegisterType(ContainerBuilder builder, Type type, IEnumerable<IAutofacRegistrationAttribute> attributes)
        {
            var registrationBuilder = builder.RegisterType(type);

            foreach (IAutofacRegistrationAttribute attribute in attributes)
            {
                registrationBuilder = attribute.Register(registrationBuilder);
            }
        }

        private static void RegisterGenericType(ContainerBuilder builder, Type type, IEnumerable<IAutofacRegistrationAttribute> attributes)
        {
            var registrationBuilder = builder.RegisterGeneric(type);

            foreach (IAutofacRegistrationAttribute attribute in attributes)
            {
                registrationBuilder = attribute.Register(registrationBuilder);
            }
        }
    }
}