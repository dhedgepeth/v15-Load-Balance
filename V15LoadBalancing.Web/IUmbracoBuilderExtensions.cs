using Umbraco.Cms.Core;

namespace V15LoadBalancing.Web
{
	public static partial class IUmbracoBuilderExtensions
	{
		public static IUmbracoBuilder AddSqlServerCache(this IUmbracoBuilder builder)
		{
			builder.Services.AddDistributedSqlServerCache(options =>
			{
				options.SchemaName = "dbo";
				options.TableName = "SessionCache";
				options.ConnectionString = builder.Config.GetConnectionString(Constants.System.UmbracoConnectionName);
			});

			return builder;
		}
	}
}