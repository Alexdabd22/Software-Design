using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StrategyLibrary
{
    public class NetworkImageLoadStrategy : IImageLoadStrategy
    {
        public async Task<byte[]> LoadImageAsync(string href)
        {
            using (var httpClient = new HttpClient())
            {
                return await httpClient.GetByteArrayAsync(href);
            }
        }
    }

}
