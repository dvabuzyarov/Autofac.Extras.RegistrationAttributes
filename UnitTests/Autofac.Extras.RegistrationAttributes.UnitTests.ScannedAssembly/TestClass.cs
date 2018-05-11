using Autofac.Extras.RegistrationAttributes.RegistrationAttributes;

namespace UnitTests.ScannedAssembly
{
    [As(typeof (ITestClass))]
    public class TestClass : ITestClass
    {
    }
}
