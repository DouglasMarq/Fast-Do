using SQLite;
using System;

namespace Fast_Do.Models
{
    [Table ("Item")]
    public class Item
    {
        [PrimaryKey]
        public int Id { get; set; }

        public string Text { get; set; }

        public string Description { get; set; }

        public string Date { get; set; }
    }
}