﻿using System.ComponentModel.DataAnnotations.Schema;

namespace db.v1.context.main.Entities.Dictionary
{
    [Table("app_user_roles")]
    public sealed class AppUserRoleEntity : BaseDictionaryEntity
    {
        public AppUserRoleEntity(Guid id, string name, string tag)
        {
            UUID = id;
            Name = name;
            Tag = tag;
        }

        public AppUserRoleEntity() { }
    }
}