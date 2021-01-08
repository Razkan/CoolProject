using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Interfaces.Model;

namespace Library.Model
{
    public class Endpoint : IEndpoint
    {
        public static IEndpoint Empty { get; } = new Endpoint();

        [JsonPropertyName("URIs")]
        public IEnumerable<Uri> URIs { get; set; }
    }
}