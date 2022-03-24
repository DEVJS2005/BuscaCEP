
using Refit;
using System.Threading.Tasks;

namespace BuscaCEP
{
    public interface IBuscaCepInterfaceAPI
    {
        [Get("/{cep}/json/")]
        Task<cepResponde> GetenderecoAsync(string cep);
        
    }
}
