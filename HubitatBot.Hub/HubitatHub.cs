using System.Net.Http.Json;
using System.Text.Json;

namespace HubitatBot.Hub;

public sealed class HubitatHub(IMakerAPI makerAPI, string host, string token, int appId) : BaseHubitatHub
{
    private IMakerAPI HubClient { get; } = makerAPI;
    private readonly string _host = host;
    private readonly string _token = token;
    private readonly int _appId = appId;
    private readonly string _base_uri = host + "/apps/api/" + appId + "/devices/";
    public async Task<string> GetDevices()
    {
        try
        {
            var response = await this.HubClient.GetDevices(this._token);
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
