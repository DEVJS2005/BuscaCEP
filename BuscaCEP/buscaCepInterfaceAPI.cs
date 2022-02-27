
using Refit;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaCEP
{
    public interface IbuscaCepInterfaceAPI
    {
        [Get("/{cep}/json/")]
        Task<cepResponde> getEnderecoAsync(string cep);
        
    }
}
