namespace freight.control.maui.MVVM.Models.IBGE
{
    public class UF
	{
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public Regiao Regiao { get; set; }
    }
}

