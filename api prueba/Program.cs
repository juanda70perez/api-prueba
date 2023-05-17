// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using Newtonsoft.Json.Linq;

string link = "https://pokeapi.co/api/v2/pokemon?offset=20&limit=20";

using (var httpClient = new HttpClient())
{
    var response = await httpClient.GetAsync(link);
    try
    {
        if (response.IsSuccessStatusCode)
        {
            if (response.Content != null)
            {
                var datos = response.Content.ReadAsStringAsync();
                var json = JObject.Parse(datos.Result);
                //Console.WriteLine(json["results"][0]["name"]);
                foreach (var dato in json["results"])
                {
                    Console.WriteLine(dato["name"]);
                }
            }
        }
        else
        {
            Console.WriteLine("no funciono");
        }
    }catch(Exception e)
    {
        Console.WriteLine("Ocurrio un error: "e.Message);
    }
   

}