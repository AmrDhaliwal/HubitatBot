using Refit;

namespace HubitatBot.Hub;

public interface IMakerAPI
{
    [Get("/all?access_token={token}")]
    Task<string> GetDevices(string token);
}
