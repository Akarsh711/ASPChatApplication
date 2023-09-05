namespace ASPWebApplication.Models
{
    public class Friends
    {
        public int Id { get; set; }
        public int PersonOneId { get; set; }
        public int PersonTwoId { get; set; }
        public Contact? PersonOneObj { get; set; }
        public Contact? PersonTwoObj { get; set; }
    }
}
