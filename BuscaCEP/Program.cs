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
            bool reboot = true;
            do
            {
                Console.WriteLine("====================================");
                Console.WriteLine("    Seja bem-vindo ao Busca CEP    ");
                Console.WriteLine("====================================");

                try
                {
                    var cepCliente = RestService.For<IbuscaCepInterfaceAPI>(apiURL);
                    Console.WriteLine("");
                    Console.WriteLine("Informe o CEP desejado:");
                    string cepInformado = Console.ReadLine();

                    Console.WriteLine("Consultando informações do cep " + cepInformado);

                    var address = await cepCliente.getEnderecoAsync(cepInformado);
                    Console.Clear();

                    Console.WriteLine("Informações do CEP:{0}", address.Cep);
                    Console.WriteLine("Rua:{0}\nBairro:{1}\nComplemento:{2}\nCidade:{3}\nEstado:{4}\nDDD do estado:{5}", address.Logradouro, address.Bairro, address.Complemento, address.Localidade, address.Uf, address.DDD);
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("github:DEVJS2005");

                }
                catch (Exception e)
                {
                    Console.WriteLine("Erro na consulta." + e.Message);
                }
                Console.WriteLine("Deseja consultar informações de outro cep?(y/n)");
                string resposta = Console.ReadLine();
                if(resposta == "y")
                {
                    reboot = true;
                    Console.Clear();
                }else if (resposta == "n")
                {
                    Console.Clear();
                    Console.WriteLine("Pressione enter para fechar");
                    Console.WriteLine("");
                    Console.ReadKey();
                    reboot = false;
                }
            } while (reboot == true);

            Console.WriteLine("github:DEVJS2005");


        }
    }
}
