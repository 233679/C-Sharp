using Newtonsoft.Json;
using RestSharp;

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
            RestClient client = new RestClient("https://www.colourlovers.com/api/colors/new");
            RestRequest restRequest = new RestRequest("?format=json");

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
            string data_buffer = "";

            foreach (var data in result.Property1)
            {
                data_buffer += (data.ToString() + "\n"); 
            }

            return data_buffer;
        }
    }
}

public class Rootobject
{
    public Class1[] Property1 { get; set; }
}

public class Class1
{
    public int id { get; set; }
    public string title { get; set; }
    public string userName { get; set; }
    public int numViews { get; set; }
    public int numVotes { get; set; }
    public int numComments { get; set; }
    public int numHearts { get; set; }
    public int rank { get; set; }
    public string dateCreated { get; set; }
    public string hex { get; set; }
    public Rgb rgb { get; set; }
    public Hsv hsv { get; set; }
    public string description { get; set; }
    public string url { get; set; }
    public string imageUrl { get; set; }
    public string badgeUrl { get; set; }
    public string apiUrl { get; set; }
}

public class Rgb
{
    public int red { get; set; }
    public int green { get; set; }
    public int blue { get; set; }
}

public class Hsv
{
    public int hue { get; set; }
    public int saturation { get; set; }
    public int value { get; set; }
}
