using GrinScootersClone.Models;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrinScootersClone.Interfaces
{
    public interface IApi
    {
        [Get("/map/style")]
        Task<MapStyleModel> GetMapStyle();

        [Get("/map/pins")]
        Task<IList<PlaceModel>> GetPlaces();
    }
}
