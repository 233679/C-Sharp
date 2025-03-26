using Newtonsoft.Json;
using RestSharp;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using System.Text;

namespace RestAPI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());

            // https://www.colourlovers.com/api/colors/new?format=json
            // https://api.artic.edu/api/v1/artworks/search?q=cats
        }

        /// <summary>
        ///  Doesn't work due to the colourlovers api requiring some type of authenetication.
        /// </summary>
        /// <returns></returns>
        public static string getData()
        {
            RestClient client = new RestClient("https://api.artic.edu/api/v1");
            RestRequest restRequest = new RestRequest("artworks");

            RestResponse response = client.Execute(restRequest);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return (response.ResponseUri + "\n" + response.StatusCode.ToString());
            }

            Rootobject? null_result = JsonConvert.DeserializeObject<Rootobject>(response.Content);

            if (null_result == null)
            {
                return "Failed to parse:\n" + response.Content.ToString();
            }

            Rootobject result = null_result;
            string data_buffer = result.ToString();

            foreach (var data in result.data)
            {
                data_buffer += (data.ToString() + "\n");
            }

            return data_buffer;
        }
    }
}

[ToString]
public class Rootobject
{
    public object preference { get; set; }
    public Pagination pagination { get; set; }
    public Datum[] data { get; set; }
    public Info info { get; set; }
    public Config config { get; set; }
}

[ToString]
public class Pagination
{
    public int total { get; set; }
    public int limit { get; set; }
    public int offset { get; set; }
    public int total_pages { get; set; }
    public int current_page { get; set; }
}

[ToString]
public class Info
{
    public string license_text { get; set; }
    public string[] license_links { get; set; }
    public string version { get; set; }
}

[ToString]
public class Config
{
    public string iiif_url { get; set; }
    public string website_url { get; set; }
}

[ToString]
public class Datum
{
    public float _score { get; set; }
    public int id { get; set; }
    public string api_model { get; set; }
    public string api_link { get; set; }
    public bool is_boosted { get; set; }
    public string title { get; set; }
    public Thumbnail thumbnail { get; set; }
    public DateTime timestamp { get; set; }
}

[ToString]
public class Thumbnail
{
    public string lqip { get; set; }
    public int width { get; set; }
    public int height { get; set; }
    public string alt_text { get; set; }
}
