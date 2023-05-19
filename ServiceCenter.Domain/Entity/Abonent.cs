using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceCenter.Domain.Entity
{
    public class Abonent
    {
        public uint Abonent_ID { get; set; }
        public string Contract_number { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime Birthday { get; set; }
        public string Adress { get; set; }
        public string Passport { get; set; }

        public uint Tariff_ID { get; set; }
        [ForeignKey("Tariff_ID")]
        public virtual Tariff Tariff { get; set; }
    }
}
