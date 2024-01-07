namespace ProjectRPS.Hubs.Models;

public class Message
{
    public string Type { get; set; }
    public object Data { get; set; }
}