using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FinalOrderSystem.Web.Core.Menu
{
    public class MenuModule
    {
        /// <summary>
        ///  Get Menu Json and Deserialize
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FinalOrderSystem.DataClass.DataModels.Menu> GetMenus()
        {
            var data = new List<FinalOrderSystem.DataClass.DataModels.Menu>();
            var url = "http://localhost:5154/api/Menu/GetMenus";
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync(url).Result;
                if (result.StatusCode.Equals(HttpStatusCode.OK))
                {
                    var resultStr = result.Content.ReadAsStringAsync().Result;
                    data = JsonConvert.DeserializeObject<List<FinalOrderSystem.DataClass.DataModels.Menu>>(resultStr);
                }
            }

            return data;
        }
        public IEnumerable<FinalOrderSystem.DataClass.DataModels.Menu> GetMenuByID(string SID)
        {

            var data = new List<FinalOrderSystem.DataClass.DataModels.Menu>();
            var url = $"http://localhost:5154/api/Menu/GetMenuByID?SID={SID}";


            
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync(url).Result;
                if (result.StatusCode.Equals(HttpStatusCode.OK))
                {
                    var resultStr = result.Content.ReadAsStringAsync().Result;
                    data = JsonConvert.DeserializeObject<List<FinalOrderSystem.DataClass.DataModels.Menu>>(resultStr);
                }
            }

            return data;
        }
        public IEnumerable<FinalOrderSystem.DataClass.DataModels.Menu> GetMenuByName(string Name)
        {

            var data = new List<FinalOrderSystem.DataClass.DataModels.Menu>();
            var url = $"http://localhost:5154/api/Menu/GetMenuByName?Name={Name}";



            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync(url).Result;
                if (result.StatusCode.Equals(HttpStatusCode.OK))
                {
                    var resultStr = result.Content.ReadAsStringAsync().Result;
                    data = JsonConvert.DeserializeObject<List<FinalOrderSystem.DataClass.DataModels.Menu>>(resultStr);
                }
            }

            return data;
        }
        public bool CreateMenu(FinalOrderSystem.DataClass.DataModels.Menu model)
        {

            var data = false;
            var url = "http://localhost:5154/api/Menu/CreateMenu";


            string json = JsonConvert.SerializeObject(model);

            HttpContent contentPost = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                var result = client.PostAsync(url, contentPost).GetAwaiter().GetResult();
                if (result.StatusCode.Equals(HttpStatusCode.OK))
                {
                    var resultStr = result.Content.ReadAsStringAsync().Result;
                    data = JsonConvert.DeserializeObject<bool>(resultStr);
                }
            }
            return data;
        }

        public bool EditMenu(FinalOrderSystem.DataClass.DataModels.Menu model)
        {

            var data = false;
            var url = "http://localhost:5154/api/Menu/EditMenu";


            string json = JsonConvert.SerializeObject(model);
 
            HttpContent contentPost = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                var result = client.PostAsync(url, contentPost).GetAwaiter().GetResult();
                if (result.StatusCode.Equals(HttpStatusCode.OK))
                {
                    var resultStr = result.Content.ReadAsStringAsync().Result;
                    data = JsonConvert.DeserializeObject<bool>(resultStr);
                }
            }
            return data;
        }
        public bool DeleteMenu(string SID)
        {

            var data = false;
            var url = "http://localhost:5154/api/Menu/DeleteMenu";

            string json = JsonConvert.SerializeObject(SID);

            HttpContent contentPost = new StringContent(json, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                var result = client.PostAsync(url, contentPost).GetAwaiter().GetResult();
                if (result.StatusCode.Equals(HttpStatusCode.OK))
                {
                    var resultStr = result.Content.ReadAsStringAsync().Result;
                    data = JsonConvert.DeserializeObject<bool>(resultStr);
                }
            }
            return data;
        }
    }
}
