﻿using db.v1.context.main.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace db.v1.context.main.Contexts.Main.Interfaces
{
    public interface IProfileContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public int SaveChanges();
    }
}