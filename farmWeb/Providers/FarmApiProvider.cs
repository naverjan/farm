using farmAPI.Models;
using farmWeb.Providers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace farmWeb.Providers
{
    public class FarmApiProvider : IFarmApi
    {
        private readonly IHttpClientFactory httpClientFactory;

        public FarmApiProvider(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<ICollection<FarmAnimal>> GetAnimals()
        {
            var client = httpClientFactory.CreateClient("farmServices");
            var response = await client.GetAsync("/api/animal");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                MemoryStream contentEnd = new MemoryStream(Encoding.UTF8.GetBytes(content));
                var results = await JsonSerializer.DeserializeAsync<ICollection<FarmAnimal>>(contentEnd, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                return results;
            }
            return null;
        }

        public async Task<FarmAnimalType> GetAnimalType(int id)
        {
            var client = httpClientFactory.CreateClient("farmServices");
            var response = await client.GetAsync("/api/AnimalType/" + id.ToString());
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                MemoryStream contentEnd = new MemoryStream(Encoding.UTF8.GetBytes(content));
                var results = await JsonSerializer.DeserializeAsync<FarmAnimalType>(contentEnd, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                return results;
            }
            return null;
        }

        public async Task<bool> AddCorral(FarmCorral corral)
        {
            var client = httpClientFactory.CreateClient("farmServices");
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            var body = new StringContent(JsonSerializer.Serialize(corral, options), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/api/corral", body);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<ICollection<FarmCorral>> GetCorrals()
        {
            var client = httpClientFactory.CreateClient("farmServices");
            var response = await client.GetAsync("/api/Corral");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                MemoryStream contentEnd = new MemoryStream(Encoding.UTF8.GetBytes(content));
                var results = await JsonSerializer.DeserializeAsync<ICollection<FarmCorral>>(contentEnd, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                return results;
            }
            return null;
        }

        public async Task<ICollection<FarmAnimalType>> GetAnimalTypes()
        {
            var client = httpClientFactory.CreateClient("farmServices");
            var response = await client.GetAsync("/api/AnimalType");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                MemoryStream contentEnd = new MemoryStream(Encoding.UTF8.GetBytes(content));
                var results = await JsonSerializer.DeserializeAsync<ICollection<FarmAnimalType>>(contentEnd, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                return results;
            }
            return null;
        }

        public  async Task<FarmCorral> GetCorralById(int id)
        {
            var client = httpClientFactory.CreateClient("farmServices");
            var response = await client.GetAsync("/api/corral/" + id.ToString());
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                MemoryStream contentEnd = new MemoryStream(Encoding.UTF8.GetBytes(content));
                var results = await JsonSerializer.DeserializeAsync<FarmCorral>(contentEnd, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                return results;
            }
            return null;
        }

        public async Task<FarmDanger> GetDangerBydId(int id)
        {
            var client = httpClientFactory.CreateClient("farmServices");
            var response = await client.GetAsync("/api/danger/" + id.ToString());
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                MemoryStream contentEnd = new MemoryStream(Encoding.UTF8.GetBytes(content));
                var results = await JsonSerializer.DeserializeAsync<FarmDanger>(contentEnd, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                return results;
            }
            return null;
        }

        public async Task<bool> AddAnimal(FarmAnimal animal)
        {
            var client = httpClientFactory.CreateClient("farmServices");
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            var body = new StringContent(JsonSerializer.Serialize(animal, options), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/api/animal", body);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<ICollection<FarmAnimalIncompatibility>> GetAnimalIncompatibilities(long id)
        {
            var client = httpClientFactory.CreateClient("farmServices");
            var response = await client.GetAsync("/api/Incompability/"+id.ToString());
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                MemoryStream contentEnd = new MemoryStream(Encoding.UTF8.GetBytes(content));
                var results = await JsonSerializer.DeserializeAsync<ICollection<FarmAnimalIncompatibility>>(contentEnd, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                return results;
            }
            return null;
        }

        public async Task<ICollection<FarmAnimal>> GetAnimalsOfCorral(long idCorral)
        {
            var client = httpClientFactory.CreateClient("farmServices");
            var response = await client.GetAsync("/api/corral/animals/" + idCorral.ToString());
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                MemoryStream contentEnd = new MemoryStream(Encoding.UTF8.GetBytes(content));
                var results = await JsonSerializer.DeserializeAsync<ICollection<FarmAnimal>>(contentEnd, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                return results;
            }
            return null;
        }

        public async Task<ICollection<FarmAnimalIncompatibility>> GetAnimalIncompatibilities()
        {
            var client = httpClientFactory.CreateClient("farmServices");
            var response = await client.GetAsync("/api/Incompability/");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                MemoryStream contentEnd = new MemoryStream(Encoding.UTF8.GetBytes(content));
                var results = await JsonSerializer.DeserializeAsync<ICollection<FarmAnimalIncompatibility>>(contentEnd, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                return results;
            }
            return null;
        }

        public async Task<bool> AddIncompability(FarmAnimalIncompatibility incompatibility)
        {
            var client = httpClientFactory.CreateClient("farmServices");
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            var body = new StringContent(JsonSerializer.Serialize(incompatibility, options), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/api/Incompability", body);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
