
namespace TestBlazorWASM.Shared;
public class NotificationMessage:BaseEntity
{
    public Guid Sender { get ; set; }
    public string Message { get; set; }
    public List<Guid> recievers { get; set; }
    public DateTime createdOn { get; set; }


}
