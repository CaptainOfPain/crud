namespace CRUD.Web.Requests;

public class ItemRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime? ExpirationDate { get; set; }
}