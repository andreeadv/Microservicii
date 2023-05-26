using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Microservicii
{
    class Program
    {
        static async Task test_sum()
        {
            // Set the vector to sort
            var vector = new List<int> { 5, 3, 1, 4, 2 };

            // Create the request payload
            var payload = new Dictionary<string, List<int>>
            {
                { "vector", vector }
            };

            // Convert the payload to JSON
            var jsonPayload = Newtonsoft.Json.JsonConvert.SerializeObject(payload);

            // Set the URL of the microservice
            var apiUrl = "http://localhost:5000/sum";

            // Create a HttpClient instance
            using (var httpClient = new HttpClient())
            {
                // Create a HttpRequestMessage with the JSON payload
                var request = new HttpRequestMessage(HttpMethod.Post, apiUrl);
                request.Content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                // Send the request and get the response
                var response = await httpClient.SendAsync(request);

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content
                    var responseContent = await response.Content.ReadAsStringAsync();

                    // Deserialize the response JSON
                    var result = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, int>>(responseContent);

                    // Get the sorted vector from the response
                    var suma_ = result["suma"];

                    // Print the sorted vector
                    Console.WriteLine("Suma elementelor: " + string.Join(", ", suma_));
                }
                else
                {
                    Console.WriteLine("Error: " + response.StatusCode);
                }
            }
            Console.ReadLine();
        }

        static async Task test_min()
        {
            // Set the vector to sort
            var vector = new List<int> { 5, 3, 1, 4, 2 };

            // Create the request payload
            var payload = new Dictionary<string, List<int>>
            {
                { "vector", vector }
            };

            // Convert the payload to JSON
            var jsonPayload = Newtonsoft.Json.JsonConvert.SerializeObject(payload);

            // Set the URL of the microservice
            var apiUrl = "http://localhost:5001/min";

            // Create a HttpClient instance
            using (var httpClient = new HttpClient())
            {
                // Create a HttpRequestMessage with the JSON payload
                var request = new HttpRequestMessage(HttpMethod.Post, apiUrl);
                request.Content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                // Send the request and get the response
                var response = await httpClient.SendAsync(request);

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content
                    var responseContent = await response.Content.ReadAsStringAsync();

                    // Deserialize the response JSON
                    var result = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, int>>(responseContent);

                    // Get the sorted vector from the response
                    var minelement = result["min_element"];

                    // Print the sorted vector
                    Console.WriteLine("Elementul minim din vector: " + string.Join(", ", minelement));
                }
                else
                {
                    Console.WriteLine("Error: " + response.StatusCode);
                }
            }
            Console.ReadLine();
        }

        static async Task test_max()
        {
            // Set the vector to sort
            var vector = new List<int> { 5, 3, 1, 4, 2 };

            // Create the request payload
            var payload = new Dictionary<string, List<int>>
            {
                { "vector", vector }
            };

            // Convert the payload to JSON
            var jsonPayload = Newtonsoft.Json.JsonConvert.SerializeObject(payload);

            // Set the URL of the microservice
            var apiUrl = "http://localhost:5002/max";

            // Create a HttpClient instance
            using (var httpClient = new HttpClient())
            {
                // Create a HttpRequestMessage with the JSON payload
                var request = new HttpRequestMessage(HttpMethod.Post, apiUrl);
                request.Content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                // Send the request and get the response
                var response = await httpClient.SendAsync(request);

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content
                    var responseContent = await response.Content.ReadAsStringAsync();

                    // Deserialize the response JSON
                    var result = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, int>>(responseContent);

                    // Get the sorted vector from the response
                    var maxelement = result["max_element"];

                    // Print the sorted vector
                    Console.WriteLine("Elementul maxim din vector: " + string.Join(", ", maxelement));
                }
                else
                {
                    Console.WriteLine("Error: " + response.StatusCode);
                }
            }
            Console.ReadLine();
        }

        static async Task Main(string[] args)
        {
            await test_sum();
            await test_min();
            await test_max();
        }
    }
}