using System.Reflection;
using Autofac;
using AutoMapper;
using CRUD.Application.Items.Commands;
using CRUD.Domain.Items.Models;
using CRUD.Infrastructure.MongoDb.Items;
using CRUD.Infrastructure.Persistence.Items;
using CRUD.Web.Mocks;
using PlaygroundShared.Application.IoC;
using PlaygroundShared.Domain.IoC;
using PlaygroundShared.Domain.Shared;
using PlaygroundShared.Infrastructure.Core.IoC;
using PlaygroundShared.Infrastructure.MongoDb.IoC;
using PlaygroundShared.Messages;
using Module = Autofac.Module;

public class RootModule : Module
{   
    private readonly IConfiguration _configuration;

    public RootModule(IConfiguration configuration)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }
    
    protected override void Load(ContainerBuilder builder)
    {
        base.Load(builder);

        builder.RegisterModule(new MongoDbModule(_configuration, typeof(ItemMongoRepository).Assembly));
        builder.RegisterModule(new DomainModule(typeof(Item).Assembly));
        builder.RegisterModule(new InfrastructureModule(new []{typeof(ItemMongoRepository).Assembly,typeof(ItemRepository).Assembly}));
        builder.RegisterModule(new ApplicationModule(typeof(CreateItemCommand).Assembly));
        builder.Register(ctx => new CorrelationContext()).As<ICorrelationContext>().InstancePerLifetimeScope();
        
        builder.Register(ctx =>
        {
            var assemblies = new List<Assembly>()
            {
                typeof(ItemMappings).Assembly
            };

            var profiles = assemblies.SelectMany(x => x.GetExportedTypes()).Where(x => x.IsAssignableTo<Profile>())
                .Select(x => (Profile) Activator.CreateInstance(x));

            var cfg = new MapperConfiguration(m =>
            {
                m.DisableConstructorMapping();
                m.AddProfiles(profiles);
            });

            return new Mapper(cfg);
        }).As<IMapper>().InstancePerLifetimeScope();

        builder.RegisterType<FakeMessagePublisher>().As<IMessagePublisher>().InstancePerLifetimeScope();
    }
}