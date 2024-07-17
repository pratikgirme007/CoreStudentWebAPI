using CoreStudentWebAPI.DataAccessLayer.ModelDtos;
using CoreStudentWebAPI.DataAccessLayer.Models;
using CoreStudentWebAPI.HttpClient;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreStudentWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        public readonly IHttpClientService _httpClientService;
        public CandidateController(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }
        // GET: api/<CandidateController>
        [HttpGet]
        public IEnumerable<Candidate> Get()
        {
            return _httpClientService.GetList();
        }

        // GET api/<CandidateController>/5
        [HttpGet("{id}")]
        public Candidate Get(int id)
        {
            return _httpClientService.GetById(id);
        }

        // POST api/<CandidateController>
        [HttpPost]
        public void Post([FromBody] CandidateDto candidateDto)
        {
            _httpClientService.Post(candidateDto);
        }

        // PUT api/<CandidateController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CandidateDto candidate)
        {
            _httpClientService.Put(id, candidate);
        }

        // DELETE api/<CandidateController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _httpClientService.Delete(id);
        }
    }
}
