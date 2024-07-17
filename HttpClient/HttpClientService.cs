using CoreStudentWebAPI.DataAccessLayer.ModelDtos;
using CoreStudentWebAPI.DataAccessLayer.Models;
using System.Net.Http.Json;
using http = System.Net.Http;

namespace CoreStudentWebAPI.HttpClient
{
    public class HttpClientService : IHttpClientService
    {
        public IList<Candidate> GetList()
        {
            try
            {
                using (http.HttpClient client = new http.HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5076/api/Candidate/GetCandidates");
                    var responseTask = client.GetAsync(client.BaseAddress);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadFromJsonAsync<IList<Candidate>>();
                        readTask.Wait();

                        return readTask.Result;
                    }
                    else
                    {
                        throw new Exception(result.StatusCode.ToString());
                    }
                }
            }
            catch (Exception exception)
            {
                return null;
            }
        }
        public Candidate GetById(int id)
        {
            try
            {
                using (http.HttpClient client = new http.HttpClient())
                {
                    string baseAddress = $"http://localhost:5076/api/Candidate/GetCandidate/{id}";
                    client.BaseAddress = new Uri(baseAddress);
                    var responseTask = client.GetAsync(client.BaseAddress);
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadFromJsonAsync<Candidate>();
                        readTask.Wait();

                        return readTask.Result;
                    }
                    else
                    {
                        throw new Exception(result.StatusCode.ToString());
                    }

                }
            }
            catch (Exception exception)
            {
                return null;
            }
        }
        public int Post(CandidateDto candidateDto)
        {
            try
            {
                using (http.HttpClient client = new http.HttpClient())
                {
                    string baseAddress = $"http://localhost:5076/api/Candidate/SaveCandidate";
                    client.BaseAddress = new Uri(baseAddress);
                    var responseTask = client.PostAsJsonAsync<CandidateDto>(client.BaseAddress, candidateDto);
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return 1;
                    }
                    else
                    {
                        throw new Exception(result.StatusCode.ToString());
                    }

                }
            }
            catch (Exception exception)
            {
                return 0;
            }
        }

        public int Put(int id, CandidateDto candidate)
        {
            try
            {
                using (http.HttpClient client = new http.HttpClient())
                {
                    client.BaseAddress = new Uri($"http://localhost:5076/api/Candidate/UpdateCandidate/{id}");

                    var responseTask = client.PutAsJsonAsync<CandidateDto>(client.BaseAddress, candidate);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return 1;
                    }
                    else
                    {
                        throw new Exception(result.StatusCode.ToString());
                    }
                }
            }
            catch (Exception exception)
            {
                return 0;
            }
        }

        public int Delete(int id)
        {
            try
            {
                using(http.HttpClient client = new http.HttpClient())
                {
                    client.BaseAddress = new Uri($"http://localhost:5076/api/Candidate/DeleteCandidate/{id}");
                    var responseTask = client.DeleteAsync(client.BaseAddress);
                    responseTask.Wait();

                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return 1;
                    }
                    else
                    {
                        throw new Exception(result.StatusCode.ToString());
                    }
                }
            }
            catch(Exception exception)
            {
                return 0;
            }
        }
    }
}
