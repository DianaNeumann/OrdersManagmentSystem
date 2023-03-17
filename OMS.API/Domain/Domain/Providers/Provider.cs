namespace Domain.Providers;

public class Provider
{
    public Provider()
    {
    }
    public Provider(string name)
    {
        Name = name;
    }

    public int Id { get; set; }
    public string Name { get; set; }
}