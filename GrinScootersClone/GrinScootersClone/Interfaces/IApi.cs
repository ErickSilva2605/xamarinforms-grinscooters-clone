﻿using GrinScootersClone.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GrinScootersClone.Interfaces
{
    public interface IApi
    {
        [Get("/map/style")]
        Task<MapStyleModel> GetMapStyle();
    }
}