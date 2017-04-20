using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace TestAzureSearch.Controllers
{
    [RoutePrefix("test-azure")]
    public class TestAzureSearchController : ApiController
    {
        static SearchServiceClient searchClient;

        [Route("add")]
        [HttpGet]
        public void Add()
        {
            var apiKey = "51E32E3D8142D3E16012FD0125844A02";
            var serviceName = "fuzelab";
            var indexName = "casemaster";

            searchClient = new SearchServiceClient(serviceName, new SearchCredentials(apiKey));

            customer customer = new customer
            {
                patientname = "patient firstname lastname a",
                id = "1000"
            };

            var indexBatch = IndexBatch.MergeOrUpload(new List<customer> { customer });

            var indexClient = searchClient.Indexes.GetClient(indexName);
            var result = indexClient.Documents.Index(indexBatch);
        }

        [Route("search/{id}")]
        [HttpGet]
        public void Search(int id)
        {
            var apiKey = "51E32E3D8142D3E16012FD0125844A02";
            var serviceName = "fuzelab";
            var indexName = "casemaster";

            searchClient = new SearchServiceClient(serviceName, new SearchCredentials(apiKey));
            var indexClient = searchClient.Indexes.GetClient(indexName);
            var a = indexClient.Documents.Search("*", new SearchParameters { Select = new[] { "patientname" } });

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("api-key", "51E32E3D8142D3E16012FD0125844A02");
            var clientResponse = Task.Run(() => client.GetAsync(
                "https://fuzelab.search.windows.net/indexes/casemaster/docs?api-version=2016-09-01&search=*&id=" + id)).Result;
            clientResponse.EnsureSuccessStatusCode();
            var result = Task.Run(() => clientResponse.Content.ReadAsStringAsync()).Result;
            var serializer = new JavaScriptSerializer();
            var testData = serializer.Deserialize<response>(result);
            var testData2 = serializer.DeserializeObject(result);
        }

        [SerializePropertyNamesAsCamelCase]
        public class customer
        {
            public string id { get; set; }
            public string patientname { get; set; }
            public string specialinstruction { get; set; }
        }

        public class responseData
        {
            public string key { get; set; }
            public object value { get; set; }
        }

        public class responseData2
        {
            public string key { get; set; }
            public string value { get; set; }
        }

        public class response
        {
            public responseData first { get; set; }
            public responseData2 second { get; set; }
        }
    }
}
