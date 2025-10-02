﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console
{
    internal class Import
    {
        HttpClient client;
        public Import()
        {
            this.client = ConfiguraHttpClient("http://localhost:5057");
        }
        public async Task ImportacaoArquivoPetAsync(string caminhoDeImportacaoDoArquivo)
        {
            var leitor = new LeitorDeArquivo();
            List<Pet> listaDePet = leitor.RealizaLeitura(caminhoDeImportacaoDoArquivo);
            foreach (var pet in listaDePet)
            {
                System.Console.WriteLine($"Importando pet: {pet.Nome}");
                try
                {
                    var resposta = await CreatePetAsync(pet);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
            System.Console.WriteLine("Importação concluída!");
        }

        Task<HttpResponseMessage> CreatePetAsync(Pet pet)
        {
            HttpResponseMessage? response = null;
            using (response = new HttpResponseMessage())
            {
                return client.PostAsJsonAsync("pet/add", pet);
            }
        }

        HttpClient ConfiguraHttpClient(string url)
        {
            HttpClient _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            _client.BaseAddress = new Uri(url);
            return _client;
        }
    }
}
