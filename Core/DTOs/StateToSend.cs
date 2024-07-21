namespace ProjectRPS.Core.DTOs;

public class StateToSend
{
    public EntityDTO[] Entities { get; set; }
    public int MessageNumber { get; set; } = 0;
}