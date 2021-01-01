using System;
using System.Threading.Tasks;

namespace Interfaces.Model
{
    public interface IRemoteProcedureCall
    {
        Task Register<TInterface>(Uri uri);
        Task<IRPCResponse> GetAsync<TInterface>();
    }
}