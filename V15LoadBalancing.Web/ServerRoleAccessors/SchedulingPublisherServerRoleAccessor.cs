using Umbraco.Cms.Core.Sync;

namespace V15LoadBalancing.Web.ServerRoleAccessors
{

	public sealed class SchedulingPublisherServerRoleAccessor : IServerRoleAccessor
	{
		public ServerRole CurrentServerRole => ServerRole.SchedulingPublisher;
	}
}