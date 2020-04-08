﻿using GrinScootersClone.Interfaces;
using GrinScootersClone.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GrinScootersClone.Services
{
    public class ApiService : IApi
    {
        private static ApiService _instance;
        public static ApiService Instance = _instance ?? (_instance = new ApiService());
        private readonly IApi _api;
        private ApiService()
        {
            _api = RestService.For<IApi>("https://grinclone.getsandbox.com");
        }

        public async Task<MapStyleModel> GetMapStyle()
        {
            return await _api.GetMapStyle();
        }
    }
}