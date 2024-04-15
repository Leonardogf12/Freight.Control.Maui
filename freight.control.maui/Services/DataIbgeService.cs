using System.IO.Compression;
using freight.control.maui.Constants;
using Newtonsoft.Json;

namespace freight.control.maui.Services;

public class Regiao
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Sigla { get; set; }
}

public class UF
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Sigla { get; set; }
    public Regiao Regiao { get; set; }
}

public class RegiaoIntermediaria
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public UF UF { get; set; }
}

public class Mesorregiao
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public UF UF { get; set; }
}

public class Microrregiao
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public Mesorregiao Mesorregiao { get; set; }
}

public class Municipio
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public Microrregiao Microrregiao { get; set; }
}


public class DataIbgeService
{       
    public static async Task<List<Municipio>> GetCitiesByCodeState(string state)
    {
        using (HttpClient client = new HttpClient())
        {
            var codeState = $"{state}/municipios";

            try
            {
                if (!ToastFailConectionService.CheckIfConnectionIsSuccessful()) return null;

                HttpResponseMessage response = await client.GetAsync(StringConstants.urlDataIbgeService + codeState);

                if (response.IsSuccessStatusCode)
                {
                    //var downloaded = new System.Net.WebClient().DownloadString(StringConstants.urlDataIbgeService + codeState);
                    //var result = JsonConvert.DeserializeObject<List<Municipio>>(downloaded);
                    //return result;

                    using (var stream = await response.Content.ReadAsStreamAsync())
                    using (var decompressedStream = new GZipStream(stream, CompressionMode.Decompress))
                    using (var reader = new StreamReader(decompressedStream))
                    {
                        var content = await reader.ReadToEndAsync();

                        var result = JsonConvert.DeserializeObject<List<Municipio>>(content);

                        return result;
                    }
                }

                return new List<Municipio>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Municipio>();
            }
        }
    }
}
