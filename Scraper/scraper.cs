using HtmlAgilityPack;
using Microsoft.VisualBasic;
using System;
using System.Net.Http;

static class WebScraper
{
    static readonly string url = "https://www.asumsi.co/post";
    public static void Run()
    {
        HttpClient client = new();
        var html = client.GetStringAsync(url).Result;
        var DOM = new HtmlDocument();
        DOM.LoadHtml(html);

        try
        {
            var articles = DOM.DocumentNode.SelectNodes(
                "//a[@class='post-card-title post-link font-weight-bold']"
            );
            if (articles == null)
            {
                Console.WriteLine("No articles found");
                return;
            }

            for (int i = 0; i < articles.Count; i++)
            {
                var href = articles[i].GetAttributeValue("href", string.Empty);
                Console.WriteLine(@"");
                Console.WriteLine(
                    $"{i + 1}. {articles[i].InnerText.Trim().ToUpper()}"
                    );
                Console.WriteLine($"\t{href}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
