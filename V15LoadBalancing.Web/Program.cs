using Umbraco.Cms.Infrastructure.DependencyInjection;
using V15LoadBalancing.Web.ServerRoleAccessors;
using V15LoadBalancing.Web;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

var umbracoBuilder = builder.CreateUmbracoBuilder()
	.AddBackOffice()
	.AddWebsite()
	.AddDeliveryApi()
	.AddComposers();

if (builder.Environment.EnvironmentName.Equals("Subscriber"))
{
	umbracoBuilder.SetServerRegistrar<SubscriberServerRoleAccessor>()
		.AddAzureBlobMediaFileSystem()
		.AddAzureBlobImageSharpCache()
		.AddSqlServerCache(); // make a redis cache per region instead
}
else if (builder.Environment.IsProduction())
{
	umbracoBuilder.SetServerRegistrar<SchedulingPublisherServerRoleAccessor>();

}
else if (builder.Environment.EnvironmentName.Equals("Local"))
{
	umbracoBuilder.SetServerRegistrar<SingleServerRoleAccessor>();
}
else
{
	umbracoBuilder.SetServerRegistrar<SingleServerRoleAccessor>()
		.AddSqlServerCache();
}

umbracoBuilder.Build();

WebApplication app = builder.Build();

await app.BootUmbracoAsync();

app.UseHttpsRedirection();

app.UseUmbraco()
	.WithMiddleware(u =>
	{
		u.UseBackOffice();
		u.UseWebsite();
	})
	.WithEndpoints(u =>
	{
		u.UseBackOfficeEndpoints();
		u.UseWebsiteEndpoints();
	});

await app.RunAsync();