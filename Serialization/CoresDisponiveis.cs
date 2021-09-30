using System.ComponentModel.DataAnnotations;


namespace ConsoleApp2.Serialization
{
    public class CoresDisponiveis
    {
        [Key]
        public string hexValue { get; set; }
        public string nomeCor { get; set; }

    }
}
