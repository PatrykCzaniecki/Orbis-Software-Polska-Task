using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OrbisSoftwarePolskaTask.Models
{
    public class BaselinkerOrderTask2
    {
        public int OrderId { get; set; }
        [JsonPropertyName("custom_extra_fields")]
        [MaxLength(50)]
        public string CustomExtraFields { get; set; }

        public BaselinkerOrderTask2(int orderId, string customExtraFields)
        {
            OrderId = orderId;
            CustomExtraFields = customExtraFields;
        }
    }
}