using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace db.v1.context.main.Entities.Users
{
    [Table("users")]
    public sealed class UserEntity
    {
        [Key]
        [Column("id")]
        public int ID { get; set; }

        [Required]
        [Column("role_id")]
        public int RoleID { get; set; }

        [Column("family_status_id")]
        public int? FamilyStatusID { get; set; }

        [Column("city_id")]
        public int? CityID { get; set; }

        [Required]
        [Column("email")]
        public string Email { get; set; }

        [Required]
        [Column("password")]
        public string Password { get; set; }

        [Column("refresh_token")]
        public string? Token { get; set; }

        [Column("token_create_date")]
        public decimal? CreateDate { get; set; }

        [Column("token_expire_date")]
        public decimal? ExpireDate { get; set; }

        [Required]
        [Column("reg_date")]
        public decimal RegDate { get; set; }

        [Column("profile_url")]
        public string? ProfileURL { get; set; }

        [Required]
        [Column("surname")]
        public string Surname { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Column("avatar")]
        public string? Avatar { get; set; }

        [Column("status")]
        public string? Status { get; set; }

        [Column("birthdate")]
        public decimal? BirthDate { get; set; }

        [Column("profile_is_private")]
        public bool ProfileIsPrivate { get; set; }

        [Column("friends_can_create_notes")]
        public bool FriendsCanCreateNotes { get; set; } = true;

        [Column("friends_can_comment_notes")]
        public bool FriendsCanCommentNotes { get; set; } = true;

        [Column("not_friends_can_write_msg")]
        public bool NotFriendsCanWriteMsg { get; set; } = true;

        public UserEntity(int id, string token, decimal token_create_date, decimal token_expire_date)
        {
            ID = id;
            Token = token;
            CreateDate = token_create_date;
            ExpireDate = token_expire_date;
        }

        public UserEntity(int role_id, string email, string password, decimal reg_date, string surname, string name, string profile_url)
        {
            RoleID = role_id;
            Email = email;
            Password = password;
            RegDate = reg_date;
            Surname = surname;
            Name = name;
            ProfileURL = profile_url;
        }

        public UserEntity(int id, int role_id, string email, string password, decimal reg_date, string surname, string name)
        {
            ID = id;
            RoleID = role_id;
            Email = email;
            Password = password;
            RegDate = reg_date;
            Surname = surname;
            Name = name;
        }

        public UserEntity() { }
    }
}