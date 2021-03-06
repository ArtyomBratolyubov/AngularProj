﻿using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.IO;
using System.Threading;

namespace ORM
{


    public partial class EntityModel : DbContext
    {
        public EntityModel()
            : base("name=DataContext")
        {

        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<CommentSong> CommentsSong { get; set; }
        public virtual DbSet<RateSong> RateSongs { get; set; }
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Image> Songs { get; set; }
        public virtual DbSet<File> Files { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }

}


