using System;
using System.Collections.Generic;

namespace ConnectAppAPI.DataAccess.Models;

public partial class Message
{
    public int MsId { get; set; }

    public DateTime Time { get; set; }

    public string Text { get; set; } = null!;

    public string FromUserIdFk { get; set; } = null!;

    public string? ToUserIdFk { get; set; }

    public int? MediaIdFk { get; set; }

    public bool IsEdited { get; set; }

    public bool IsViewed { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsForwarded { get; set; }

    public int? OldMessageIdFk { get; set; }

    public virtual AspNetUser FromUserIdFkNavigation { get; set; } = null!;

    public virtual ICollection<Message> InverseOldMessageIdFkNavigation { get; set; } = new List<Message>();

    public virtual Media? MediaIdFkNavigation { get; set; }

    public virtual Message? OldMessageIdFkNavigation { get; set; }

    public virtual AspNetUser? ToUserIdFkNavigation { get; set; }

    public virtual ICollection<Chat> ChatIdFks { get; set; } = new List<Chat>();
}
