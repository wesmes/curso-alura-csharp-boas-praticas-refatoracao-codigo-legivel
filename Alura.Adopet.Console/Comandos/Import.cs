using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos;
using Alura.Adopet.Console.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(instrucao:"import",
                documentacao: "adopet import <arquivo> comando que realiza a importação do arquivo de pets.")]
    internal class Import: IComando
    {
        public async Task ExecutarAsync(string[] args)
        {
            await this.ImportacaoArquivoPetAsync(caminhoDeImportacaoDoArquivo: args[1]);
        }

        private async Task ImportacaoArquivoPetAsync(string caminhoDeImportacaoDoArquivo)
        {
            var leitor = new LeitorDeArquivo();
            List<Pet> listaDePet = leitor.RealizaLeitura(caminhoDeImportacaoDoArquivo);
            foreach (var pet in listaDePet)
            {
                System.Console.WriteLine($"Importando pet: {pet.Nome}");
                try
                {
                    var httpCreatePet = new HttpClientPet();
                    await httpCreatePet.CreatePetAsync(pet);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
            System.Console.WriteLine("Importação concluída!");
        }
    }
}
