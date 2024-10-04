using System;
using System.Collections.Generic;

namespace ConnectAppAPI.DataAccess.Models;

public partial class Media
{
    public int MdId { get; set; }

    public string Url { get; set; } = null!;

    public double Size { get; set; }

    public byte[] UploadTime { get; set; } = null!;

    public string? AuthorIdFk { get; set; }

    public virtual AspNetUser? AuthorIdFkNavigation { get; set; }

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
}
