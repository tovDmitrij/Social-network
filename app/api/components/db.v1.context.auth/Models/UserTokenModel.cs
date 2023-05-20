using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace db.v1.context.auth.Models
{
    /// <summary>
    /// Информация в refresh-токене пользователя
    /// </summary>
    public sealed class UserTokenModel
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        [Key]
        [Column("user_id")]
        public int UserID { get; set; }

        /// <summary>
        /// Refresh-токен
        /// </summary>
        [Required]
        [Column("refresh_token")]
        public string RefreshToken { get; set; }

        /// <summary>
        /// Дата создания токена
        /// </summary>
        [Required]
        [Column("create_date")]
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Дата просрочки токена
        /// </summary>
        [Required]
        [Column("expire_date")]
        public DateTime ExpireDate { get; set; }

        /// <summary>
        /// Информация в refresh-токене пользователя
        /// </summary>
        /// <param name="user_id">Идентификатор пользователя</param>
        /// <param name="refresh_token">Refresh-токен</param>
        /// <param name="create_date">Дата создания токена</param>
        /// <param name="expire_date">Дата просрочки токена</param>
        public UserTokenModel(int user_id, string refresh_token, DateTime create_date, DateTime expire_date)
        {
            UserID = user_id;
            RefreshToken = refresh_token;
            CreateDate = create_date;
            ExpireDate = expire_date;
        }

        /// <summary>
        /// Информация в refresh-токене пользователя
        /// </summary>
        public UserTokenModel() { }
    }
}
