namespace LibrarySystem.Dtos
{
    public class UserBorrowRequestDto
    {
        public int BookId { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string UserEmail { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
