using System.Net.Http.Json;
using System.Text.Json;

namespace HubitatBot.Hub;

public sealed class HubitatHub(IHttpClientFactory httpClientFactory, string host, string token, int appId) : BaseHubitatHub
{
    private IHttpClientFactory HttpClient { get; } = httpClientFactory;
    private readonly string _host = host;
    private readonly string _token = token;
    private readonly int _appId = appId;
    private readonly string _base_uri = host + "/apps/api/" + appId + "/devices/";
    public async Task<string> GetDevices()
    {
        var client = this.HttpClient.CreateClient();
        try
        {
            var response = await client.GetStringAsync(
                $"{this._base_uri}/all?access_token={this._token}");
            return response ?? "";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
    public override void Dispose()
    {
    }
}
