using System;
namespace AprendendoAPI.Models
{
    public class CuradoDto
    {
         public string Nome { get; set; }
         public string Cpf { get; set; }

         public DateTime DataNascimento { get; set; }
         public DateTime DataCura { get; set; }

         public string Sexo { get; set; }

         public double Latitude { get; set; }
         public double Longitude { get; set; }
        
    }
}