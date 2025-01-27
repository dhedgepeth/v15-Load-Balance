using Umbraco.Cms.Core.Sync;

namespace V15LoadBalancing.Web.ServerRoleAccessors
{
	public sealed class SubscriberServerRoleAccessor : IServerRoleAccessor
	{
		public ServerRole CurrentServerRole => ServerRole.Subscriber;
	}
}