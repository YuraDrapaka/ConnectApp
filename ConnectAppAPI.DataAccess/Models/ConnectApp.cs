using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ConnectAppAPI.DataAccess.Models;

public partial class ConnectApp : DbContext
{
    public ConnectApp()
    {
    }

    public ConnectApp(DbContextOptions<ConnectApp> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Chat> Chats { get; set; }

    public virtual DbSet<Media> Medias { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<UsersChatsRelation> UsersChatsRelations { get; set; }

    public virtual DbSet<UsersContactsRelation> UsersContactsRelations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=DESKTOP-F74BI62;initial catalog=ConnectAppDB;Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.Property(e => e.RoleId).HasMaxLength(450);

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("First Name");
            entity.Property(e => e.IconFk).HasColumnName("Icon_FK");
            entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted?");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Last Name");
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);
            entity.Property(e => e.UserTag)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRoles");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.Property(e => e.UserId).HasMaxLength(450);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.Property(e => e.UserId).HasMaxLength(450);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Chat>(entity =>
        {
            entity.Property(e => e.ChatId).HasColumnName("Chat_Id");
            entity.Property(e => e.CreationTime)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("Creation_Time");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Icon)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IsChannel).HasColumnName("IsChannel?");

            entity.HasMany(d => d.MessageIdFks).WithMany(p => p.ChatIdFks)
                .UsingEntity<Dictionary<string, object>>(
                    "ChatsMessagesRelation",
                    r => r.HasOne<Message>().WithMany()
                        .HasForeignKey("MessageIdFk")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Chats_Messages_MessageID"),
                    l => l.HasOne<Chat>().WithMany()
                        .HasForeignKey("ChatIdFk")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_Chats_Messages_ChatID"),
                    j =>
                    {
                        j.HasKey("ChatIdFk", "MessageIdFk").HasName("PK_ChatID_MessageID");
                        j.ToTable("Chats_Messages_RELATION");
                        j.IndexerProperty<int>("ChatIdFk").HasColumnName("ChatID_FK");
                        j.IndexerProperty<int>("MessageIdFk").HasColumnName("MessageID_FK");
                    });
        });

        modelBuilder.Entity<Media>(entity =>
        {
            entity.HasKey(e => e.MdId);

            entity.Property(e => e.MdId).HasColumnName("Md_Id");
            entity.Property(e => e.AuthorIdFk)
                .HasMaxLength(450)
                .HasColumnName("AuthorId_FK");
            entity.Property(e => e.UploadTime)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Url)
                .HasColumnType("text")
                .HasColumnName("URL");

            entity.HasOne(d => d.AuthorIdFkNavigation).WithMany(p => p.Media)
                .HasForeignKey(d => d.AuthorIdFk)
                .HasConstraintName("FK_Medias_Author");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.MsId);

            entity.Property(e => e.MsId).HasColumnName("Ms_Id");
            entity.Property(e => e.FromUserIdFk)
                .HasMaxLength(450)
                .HasColumnName("From_UserID_FK");
            entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted?");
            entity.Property(e => e.IsEdited).HasColumnName("IsEdited?");
            entity.Property(e => e.IsForwarded).HasColumnName("IsForwarded?");
            entity.Property(e => e.IsViewed).HasColumnName("IsViewed?");
            entity.Property(e => e.MediaIdFk).HasColumnName("MediaID_FK");
            entity.Property(e => e.OldMessageIdFk).HasColumnName("OldMessageID_FK");
            entity.Property(e => e.Text).HasColumnType("text");
            entity.Property(e => e.Time)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.ToUserIdFk)
                .HasMaxLength(450)
                .HasColumnName("To_UserID_FK");

            entity.HasOne(d => d.FromUserIdFkNavigation).WithMany(p => p.MessageFromUserIdFkNavigations)
                .HasForeignKey(d => d.FromUserIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Messages_FromUserID");

            entity.HasOne(d => d.MediaIdFkNavigation).WithMany(p => p.Messages)
                .HasForeignKey(d => d.MediaIdFk)
                .HasConstraintName("FK_Messages_Media");

            entity.HasOne(d => d.OldMessageIdFkNavigation).WithMany(p => p.InverseOldMessageIdFkNavigation)
                .HasForeignKey(d => d.OldMessageIdFk)
                .HasConstraintName("FK_Messages_OldMessageID");

            entity.HasOne(d => d.ToUserIdFkNavigation).WithMany(p => p.MessageToUserIdFkNavigations)
                .HasForeignKey(d => d.ToUserIdFk)
                .HasConstraintName("FK_Messages_ToUserID");
        });

        modelBuilder.Entity<UsersChatsRelation>(entity =>
        {
            entity.HasKey(e => e.UsersChatsRelationId).HasName("PK_UserID_ChatID_REL");

            entity.ToTable("Users_Chats_RELATION");

            entity.Property(e => e.UsersChatsRelationId).HasColumnName("Users_Chats_Relation_ID");
            entity.Property(e => e.ChatIdFk).HasColumnName("ChatID_FK");
            entity.Property(e => e.UserIdFk)
                .HasMaxLength(450)
                .HasColumnName("UserID_FK");

            entity.HasOne(d => d.ChatIdFkNavigation).WithMany(p => p.UsersChatsRelations)
                .HasForeignKey(d => d.ChatIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Chats_ChatID");

            entity.HasOne(d => d.UserIdFkNavigation).WithMany(p => p.UsersChatsRelations)
                .HasForeignKey(d => d.UserIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Chats_UserID");
        });

        modelBuilder.Entity<UsersContactsRelation>(entity =>
        {
            entity.HasKey(e => e.UserCountactRelationId);

            entity.ToTable("Users_Contacts_RELATION");

            entity.Property(e => e.UserCountactRelationId).HasColumnName("User_Countact_relationID");
            entity.Property(e => e.ContactFk)
                .HasMaxLength(450)
                .HasColumnName("Contact_FK");
            entity.Property(e => e.UserIdFk)
                .HasMaxLength(450)
                .HasColumnName("UserID_FK");

            entity.HasOne(d => d.ContactFkNavigation).WithMany(p => p.UsersContactsRelationContactFkNavigations)
                .HasForeignKey(d => d.ContactFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserID_Contacts-Contact");

            entity.HasOne(d => d.UserIdFkNavigation).WithMany(p => p.UsersContactsRelationUserIdFkNavigations)
                .HasForeignKey(d => d.UserIdFk)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserID_Contacts-UserID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
