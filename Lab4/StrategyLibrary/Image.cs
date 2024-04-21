using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyLibrary
{
    public class Image
    {
        private IImageLoadStrategy _loadStrategy;
        public string Source { get; private set; }

        public Image(string source)
        {
            Source = source;
            _loadStrategy = DetermineStrategy(source);
        }

        private IImageLoadStrategy DetermineStrategy(string source)
        {
            return source.StartsWith("http") ? (IImageLoadStrategy)new NetworkImageLoadStrategy() : new LocalImageLoadStrategy();
        }

        public async Task LoadImageAsync()
        {
            var imageData = await _loadStrategy.LoadImageAsync(Source);
            Console.WriteLine($"Image loaded with {imageData.Length} bytes from {Source}");
        }
    }

}
