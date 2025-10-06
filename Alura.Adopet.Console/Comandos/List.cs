using Alura.Adopet.Console.Modelos;
using Alura.Adopet.Console.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.Comandos
{
    [DocComando(instrucao: "list",
                documentacao: "adopet list comando que exibe no terminal a lista de pets cadastrados na API.")]

    internal class List : IComando
    {
        public Task ExecutarAsync(string[] args)
        {
            this.ListaDadosPetsDaAPIAsync();
            return Task.CompletedTask;
        }

        private async Task ListaDadosPetsDaAPIAsync()
        {
            var httpListPet = new HttpClientPet();
            IEnumerable<Pet>? pets = await httpListPet.ListPetsAsync();
            System.Console.WriteLine("----- Lista de Pets importados no sistema -----");
            foreach (var pet in pets)
            {
                System.Console.WriteLine(pet);
            }
        }
    }
}
