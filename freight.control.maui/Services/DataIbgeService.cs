using Newtonsoft.Json;

namespace freight.control.maui.Services;

public class RegiaoIntermediaria
{
    public int Id { get; set; }
    public string Nome { get; set; }
}

public class RegiaoImediata
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public RegiaoIntermediaria RegiaoIntermediaria { get; set; }
}

public class Mesorregiao
{
}

public class Microrregiao
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public Mesorregiao Mesorregiao { get; set; }
    public RegiaoImediata RegiaoImediata { get; set; }
}

public class Municipio
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public Microrregiao Microrregiao { get; set; }
}

public class Localidades
{
    public List<Municipio> Municipios { get; set; }
}

public class DataIbgeService
{    
    const string url = "https://servicodados.ibge.gov.br/api/v1/localidades/estados/";

    public static async Task<List<Municipio>> GetCitiesByCodeState(string state)
    {
        using (HttpClient client = new HttpClient())
        {
            var codeState = $"{state}/municipios";

            try
            {               
                HttpResponseMessage response = await client.GetAsync(url + codeState);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var result = JsonConvert.DeserializeObject<List<Municipio>>(content);

                    return result;
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
