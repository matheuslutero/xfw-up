using System.Threading.Tasks;
using Refit;
using Xfw.Models;

namespace Xfw.Api
{
    public interface IMovieApi
    {
        [Get("/movie/upcoming?api_key={apiKey}")]
        Task<UpcomingResponse> GetUpcoming(string apiKey);
    }
}
