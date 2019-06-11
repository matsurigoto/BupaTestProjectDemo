using BupaWebAPI.Messages;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BupaWebAPI.Clients
{
    public interface IMemberApiClient
    {
        Task<CreateMemberResponse> CreateMemberAsync(CreateMemberRequest request);
    }

    public class MemberApiClient : IMemberApiClient
    {
        //protected readonly IHttpClientFactory _clientFactory;
        protected readonly HttpClient _httpClient;

        public MemberApiClient(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<CreateMemberResponse> CreateMemberAsync(CreateMemberRequest request)
        {
            var content = JsonConvert.SerializeObject(request);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var buffercontent = new ByteArrayContent(buffer);
            buffercontent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //var client = _httpClient.CreateClient("myBupaAPI");
            var result = await _httpClient.PostAsync("/BupaAPI/CreateMember", buffercontent);
            var responseContent = result.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CreateMemberResponse>(responseContent.Result);
        }
    }
}
