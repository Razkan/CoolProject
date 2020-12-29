using System;
using System.Collections.Generic;

namespace Interfaces.Model
{
    public interface IFetch
    {
        IEnumerable<Uri> URIs { get; }
    }
}