using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Interfaces.Model;

namespace Library.Model
{
    public class Fetch : IFetch
    {
        public static IFetch Empty { get; } = new Fetch();

        [JsonPropertyName("URIs")]
        public IEnumerable<Uri> URIs { get; set; }
    }
}