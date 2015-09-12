using Autofac.Extras.RegistrationAttributes.RegistrationAttributes;

namespace Autofac.Extras.RegistrationAttributes.UnitTests.ScannedAssembly
{
    [As(typeof (ITestClass))]
    public class TestClass : ITestClass
    {
    }
}
