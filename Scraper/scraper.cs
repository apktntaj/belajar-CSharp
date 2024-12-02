// using HtmlAgilityPack;
// using System;
// using System.Net.Http;
// using System.Threading.Tasks;

// static class WebScraper
// {
//     static readonly string url = "https://www.asumsi.co/post/category/politik/";
//     static readonly HttpClient client = new();

//     public static async Task Run()
//     {
//         try
//         {
//             var html = await client.GetStringAsync(url);
//             var DOM = new HtmlDocument();
//             DOM.LoadHtml(html);

//             var articles = DOM.DocumentNode.SelectNodes(
//                 "//a[@class='post-card-title post-link font-weight-bold']"
//             );

//             if (articles is null)
//             {
//                 Console.WriteLine("No articles found");
//                 return;
//             }

//             for (int i = 0; i < articles.Count; i++)
//             {
//                 var href = articles[i].GetAttributeValue("href", string.Empty);
//                 Console.WriteLine($"{i + 1}. {articles[i].InnerText.Trim().ToUpper()}");
//                 Console.WriteLine($"\t{href}");
//             }
//         }
//         catch (HttpRequestException e)
//         {
//             Console.WriteLine($"Request error: {e.Message}");
//         }
//         catch (Exception e)
//         {
//             Console.WriteLine($"Unexpected error: {e.Message}");
//         }
//     }
// }