namespace PoopHub.Models;

public class User
{
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public long Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email {
        get;
        set;
    }

    public int Role { get; set; }

    public User()
    {

    }



}