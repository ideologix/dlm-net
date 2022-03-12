namespace DLM_NET.Models
{
    public class License
    {
        const int STATUS_SOLD = 1;
        const int STATUS_DELIVERED = 2;
        const int STATUS_ACTIVE = 3;
        const int STATUS_INACTIVE = 4;
        const int STATUS_DISABLED = 5;
        public int id { get; set; }
        public int order_id { get; set; }
        public int product_id { get; set; }
        public int user_id { get; set; }
        public String? license_key { get; set; }
        public String? expires_at { get; set; }
        public int valid_for { get; set; }
        public int source { get; set; }
        public int status { get; set; }
        public int times_activated { get; set; }
        public int activations_limit { get; set; }
        public String? created_at { get; set; }
        public String? updated_at { get; set; }
        public List<Activation>? activations { get; set; }

        public bool IsExpired()
        {
            DateTime ExpiresAt = DateTime.Parse(this.expires_at);
            return ExpiresAt <= DateTime.Now;
        }
    }
}
