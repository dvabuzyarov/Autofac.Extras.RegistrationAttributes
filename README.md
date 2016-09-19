# Autofac.Extras.Attribute

Component registering into Autocaf container using attributes
## Simple steps
1. Mark implementation with attribute
```cs
    [As(typeof (INowProvider))]
    [SingleInstance]
    class NowProvider : INowProvider
    {
        public DateTime UtcNow()
        {
            return DateTime.UtcNow;
        }
    }
```
2. Create assembly registration
```cs
    
    namespace AssemblyNameSpace
    {
      public class AutoRegistrationModule : Module
      {
          protected override void Load(ContainerBuilder builder)
          {
              base.Load(builder);
              builder.AutoRegistration(GetType().Assembly);
          }
      }
```
3. Call all assemblies specific Ninject modules in the main assembly
```cs
    using Ninject.Extensions.MetadataRegistration;
    using Ninject.Modules;
    
    namespace MainAssemblyNameSpace
    {
        public class AutoRegistrationModule : Module
        {
            protected override void Load(ContainerBuilder builder)
            {
                base.Load(builder);
                builder.AutoRegistration(GetType().Assembly);
                //---either---
                builder.AutoRegistration(typeof(TypeFromOtherAssembly).Assembly);
                //---or---
                builder.RegisterModule<OtherAssemblyNamespace.AutoRegistrationModule>();
            }
        }
    }
```
## Supported attributes
1. AsAttribute - The implementation class will be registred as specified type
```cs
    [As(typeof (ITemplateUserProvider))]
    class ExampleClass : ITemplateUserProvider
    {
        private readonly INowProvider _nowProvider;
    
        public ExampleClass(INowProvider nowProvider) 
        {
            _nowProvider = nowProvider;
        }
    
        public string CurrentDateTimeAsString()
        {
            _nowProvider.UtcNow().ToString();
        }
    }
```
2. SingleInstanceAttribute - The single instance of the implementation class will be shared across all consumers
3. NamedAttribute - It creates a named registration
```cs
    [Named(typeof(IDownloadParams), "Download1")]
    class DownloadParams : IDownloadParams
    {
        public string PageUrl { get; private set; }

        public DownloadParams()
        {
            PageUrl = "http://google.com";
        }
    }
    
    
    [As(typeof (IDownloadSetvice))]
    [SingleInstance]
    class DownloadSetvice : IDownloadSetvice
    {
        private readonly IContainer _container;

        public DownloadParamsFactory(IContainer container)
        {
            _container = container;
        }

        public string Get(string paramsName)
        {
            return _container.ResolveNamed<IDownloadParams>('Download1');
            // --- some action here
        }
    }

```

4. ExternallyOwnedAttribute - setup a registration as externally owned.
5. AsCustomAtrribute - you can specify your custom registration, here is an expample how I am using it
```cs
    [As(typeof(ISomeService))]
    [SingleInstance]
    [AsCustom(typeof (DebugRegistration))]
    class SomeServiceFake : ISomeService
    {
        public SomeServiecFake()
        {
        }

        public IEnumerable<string> Payload()
        {
            yield return "concept 1";
            yield return "concept 2";
            yield return "concept 3";
        }
    }


    [As(typeof(ISomeService))]
    [SingleInstance]
    [AsCustom(typeof(ProductionRegistration))]
    [AsCustom(typeof(DevelopmentRegistration))]
    [AsCustom(typeof(ConsolidationRegistration))]
    class SomeService : ISomeService
    {
        public SomeServiec()
        {
        }

        public IEnumerable<string> Payload()
        {
            //--- read data from remote source
        }
    }
    
  So if DEBUG constans is defined the first implementation will be resolved from the DI.
  If DEBUG constant is not defined then the first implementation will not be registred.
  
  You just need to implement IAutofacCustomRegistration interface in your custom registration.

```
