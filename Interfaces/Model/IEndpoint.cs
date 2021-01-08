using System;
using System.Collections.Generic;

namespace Interfaces.Model
{
    public interface IEndpoint
    {
        IEnumerable<Uri> URIs { get; }
    }
}