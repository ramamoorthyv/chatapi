namespace chatapi.Models
{
    public class User {
        public int Id { get; set; }

        [UniqueEmail]
        [ValidEmail]
        public string Email { get; set; }
        public string Password { get; set; }

        [MinLengthValidator]
        public string Firstname { get; set; }

        [MinLengthValidator]
        public string Lastname { get; set; }

        public ICollection<Message>? SentMessages { get; set; }
        public ICollection<Message>? ReceivedMessages { get; set; }
    }
}