namespace OrbisSoftwarePolskaTask.Models;

public class GetOrder
{
    public GetOrder(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}