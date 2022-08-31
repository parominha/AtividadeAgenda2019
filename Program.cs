using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace AtividadeAgenda2019
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Digite o seu nome: ");
            string Nome = Console.ReadLine();
            Console.Write("Digite o seu sobrenome: ");
            string Sobrenome = Console.ReadLine();
            Console.Write("Digite a sua data de nascimento: ");
            string DataNascimento = Console.ReadLine();
            Console.Write("Digite o seu sexo (F/M): ");
            string Sexo = Console.ReadLine();

            Console.Write("Digite o seu CEP: ");
            string CEP = Console.ReadLine();

            ConsultaViaCep RetornoConsultaViaCep = new ConsultaViaCep();
            ViaCep oViaCep = new ViaCep();
            oViaCep = RetornoConsultaViaCep.Consulta(CEP);

            if (Sexo.ToUpper() == "F")
            {
                Sexo = "F - Feminino";
            }
            else
            {
                Sexo = "M - Masculino";
            }

            Console.WriteLine("----- Dados informados -----");
            Console.WriteLine("Nome:..............." + Nome);
            Console.WriteLine("Sobrenome:.........." + Sobrenome);
            Console.WriteLine("Data de nascimento:." + DataNascimento);
            Console.WriteLine("Sexo:..............." + Sexo);
            Console.WriteLine("CEP:................" + oViaCep.Cep.ToString());
            Console.WriteLine("Logradouro:........." + oViaCep.Logradouro.ToString());
            Console.WriteLine("Complemento:........" + oViaCep.Complemento.ToString());
            Console.WriteLine("Bairro:............." + oViaCep.Bairro.ToString());
            Console.WriteLine("Localidade:........." + oViaCep.Localidade.ToString());
            Console.WriteLine("UF:................." + oViaCep.UF.ToString());
            Console.WriteLine("Ibge:..............." + oViaCep.Ibge.ToString());
            Console.WriteLine("DDD:................" + oViaCep.Ddd.ToString());



            string filePath = @"C:\Projetos Visual Studio\AtividadeAgenda2019";
            var ObjetoDados = JsonConvert.SerializeObject(Nome, Sobrenome, DataNascimento, Sexo, oViaCep.Cep, oViaCep.Logradouro);
            await File.WriteAllTextAsync(filePath, ObjetoDados);
            Console.WriteLine("Dados salvos com sucesso !!!");

        }
    }   
}
