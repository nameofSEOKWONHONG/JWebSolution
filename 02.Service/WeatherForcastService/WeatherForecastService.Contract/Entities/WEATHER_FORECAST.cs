using System;
using System.ComponentModel.DataAnnotations.Schema;
using JServiceStack.Entity;

namespace Entity
{
    [Table("WEATHER_FORECAST")]
    public class WEATHER_FORECAST : ENTITY_BASE
    {
        public DateTime DATE { get; set; }

        public int TEMP_C { get; set; }

        [NotMapped]
        public int TEMP_F => 32 + (int) (TEMP_C / 0.5556);

        public string SUMMARY { get; set; }
    }
}