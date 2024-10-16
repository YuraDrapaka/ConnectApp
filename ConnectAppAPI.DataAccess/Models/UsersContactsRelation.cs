using System;
using System.Collections.Generic;

namespace ConnectAppAPI.DataAccess.Models;

public partial class UsersContactsRelation
{
    public string UserCountactRelationId { get; set; } = null!;

    public string UserIdFk { get; set; } = null!;

    public string ContactFk { get; set; } = null!;

    public virtual AspNetUser ContactFkNavigation { get; set; } = null!;

    public virtual AspNetUser UserIdFkNavigation { get; set; } = null!;
}
