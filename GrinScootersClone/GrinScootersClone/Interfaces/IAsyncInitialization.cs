using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GrinScootersClone.Interfaces
{
    public interface IAsyncInitialization
    {
        Task Initialization { get; }
    }
}
