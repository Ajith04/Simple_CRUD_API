﻿using Microsoft.EntityFrameworkCore;

namespace DotNetCRUD.Database
{
    public class ABCDbContext : DbContext
    {
        public ABCDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
