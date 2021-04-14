using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.IMDB
{
    public class Name
    {
        [Column("id")]
        public string Id { get; set; }
        [Column("name")]
        public string FullName { get; set; }
        [Column("birth_year")]
        public int BirthYear { get; set; }
        [Column("death_year")]
        public int DeathYear { get; set; }
        [Column("professions")]
        public List<string> Professions { get; set; }
        [Column("title_ids")]
        public List<string> TitleIds { get; set; }
    }
}
