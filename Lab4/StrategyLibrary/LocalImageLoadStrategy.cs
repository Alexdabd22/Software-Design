using System;
using System.IO;
using System.Threading.Tasks;

namespace StrategyLibrary
{
    public class LocalImageLoadStrategy : IImageLoadStrategy
    {
        public async Task<byte[]> LoadImageAsync(string href)
        {
            using (var stream = new FileStream(href, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, true))
            {
                byte[] buffer = new byte[stream.Length];
                await stream.ReadAsync(buffer, 0, buffer.Length);
                return buffer;
            }
        }
    }
}
