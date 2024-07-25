namespace chatapi.Models
{
    public class Message {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt {get; set;}

        public int From { get; set;}
        public int To { get; set; }

         public User FromUser { get; set; }
        public User ToUser { get; set; }
       
    }
}