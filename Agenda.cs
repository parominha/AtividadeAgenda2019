using System;
using System.Collections.Generic;
using System.Text;

namespace AtividadeAgenda2019
{
    public class Agenda
    {
        public Agenda()
        { }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string UF { get; set; }
        public string Ibge { get; set; }
        public string Ddd { get; set; }


        //public Agenda(string nome, string sobrenome, DateTime datanascimento, string sexo)
        //{
        //    this.Nome = nome;
        //    this.Sobrenome = sobrenome;
        //    this.DataNascimento = datanascimento;
        //    this.Sexo = sexo;
        //}

    }
}
