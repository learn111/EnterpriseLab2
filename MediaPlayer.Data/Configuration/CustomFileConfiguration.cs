using System.Data.Entity.ModelConfiguration;
using MediaPlayer.Data.Entities;

namespace MediaPlayer.Data.Configuration
{
    internal class CustomFileConfiguration : EntityTypeConfiguration<CustomFile>
    {
        public CustomFileConfiguration()
        {
            HasOptional(f => f.Track)
                .WithRequired(t => t.CustomFile);
        }
    }
}