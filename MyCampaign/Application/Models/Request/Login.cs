using Newtonsoft.Json;

namespace Application;

public class Login
{
    [JsonProperty("username")]
    public string Username {get;set;}
    [JsonProperty("password")]
    public string Password {get;set;}
}
