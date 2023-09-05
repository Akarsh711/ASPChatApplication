namespace ASPWebApplication.Models
{
    public class ChatRoom
    {
        
        public int Id { get; set; }
        public int ContactId { get; set; }
        public int MessageId { get; set; }
        public Contact? ContactObj { get; set; } // MtoM
        public Message? MessageObj { get; set; } // MtoM
    }
   
}
