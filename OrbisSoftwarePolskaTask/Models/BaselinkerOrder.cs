using System.ComponentModel.DataAnnotations;

namespace OrbisSoftwarePolskaTask.Models
{
    public class BaselinkerOrder
    {
        public int OrderId { get; set; }
        [MaxLength(200)] public string AdminComments { get; set; }
        [MaxLength(50)] public string ExtraField1 { get; set; }
        [MaxLength(50)] public string ExtraField2 { get; set; }
        [MaxLength(50)] public string CustomExtraFields { get; set; }
        public string File { get; set; }
        [MaxLength(30)] public string InvoiceNumber { get; set; }

        public BaselinkerOrder(int orderId, string adminComments, string extraField1, string extraField2, string customExtraFields, string file, string invoiceNumber)
        {
            OrderId = orderId;
            AdminComments = adminComments;
            ExtraField1 = extraField1;
            ExtraField2 = extraField2;
            CustomExtraFields = customExtraFields;
            File = file;
            InvoiceNumber = invoiceNumber;
        }
    }
}