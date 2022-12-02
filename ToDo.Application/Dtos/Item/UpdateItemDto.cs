namespace ToDo.Application.Dtos.Item;

public class UpdateItemDto
{
    public Guid Id { get; set; }
    public bool Done { get; set; }

}