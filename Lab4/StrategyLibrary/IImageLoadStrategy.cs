using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyLibrary
{
    public interface IImageLoadStrategy
    {
        Task<byte[]> LoadImageAsync(string href);
    }
}
