using AprendendoAPI.Data.Collections;
using AprendendoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace AprendendoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CuradoController: ControllerBase
    {
         Data.MongoDB _mongoDB;
        IMongoCollection<Curado> _curadosCollection;

        public CuradoController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _curadosCollection = _mongoDB.DB.GetCollection<Curado>(typeof(Curado).Name.ToLower());
        }

        [HttpPost]
        public ActionResult SalvarInfectado([FromBody] CuradoDto dto)
        {
            var curado = new Curado(dto.Nome,dto.Cpf ,dto.DataNascimento, dto.DataCura,  dto.Sexo, dto.Latitude, dto.Longitude);

            _curadosCollection.InsertOne(curado);
            
            return StatusCode(201, "Infectado adicionado com sucesso");
        }

        [HttpGet]
        public ActionResult ObterInfectados()
        {
            var curados = _curadosCollection.Find(Builders<Curado>.Filter.Empty).ToList();
            
            return Ok(curados);
        }
           [HttpPut]

        public ActionResult AtualizarInfectado([FromBody] CuradoDto dto)
        {
            _curadosCollection.UpdateOne(Builders<Curado>.Filter.Where(_ => _.Cpf == dto.Cpf), Builders<Curado>.Update.Set("nome", dto.Nome));

            return Ok("Nome atualizado com sucesso!");

        }
        [HttpDelete("{cpf}")]

        public ActionResult Delete(string cpf)
        {
            _curadosCollection.DeleteOne(Builders<Curado>.Filter.Where(_ => _.Cpf == cpf));
            
            return Ok("Excluido com sucesso!!");


        }

    
    }
}