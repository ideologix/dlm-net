namespace DLM_NET.Models
{
    public class Activation
    {
        const int SOURCE_WEB = 1;
        const int SOURCE_API = 2;
        public int id { get; set; }
        public String? token { get; set; }
        public int license_id { get; set; }
        public dynamic status { get; set; }
        public String? label { get; set; }
        public int source { get; set; }
        public String? ip_address { get; set; }
        public String? user_agent { get; set; }
        public List<KeyValuePair<string, dynamic>>? meta_data { get; set; }
        public License? license { get; set; }
        public String? created_at { get; set; }
        public String? updated_at { get; set; }
        public String? deactivated_at { get; set; }

        public bool isActive()
        {
            return String.IsNullOrEmpty(this.deactivated_at);
        }
    }
}
