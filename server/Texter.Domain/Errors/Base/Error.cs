namespace Texter.Domain.Errors.Base;

public class Error
{
    public Error(string name, string description)
    {
        Name = name;
        Description = description;
    }
    public string Name { get; set; }
    public string Description { get; set; }

    public override string ToString() => $"Error Name: {Name}, Description: {Description}";

}