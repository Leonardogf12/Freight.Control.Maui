using System.IO.Compression;
using freight.control.maui.Constants;
using Newtonsoft.Json;
using freight.control.maui.MVVM.Models.IBGE;

namespace freight.control.maui.Services;

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
