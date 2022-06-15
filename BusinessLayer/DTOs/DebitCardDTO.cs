namespace Safe_Development.BusinessLayer.DTOs
{
    public class DebitCardDTO
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public int DueMonth { get; set; }
        public int DueYear { get; set; }
        public decimal Balance { get; set; }
        public bool IsActive { get; set; }
    }
}
