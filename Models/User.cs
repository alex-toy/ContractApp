namespace Apollo.Models;

public class User {
    public int Id { get; set; }


    public string Name { get; set; }
    public string surname { get; set; }
    public DateOnly BirthDate { get; set; }

    public User(int id, string name, string surname, DateOnly birthDate)
    {
        Id = id;
        Name = name;
        this.surname = surname;
        BirthDate = birthDate;
    }
}