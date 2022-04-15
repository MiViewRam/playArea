using IntegrationService.Data;
using MiView.Testing.Helpers;
using Xunit;

namespace IntegrationService.Tests
{
    public class IntegrationProviderTest
    {
        private readonly DatabaseContextHelper<IntegrationServiceContext> _dbHelper;
        private readonly TestContext<IntegrationServiceContext> _testContext;

        public IntegrationProviderTest()
        {
            _dbHelper = new DatabaseContextHelper<IntegrationServiceContext>(GetType().ToString());
            _testContext = new TestContext<IntegrationServiceContext>(_dbHelper);
        }

        [Fact]
        public Task Test()
        {
            return Task.CompletedTask;
        }
    }
}
