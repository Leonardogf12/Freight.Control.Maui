using System;
namespace freight.control.maui.MVVM.Models.IBGE
{
	public class Microrregiao
	{
        public int Id { get; set; }
        public string Nome { get; set; }
        public Mesorregiao Mesorregiao { get; set; }
    }
}

