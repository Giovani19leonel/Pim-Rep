using PIM.WebForms.Core.Integration.PIM.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace PIM.WebForms.Core.Integration.PIM
{
    public class PIMServices
    {
        private HttpClient _httpClient;

        public PIMServices()
        {
            _httpClient = new HttpClient();

            _httpClient.BaseAddress = new Uri("https://localhost:7211");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public (DefaultPIM resp, ErrorResponse respError) GetPessoa(long cpf)
        {
            try
            {
                var result = _httpClient.GetAsync($"/pim/user?cpf={cpf}").Result;
                if(result.IsSuccessStatusCode)
                {
                    string data = result.Content.ReadAsStringAsync().Result;
                    var response = JsonSerializer.Deserialize<DefaultPIM>(data, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                    return (response, null);
                }
                else
                {
                    string data = result.Content.ReadAsStringAsync().Result;
                    var response = JsonSerializer.Deserialize<ErrorResponse>(data, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                    return (null, response);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return (null,null);
        }
        public (List<DefaultPIM> resp, ErrorResponse respError) GetLstPessoa()
        {
            try
            {
                var result = _httpClient.GetAsync($"/pim/user/all").Result;
                if (result.IsSuccessStatusCode)
                {
                    string data = result.Content.ReadAsStringAsync().Result;
                    var response = JsonSerializer.Deserialize<List<DefaultPIM>>(data, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                    return (response, null);
                }
                else
                {
                    string data = result.Content.ReadAsStringAsync().Result;
                    var response = JsonSerializer.Deserialize<ErrorResponse>(data, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                    return (null, response);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return (null, null);
        }

        public (bool resp, ErrorResponse respError) IncluirPostPessoa(DefaultPIM request)
        {
            try
            {
                StringContent queryString = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
                var result =  _httpClient.PostAsync($"/pim/user", queryString).Result;
                if (result.IsSuccessStatusCode)
                    return (true, null);
                else
                {
                    string data =  result.Content.ReadAsStringAsync().Result;
                    var response = JsonSerializer.Deserialize<ErrorResponse>(data, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                    return (false, response);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return (false, null);
        }

        public (bool resp, ErrorResponse respError) DeletarPessoa(int id)
        {
            try
            {
                var result = _httpClient.DeleteAsync($"/pim/user?id={id}").Result;
                if (result.IsSuccessStatusCode)
                    return (true, null);
                else
                {
                    string data = result.Content.ReadAsStringAsync().Result;
                    var response = JsonSerializer.Deserialize<ErrorResponse>(data, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                    return (false, response);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return (false, null);
        }

        public (bool resp, ErrorResponse respError) AtualizarPostPessoa(DefaultPIM request)
        {
            try
            {
                StringContent queryString = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
                var result = _httpClient.PostAsync($"/pim/user/update", queryString).Result;
                if (result.IsSuccessStatusCode)
                    return (true, null);
                else
                {
                    string data = result.Content.ReadAsStringAsync().Result;
                    var response = JsonSerializer.Deserialize<ErrorResponse>(data, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                    return (false, response);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return (false, null);
        }
    }
}