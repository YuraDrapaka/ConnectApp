using System;
using System.Collections.Generic;

namespace ConnectAppAPI.DataAccess.Models;

public partial class Chat
{
    public int ChatId { get; set; }

    public string? Description { get; set; }

    public DateTime CreationTime { get; set; }

    public string? Icon { get; set; }

    public bool IsChannel { get; set; }

    public virtual ICollection<UsersChatsRelation> UsersChatsRelations { get; set; } = new List<UsersChatsRelation>();

    public virtual ICollection<Message> MessageIdFks { get; set; } = new List<Message>();
}
