using System.Diagnostics.CodeAnalysis;

namespace chatapi.Models
{
    public class Message {
        public int Id { get; set; }
        
        [MinLengthValidator]
        public string Content { get; set; }
        public DateTime CreatedAt {get; set;}

        public int FromUserId { get; set;}
        public int ToUserId { get; set; }

        public User? FromUser { get; set; }

        public User? ToUser { get; set; }
       
    }
}