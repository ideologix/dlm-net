using DLM_NET.Http;
using DLM_NET.Apis;

namespace DLM_NET
{
    public class Service
    {

        private Licenses LicensesManager;

        public Service(String apiBase, String consumer_key, String consumer_secret)
        {
            Client client = new Client(apiBase, consumer_key, consumer_secret);
            this.LicensesManager = new Licenses(client);
        }

        public Licenses Licenses()
        {
            return this.LicensesManager;
        }

    }
}