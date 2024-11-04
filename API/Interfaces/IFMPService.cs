using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Interfaces
{
    public interface IFMPService
    {
        Task<TShirt> FindTShirtByBrandAsync (string brand);
    }
}