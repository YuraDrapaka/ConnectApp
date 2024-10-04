using System;
using System.Collections.Generic;

namespace ConnectAppAPI.DataAccess.Models;

public partial class AspNetUser
{
    public string Id { get; set; } = null!;

    public int AccessFailedCount { get; set; }

    public string? ConcurrencyStamp { get; set; }

    public string? Email { get; set; }

    public bool EmailConfirmed { get; set; }

    public bool LockoutEnabled { get; set; }

    public DateTimeOffset? LockoutEnd { get; set; }

    public string? NormalizedEmail { get; set; }

    public string? NormalizedUserName { get; set; }

    public string? PasswordHash { get; set; }

    public string? PhoneNumber { get; set; }

    public bool PhoneNumberConfirmed { get; set; }

    public string? SecurityStamp { get; set; }

    public bool TwoFactorEnabled { get; set; }

    public string? UserName { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string? UserTag { get; set; }

    public string? Description { get; set; }

    public DateOnly? Birthday { get; set; }

    public int? IconFk { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; } = new List<AspNetUserClaim>();

    public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; } = new List<AspNetUserLogin>();

    public virtual ICollection<AspNetUserToken> AspNetUserTokens { get; set; } = new List<AspNetUserToken>();

    public virtual ICollection<Media> Media { get; set; } = new List<Media>();

    public virtual ICollection<Message> MessageFromUserIdFkNavigations { get; set; } = new List<Message>();

    public virtual ICollection<Message> MessageToUserIdFkNavigations { get; set; } = new List<Message>();

    public virtual ICollection<UsersChatsRelation> UsersChatsRelations { get; set; } = new List<UsersChatsRelation>();

    public virtual ICollection<UsersContactsRelation> UsersContactsRelationContactFkNavigations { get; set; } = new List<UsersContactsRelation>();

    public virtual ICollection<UsersContactsRelation> UsersContactsRelationUserIdFkNavigations { get; set; } = new List<UsersContactsRelation>();

    public virtual ICollection<AspNetRole> Roles { get; set; } = new List<AspNetRole>();
}
