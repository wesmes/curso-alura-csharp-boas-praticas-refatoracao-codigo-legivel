using Alura.Adopet.Console.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console.Util
{
    public static class PetAPartirDoCSV
    {
        public static Pet ConverteDoTexto(this string linha)
        {
            string[] propriedades = linha.Split(';');
            return new Pet(Guid.Parse(propriedades[0]),
                                        propriedades[1],
                                        TipoPet.Cachorro
                                        );
        }
    }
}
