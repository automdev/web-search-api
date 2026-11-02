// Search API – C# example (.NET 6+, top-level statements)
// Usage: dotnet new console -n Example && copy this file to Program.cs, then AUTOM_API_KEY=your-key dotnet run
using System.Text;
using System.Text.Json;

var apiKey = Environment.GetEnvironmentVariable("AUTOM_API_KEY") ?? throw new InvalidOperationException("Set AUTOM_API_KEY");
using var http = new HttpClient { Timeout = TimeSpan.FromSeconds(120) };
http.DefaultRequestHeaders.Add("x-api-key", apiKey);

var query = "query=" + Uri.EscapeDataString("openai");
var response = await http.GetAsync("https://api.autom.dev/v1/search" + (query.Length > 0 ? "?" + query : ""));
if (!response.IsSuccessStatusCode)
{
    Console.Error.WriteLine($"HTTP {(int)response.StatusCode}: {await response.Content.ReadAsStringAsync()}");
    return;
}

using var doc = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
Console.WriteLine(JsonSerializer.Serialize(doc, new JsonSerializerOptions { WriteIndented = true }));
