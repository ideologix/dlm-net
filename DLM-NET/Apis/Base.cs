using DLM_NET.Http;

namespace DLM_NET.Apis
{
    public class Base
    {

        protected Client client;

        public Base(Client client)
        {
            this.client = client;
        }

        public Client GetClient()
        {
            return this.client;
        }

    }
}
