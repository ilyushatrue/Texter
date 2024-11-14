using Texter.Domain.Models.Base;

namespace Texter.Domain.Models;

public class Message : BaseEntity   {
    public string Text { get; set; } = null!;
    public int ChatId { get; set; }
    public int SenderId { get; set; }   
    public int ReceiverId { get; set; }

    public User? Receiver { get; set; }
    public User? Sender { get; set; }
    public Chat? Chat { get; set; }
}