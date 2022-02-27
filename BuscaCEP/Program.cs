using Refit;
using System;
using System.Threading.Tasks;

namespace BuscaCEP
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            string apiURL = "https://viacep.com.br/ws";
            Console.WriteLine("Seja bem vindo ao BuscaCEP by:JSInformatica");
            Console.Write("");
            try
            {
                var cepCliente = RestService.For<IbuscaCepInterfaceAPI>(apiURL);
                Console.WriteLine("Informe o CEP desejado:");
                string cepInformado = Console.ReadLine();

                Console.WriteLine("Consultando informações do cep " + cepInformado);

                var address = await cepCliente.getEnderecoAsync(cepInformado);
                
                Console.WriteLine("Informações do CEP:{0}",address.Cep);
                Console.WriteLine("Rua:{0}\nBairro:{1}\nComplemento:{2}\nCidade:{3}\nEstado:{4}\nDDD do estado:{5}",address.Logradouro,address.Bairro,address.Complemento,address.Localidade,address.Uf,address.DDD);


            }
            catch (Exception e)
            {
                Console.WriteLine("Erro na consulta." + e.Message);
            }
            Console.Write("");
            Console.WriteLine("Pressione enter para fechar");
            Console.ReadKey();
        
        }
    }
}
