using AprendendoAPI.Data.Collections;
using AprendendoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace AprendendoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfectadoController : ControllerBase
    {
        Data.MongoDB _mongoDB;
        IMongoCollection<Infectado> _infectadosCollection;

        public InfectadoController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _infectadosCollection = _mongoDB.DB.GetCollection<Infectado>(typeof(Infectado).Name.ToLower());
        }

        [HttpPost]
        public ActionResult SalvarInfectado([FromBody] InfectadoDto dto)
        {
            var infectado = new Infectado(dto.Nome, dto.Cpf,  dto.DataNascimento, dto.Sexo, dto.Latitude, dto.Longitude);

            _infectadosCollection.InsertOne(infectado);
            
            return StatusCode(201, "Recuperado adicionado com sucesso");
        }

        [HttpGet]
        public ActionResult ObterInfectados()
        {
            var infectados = _infectadosCollection.Find(Builders<Infectado>.Filter.Empty).ToList();
            
            return Ok(infectados);
        }

        [HttpPut]

        public ActionResult AtualizarInfectado([FromBody] InfectadoDto dto)
        {
            _infectadosCollection.UpdateOne(Builders<Infectado>.Filter.Where(_ => _.Cpf == dto.Cpf), Builders<Infectado>.Update.Set("nome", dto.Nome));

            return Ok("Nome atualizado com sucesso!");

        }
        [HttpDelete("{cpf}")]

        public ActionResult Delete(string cpf)
        {
            _infectadosCollection.DeleteOne(Builders<Infectado>.Filter.Where(_ => _.Cpf == cpf));
            
            return Ok("Excluido com sucesso!!");


        }
    }
}