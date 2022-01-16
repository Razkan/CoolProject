using System;
using System.Collections.Generic;

namespace Interfaces.Model.Shared
{
    public interface IEndpoint
    {
        IEnumerable<Uri> URIs { get; }
    }
}