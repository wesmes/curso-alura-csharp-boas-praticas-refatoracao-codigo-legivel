using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console
{
    [DocComando(instrucao: "help",
                documentacao: "adopet help comando que exibe informações de ajuda.")]
    internal class Help
    {
        private Dictionary<string, DocComando> docs;
        public Help()
        {
            docs = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.GetCustomAttributes<DocComando>().Any())
                .Select(t => t.GetCustomAttribute<DocComando>()!)
                .ToDictionary(d => d.Instrucao);
        }
        public void ExibeDocumentacao(string[] parametros)
        {
            System.Console.WriteLine("Lista de comandos.");
            // se não passou mais nenhum argumento mostra help de todos os comandos
            if (parametros.Length == 1)
            {
                System.Console.WriteLine("adopet help <parametro> ous simplemente adopet help  " +
                     "comando que exibe informações de ajuda dos comandos.");
                System.Console.WriteLine("Adopet (1.0) - Aplicativo de linha de comando (CLI).");
                System.Console.WriteLine("Realiza a importação em lote de um arquivos de pets.");
                System.Console.WriteLine("Comando possíveis: ");
                System.Console.WriteLine($" adopet help comando que exibe informações de ajuda.");
                System.Console.WriteLine($" adopet import <arquivo> comando que realiza a importação do arquivo de pets.");
                System.Console.WriteLine($" adopet show <arquivo> comando que exibe no terminal o conteúdo do arquivo importado.");
                System.Console.WriteLine($" adopet list comando que exibe no terminal a lista de pets cadastrados na API.");
                System.Console.WriteLine("Execute 'adopet.exe help [comando]' para obter mais informações sobre um comando."+"\n");

            }
            // exibe o help daquele comando específico
            else if (parametros.Length == 2)
            {
                string comandoASerExibido = parametros[1];
                if (comandoASerExibido.Equals("import"))
                {
                    System.Console.WriteLine(" adopet import <arquivo> " +
                        "comando que realiza a importação do arquivo de pets.");
                }
                if (comandoASerExibido.Equals("show"))
                {
                    System.Console.WriteLine(" adopet show <arquivo>  comando que " +
                        "exibe no terminal o conteúdo do arquivo importado.");
                }
            }
        }
    }
}
