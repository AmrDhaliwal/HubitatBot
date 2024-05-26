namespace HubitatBot.Hub;

public class HubitatHub
{
    private string _hub_mac;
    private string _host;
    private string _token;
    private int _maker_app_id;
    private string? _cloud_token = null;
    private string _base_url;
    public HubitatHub(string hub_mac, string host, string token, int maker_app_id, string? cloud_token=null)
    {
        this._hub_mac = hub_mac;
        this._host = host;
        this._token = token;
        this._maker_app_id = maker_app_id;
        if (cloud_token is not null)
        {
            this._cloud_token = cloud_token;
            this._base_url = this._host + "/api/" + this._cloud_token + "/apps/" + this._maker_app_id + "/devices";
        }
        else
        {
            this._base_url = this._host + "/apps/api/" + "/apps/" + this._maker_app_id + "/devices";
        }
    }
}
