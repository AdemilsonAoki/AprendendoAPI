using System;
using MongoDB.Driver.GeoJsonObjectModel;

namespace AprendendoAPI.Data.Collections
{
    public class Curado
    {
           public Curado(string nome, string cpf, DateTime dataNascimento, DateTime dataCura ,string sexo, double latitude, double longitude)
        {
            this.Nome = nome;
            this.Cpf = cpf;
            this.DataCura = dataCura;
            this.DataNascimento = dataNascimento;
            this.Sexo = sexo;
            this.Localizacao = new GeoJson2DGeographicCoordinates(longitude, latitude);
        }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCura { get; set; }

        public string Sexo { get; set; }
        public GeoJson2DGeographicCoordinates Localizacao { get; set; }
    }
}