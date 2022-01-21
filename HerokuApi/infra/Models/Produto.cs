using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HerokuApi.infra.Models
{
    [Table("produto")]
    public class Produto
    {
        [System.Text.Json.Serialization.JsonIgnore]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        [Column("createdat")]
        public DateTime CreatedAt { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        [Column("updatedat")]
        public DateTime UpdatedAt { get; set; }
    }
}
