using CoreStudentWebAPI.DataAccessLayer.ModelDtos;
using CoreStudentWebAPI.DataAccessLayer.Models;

namespace CoreStudentWebAPI.HttpClient
{
    public interface IHttpClientService
    {
        IList<Candidate> GetList();
        Candidate GetById(int id);
        int Post(CandidateDto candidateDto);
        int Put(int id, CandidateDto candidate);
        int Delete(int id);
    }
}
