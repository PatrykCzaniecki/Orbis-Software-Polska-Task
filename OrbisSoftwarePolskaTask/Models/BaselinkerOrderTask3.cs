using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OrbisSoftwarePolskaTask.Models
{
    public class BaselinkerOrderTask3
    {
        [JsonPropertyName("invoice_id")]
        public int InvoiceId { get; set; }
        [JsonPropertyName("file")]
        public string? File { get; set; }
        [JsonPropertyName("external_invoice_number")]
        [MaxLength(30)]
        public string? ExternalInvoiceNumber { get; set; }

        public BaselinkerOrderTask3(int invoiceId, string file, string externalInvoiceNumber)
        {
            InvoiceId = invoiceId;
            File = file;
            ExternalInvoiceNumber = externalInvoiceNumber;
        }
    }
}
