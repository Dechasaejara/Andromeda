namespace API.Models.TourAddis;
// Tour.cs
public class Tour
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal Price { get; set; }
    public string? Location { get; set; }
}

// TourBooking.cs
public class TourBooking
{
    public int Id { get; set; }
    public int TourId { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public DateTime BookingDate { get; set; }
    public int NumberOfPeople { get; set; }
}

// TourReview.cs
public class TourReview
{
    public int Id { get; set; }
    public int TourId { get; set; }
    public string? ReviewerName { get; set; }
    public string? Comment { get; set; }
    public int Rating { get; set; }
    public DateTime ReviewDate { get; set; }
}
