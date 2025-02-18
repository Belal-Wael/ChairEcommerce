using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChairEcommerce.Models
{

    public enum Status { Pending, InProgress, Completed, Canceled }


    public class TrackingDetails
    {
        public int Id { get; set; }

        [EnumDataType(typeof(Status), ErrorMessage = "Invalid status.")]
        public string Status {  get; set; }




        [ForeignKey("Order")]
        public int OrderID { get; set; }
        public Order Order { get; set; }
    }
}
