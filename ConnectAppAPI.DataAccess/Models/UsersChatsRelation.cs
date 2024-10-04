using System;
using System.Collections.Generic;

namespace ConnectAppAPI.DataAccess.Models;

public partial class UsersChatsRelation
{
    public int UsersChatsRelationId { get; set; }

    public string UserIdFk { get; set; } = null!;

    public int ChatIdFk { get; set; }

    public virtual Chat ChatIdFkNavigation { get; set; } = null!;

    public virtual AspNetUser UserIdFkNavigation { get; set; } = null!;
}
