using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OrbisSoftwarePolskaTask.Models
{
    public class BaselinkerOrderTask1
    {
        [JsonPropertyName("order_id")]
        public int OrderId { get; set; }
        [JsonPropertyName("admin_comments")]
        [MaxLength(200)]
        public string? AdminComments { get; set; }
        [JsonPropertyName("extra_field_1")]
        [MaxLength(50)]
        public string? ExtraField1 { get; set; }
        [JsonPropertyName("extra_field_2")]
        [MaxLength(50)]
        public string? ExtraField2 { get; set; }

        public BaselinkerOrderTask1(int orderId, string adminComments, string extraField1, string extraField2)
        {
            OrderId = orderId;
            AdminComments = adminComments;
            ExtraField1 = extraField1;
            ExtraField2 = extraField2;
        }
    }
}