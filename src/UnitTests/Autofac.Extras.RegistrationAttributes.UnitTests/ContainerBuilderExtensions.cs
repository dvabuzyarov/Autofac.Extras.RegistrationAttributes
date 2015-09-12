using Autofac.Extras.RegistrationAttributes.UnitTests.ScannedAssembly;
using Xunit;

namespace Autofac.Extras.RegistrationAttributes.UnitTests
{
    public class ContainerBuilderExtensionsTests
    {

        [Fact]
        public void RegistersTypesFromAssembly()
        {
            var builder = new ContainerBuilder();
            ContainerBuilderExtensions.AutoRegistration(builder, typeof(ITestClass).Assembly);

            var container = builder.Build();
            var actual = container.Resolve<ITestClass>();

            Assert.IsType<TestClass>(actual);
        }        
        
        [Fact]
        public void RegistersTypes()
        {
            var builder = new ContainerBuilder();
            ContainerBuilderExtensions.AutoRegistration(builder, typeof(TestClass));

            var container = builder.Build();
            var actual = container.Resolve<ITestClass>();

            Assert.IsType<TestClass>(actual);
        }
    }
}