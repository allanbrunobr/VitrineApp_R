
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp2.Serialization
{
    
    public class Item
    {
        [Key]
        public int id { get; set; }

        [DisplayName("Marca")]
        public string brand { get; set; }

        [DisplayName("Nome do produto")]
        public string name { get; set; }

        [DisplayName("Preço")]
        public string price { get; set; }
        public string image_link { get; set; }

        public string description { get; set; }
        public string product_type { get; set; }
        
        [DisplayName("Categoria")]
        public string category { get; set; }

        [DisplayName("Cores disponíveis")]
        public List<string> tag_list { get; set; }


        public List<CoresDisponiveis> product_colors { get; set; }
            
    }
}


