using System.Text;

HttpClient client = new();

//using(HttpRequestMessage request = new(HttpMethod.Get, "https://tula.top-academy.ru"))
//{
//    HttpResponseMessage response = await client.SendAsync(request);

//    Console.WriteLine($"Status: {response.StatusCode}");
//    Console.WriteLine($"Hreaders:");

//    foreach(var header in response.Headers)
//    {
//        Console.WriteLine($"\tKey: {header.Key}");
//        foreach (var value in header.Value)
//            Console.WriteLine($"\t\tValue: {value}");
//    }

//    Console.WriteLine($"Content: {await response.Content.ReadAsStringAsync()}");

//}

//string content = await client.GetStringAsync("https://tula.top-academy.ru");
//Console.WriteLine(content);

//byte[] buffer = await client.GetByteArrayAsync("https://tula.top-academy.ru");
//Console.WriteLine(Encoding.UTF8.GetString(buffer));

using(Stream stream = await client.GetStreamAsync("https://tula.top-academy.ru"))
{
    StreamReader reader = new StreamReader(stream);
    string content = await reader.ReadToEndAsync();
    FileStream writer = File.OpenWrite("index.html");
    writer.Write(Encoding.UTF8.GetBytes(content));
}


