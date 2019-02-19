using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeLembretes.Models
{
    public class Lembrete
    {
        
        public int Id { get; set; }

        [Display(Name = "Titulo")]
        [Required(ErrorMessage = "Titulo não pode ser deixado em branco")]
        public string Titulo { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Data não pode ser deixado em branco")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }
    }
}
