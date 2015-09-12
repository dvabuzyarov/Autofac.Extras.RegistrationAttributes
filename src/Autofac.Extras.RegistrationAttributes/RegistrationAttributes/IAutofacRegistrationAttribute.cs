using Autofac.Builder;

namespace Autofac.Extras.RegistrationAttributes.RegistrationAttributes
{
    public interface IAutofacRegistrationAttribute
    {
        IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> Register
            <TLimit, TActivatorData, TRegistrationStyle>(
            IRegistrationBuilder<TLimit, TActivatorData, TRegistrationStyle> builder);
    }
}