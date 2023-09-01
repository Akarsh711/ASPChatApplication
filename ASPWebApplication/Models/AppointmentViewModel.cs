using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPWebApplication.Models
{
    public class AppointmentViewModel
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(150), Column(TypeName = "nvarchar(150)")]
        public required string Title { get; set; } = "Title";

        [MaxLength(300), Column(TypeName = "nvarchar(300)")]
        public string Description { get; set; } = "Description";

        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        public DateTime Date { get; set; } = DateTime.Now;

        [MaxLength(100), Column(TypeName = "nvarchar(100")]
        public string Address { get; set; } = "Address";

        [MaxLength(10), Column(TypeName = "nvarchar(10")]
        public string Time { get; set; } = "12:30";

        public bool Done { get; set; } = false;
        public bool Deleted { get; set; } = false;

        //byte because byte take less memory
        // And one more thing it is always good in prod to specify
        // the lenght of char as it saves space in DB.
        public int LevelOfImportance { get; set; } = 2;


    }
}
