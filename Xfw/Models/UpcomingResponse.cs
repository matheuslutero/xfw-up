using System.Collections.Generic;
using Newtonsoft.Json;

namespace Xfw.Models
{
    public class UpcomingResponse
    {
        [JsonProperty("results")]
        public List<Movie> Movies { get; set; }
    }
}
