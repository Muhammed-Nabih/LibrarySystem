namespace LibrarySystem.Models
{
    public class BorrowRequest
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string UserEmail { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Status { get; set; }
    }
}
