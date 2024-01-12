using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniStore.Core.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(prop => prop.Title).IsRequired().HasMaxLength(50); 
            builder.Property(prop => prop.PostDate).IsRequired().HasMaxLength(20); 
            builder.Property(prop => prop.Category).IsRequired().HasMaxLength(20); 
            builder.Property(prop => prop.ImgUrl).IsRequired().HasMaxLength(100); 
        }
    }
}
