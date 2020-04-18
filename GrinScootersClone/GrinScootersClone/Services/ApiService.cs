using GrinScootersClone.Interfaces;
using GrinScootersClone.Models;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrinScootersClone.Services
{
    public class ApiService : IApi
    {
        #region Fields

        private static ApiService _instance;
        public static ApiService Instance = _instance ?? (_instance = new ApiService());
        private readonly IApi _api;

        #endregion

        #region Constructors

        private ApiService()
        {
            _api = RestService.For<IApi>("https://grinclone.getsandbox.com");
        }

        #endregion

        #region Methods

        public async Task<MapStyleModel> GetMapStyle()
        {
            return await _api.GetMapStyle();
        }

        public async Task<IList<PlaceModel>> GetPlaces()
        {
            return await _api.GetPlaces();
        }

        public async Task<WalletModel> GetWallet()
        {
            return await _api.GetWallet();
        }


        #endregion
    }
}
