using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.ScannedAssembly;

namespace Autofac.Extras.RegistrationAttributes.UnitTests
{
    [TestClass]
    public class ContainerBuilderExtensionsTests
    {

        [TestMethod]
        public void RegistersTypesFromAssembly()
        {
            var builder = new ContainerBuilder();
            ContainerBuilderExtensions.AutoRegistration(builder, typeof(ITestClass).Assembly);

            var container = builder.Build();
            var actual = container.Resolve<ITestClass>();

            Assert.IsInstanceOfType(actual, typeof(TestClass));
        }        
        
        [TestMethod]
        public void RegistersTypes()
        {
            var builder = new ContainerBuilder();
            ContainerBuilderExtensions.AutoRegistration(builder, typeof(TestClass));

            var container = builder.Build();
            var actual = container.Resolve<ITestClass>();

            Assert.IsInstanceOfType(actual, typeof(TestClass));
        }
    }
}