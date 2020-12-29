using System;
using System.Threading.Tasks;

namespace Library
{
    public interface IRemoteProcedureCall
    {
        Task Register<TInterface>(Uri uri);
        Task<IRPCResponse> GetAsync<TInterface>();
    }
}