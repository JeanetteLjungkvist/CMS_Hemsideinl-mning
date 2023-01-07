namespace Umbraco_Website.NewsArticle
{
    public class Root
    {
        public List<Articles>? Articles { get; set; }

    }

    public class Articles
    {

        public Source? Source { get; set; }

        public string? Author { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? Url { get; set; }

        public string? UrlToImage { get; set; }

        public DateTime? PublishedAt { get; set; }

        public string? Content { get; set; }
    }

    public class Source
    {
        public string? Id { get; set; }

        public string? Name { get; set; }
    }

    public class NewsClient
    {

        public static async Task<Root?> GetNewsArticlesAsync()
        {

            var client = new HttpClient();


            var respons = await client.GetFromJsonAsync<Root?>("https://newsapi.org/v2/top-headlines?country=se&category=science&apiKey=066adeace431427ab6ea1cc3102cd97b");

            return respons;
        }
    }
}
