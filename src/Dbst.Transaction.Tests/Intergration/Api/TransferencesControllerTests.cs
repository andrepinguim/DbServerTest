using System.Net.Http;
using System.Threading.Tasks;
using Dbst.Transaction.Api;
using Dbst.Transaction.Api.Models;
using Xunit;
using Newtonsoft.Json;
using System.Text;
using System.Net;

namespace Dbst.Transaction.Tests.Intergration.Api
{
    public class TransferencesControllerTests : IClassFixture<MockWebAppFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly MockWebAppFactory<Startup> _factory;

        public TransferencesControllerTests(MockWebAppFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Theory]
        [InlineData(3, 2, 120)]
        [InlineData(1, 2, 10.55)]
        public async Task SuccessfullyTransference(int originId, int destinationId, double value)
        {
            var transference = new Transference()
            {
                OriginAccountId = originId,
                DestinationAccountId = destinationId,
                Value = value
            };
            var reqJson = JsonConvert.SerializeObject(transference);

            var resp = await _client.PostAsync("/api/transferences", new StringContent(reqJson, Encoding.UTF8, "application/json"));
            resp.EnsureSuccessStatusCode();

            Assert.NotNull(resp);
            Assert.True(resp.StatusCode == HttpStatusCode.OK);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(1, 0, 0)]
        [InlineData(1, 2, 0)]
        [InlineData(-1, 0, 0)]
        [InlineData(-1, -2, 0)]
        [InlineData(-1, -2, -3)]
        [InlineData(9999, 2, 100)]
        [InlineData(1, 8888, 100)]
        public async Task UnsuccessfullyAuthentication(int originId, int destinationId, double value)
        {
            var transference = new Transference()
            {
                OriginAccountId = originId,
                DestinationAccountId = destinationId,
                Value = value
            };
            var reqJson = JsonConvert.SerializeObject(transference);

            var resp = await _client.PostAsync("/api/transferences", new StringContent(reqJson, Encoding.UTF8, "application/json"));

            Assert.NotNull(resp);
            Assert.True(resp.StatusCode == HttpStatusCode.BadRequest);
        }
    }
}
