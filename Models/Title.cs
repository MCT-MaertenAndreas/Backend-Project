using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.IMDB
{
    public class Title
    {
        [Column("id")]
        public string Id { get; set; }
        [Column("title_type")]
        public string TitleType { get; set; }
        [Column("title")]
        public string PrimaryTitle { get; set; }
        [Column("original_title")]
        public string OriginalTitle { get; set; }
        [Column("genres")]
        public List<string> Genres { get; set; }
        [Column("is_adult")]
        public bool IsAdult { get; set; }
        [Column("run_time")]
        public int RunTimeMinutes { get; set; }
        [Column("average_rating")]
        public float AverageRating { get; set; }
        [Column("vote_count")]
        public int VoteCount { get; set; }
        [Column("directors")]
        public List<string> Directors { get; set; }
        [Column("writers")]
        public List<string> Writers { get; set; }
    }
}
