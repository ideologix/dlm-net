using System.Text.Json;

using DLM_NET.Http;
using DLM_NET.Http.Responses;
using DLM_NET.Models;

namespace DLM_NET.Apis
{
    public class Licenses : Base
    {
        public Licenses(Client client) : base(client) { }

        public Result<License> Find(String licenseKey)
        {
            String contents = this.client.RequestGet("licenses/" + licenseKey).Result;

            return JsonSerializer.Deserialize<Result<License>>(contents);
        }
        
        public Result<Activation> Activate(String licenseKey)
        {
            String contents = this.client.RequestGet("licenses/activate/" + licenseKey).Result;
            return JsonSerializer.Deserialize<Result<Activation>>(contents);
        }

        public Result<Activation> Activate(String licenseKey, int softwareId)
        {
            string softwareIdStr = string.Format("?software={0}", softwareId.ToString());
            String contents = this.client.RequestGet("licenses/activate/" + licenseKey + softwareIdStr).Result;
            return JsonSerializer.Deserialize<Result<Activation>>(contents);
        }

        public Result<Activation> Validate(String token)
        {
            String contents = this.client.RequestGet("licenses/validate/" + token).Result;
            return JsonSerializer.Deserialize<Result<Activation>>(contents);
        }

        public Result<Activation> Deactivate(String token)
        {
            String contents = this.client.RequestGet("licenses/deactivate/" + token).Result;
            return JsonSerializer.Deserialize<Result<Activation>>(contents);
        }
    }
}
