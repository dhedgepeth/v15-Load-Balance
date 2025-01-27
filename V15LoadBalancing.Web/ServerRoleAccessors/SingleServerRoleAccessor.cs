using Umbraco.Cms.Core.Sync;

namespace V15LoadBalancing.Web.ServerRoleAccessors
{
	public sealed class SingleServerRoleAccessor : IServerRoleAccessor
	{
		public ServerRole CurrentServerRole => ServerRole.Single;
	}
}