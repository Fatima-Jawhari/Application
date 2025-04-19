using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp1.Core.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(2000)]  // Recommended to add length constraint
        public  required string Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey(nameof(Post))]
        public int PostId { get; set; }

        [Required]
        public  required Post Post { get; set; }

        [ForeignKey(nameof(User))]

        [Required]
        public  required string UserId { get; set; }

        [Required]
        public required ApplicationUser User { get; set; }
    }
}
