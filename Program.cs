using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AtividadeAgenda2019
{
    class Program
    {
        static async Task Main(string[] args)
        {
            List<Agenda> ListaAgenda = new List<Agenda>();
            Boolean Consulta = true;
            ViaCep oViaCep = new ViaCep();

            while (Consulta)
            {
                string Nome, Sobrenome, DataNascimento, Sexo;

                Console.WriteLine("Digite LISTAR / SALVAR / CADASTRO / SAIR");
                string OpcaoEscolhida = Console.ReadLine();

                switch (OpcaoEscolhida.ToUpper())
                {
                    case "SALVAR":
                        string filePath = @"C:\temp\Lista.json";
                        var ObjetoDados = JsonConvert.SerializeObject(ListaAgenda);
                        await File.WriteAllTextAsync(filePath, ObjetoDados);
                        Console.WriteLine("**Dados salvos com sucesso!**");
                        break;

                    case "SAIR":
                        Consulta = false;
                        break;

                    case "CADASTRO":
                        Agenda oAgenda = new Agenda();
                        Console.Write("Digite o seu nome: ");
                        Nome = Console.ReadLine();
                        Console.Write("Digite o seu sobrenome: ");
                        Sobrenome = Console.ReadLine();
                    ValidacaoData:
                        Console.Write("Digite a sua data de nascimento: ");
                        DataNascimento = Console.ReadLine();
                        try
                        {
                            oAgenda.DataNascimento = DateTime.Parse(DataNascimento);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("**Digite uma data válida**");
                            goto ValidacaoData;
                        }
                    ValidacaoSexo:
                        Console.Write("Digite o seu sexo (F/M): ");
                        Sexo = Console.ReadLine();
                        if (Sexo.ToUpper() == "F")
                        {
                            Sexo = "F - Feminino";
                        }
                        else if (Sexo.ToUpper() == "M")
                        {
                            Sexo = "M - Masculino";
                        }
                        else
                        {
                            Console.WriteLine("**Digite um sexo válido (F/M)**");
                            goto ValidacaoSexo;
                        }

                        Console.Write("Digite o seu CEP: ");
                        string CEP = Console.ReadLine();
                        ConsultaViaCep RetornoConsultaViaCep = new ConsultaViaCep();
 
                        oViaCep = RetornoConsultaViaCep.Consulta(CEP);

                        oAgenda.Nome = Nome;
                        oAgenda.Sobrenome = Sobrenome;
                        oAgenda.Sexo = Sexo;
                        ListaAgenda.Add(oAgenda);
                        break;

                    case "LISTAR":

                        int Quantidade = ListaAgenda.Count;
                        for (int i = 0; i < Quantidade; i++)
                        {
                            Console.WriteLine("----- Dados informados -----");
                            Console.WriteLine("Nome:..............." + ListaAgenda[i].Nome.ToString());
                            Console.WriteLine("Sobrenome:.........." + ListaAgenda[i].Sobrenome.ToString());
                            Console.WriteLine("Data de nascimento:." + ListaAgenda[i].DataNascimento.ToString());
                            Console.WriteLine("Sexo:..............." + ListaAgenda[i].Sexo.ToString());
                            Console.WriteLine("CEP:................" + oViaCep.Cep.ToString());
                            Console.WriteLine("Logradouro:........." + oViaCep.Logradouro.ToString());
                            Console.WriteLine("Complemento:........" + oViaCep.Complemento.ToString());
                            Console.WriteLine("Bairro:............." + oViaCep.Bairro.ToString());
                            Console.WriteLine("Localidade:........." + oViaCep.Localidade.ToString());
                            Console.WriteLine("UF:................." + oViaCep.UF.ToString());
                            Console.WriteLine("Ibge:..............." + oViaCep.Ibge.ToString());
                            Console.WriteLine("DDD:................" + oViaCep.Ddd.ToString());
                        }
                        break;

                    default:
                        Console.WriteLine("**Opção não encontrada, tente novamente!**");
                        break;
                }
            }
        }
    }
}
