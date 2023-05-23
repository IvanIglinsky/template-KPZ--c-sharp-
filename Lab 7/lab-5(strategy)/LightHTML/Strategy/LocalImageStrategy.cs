using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_5.LightHTML.Strategy
{
    public class LocalImageStrategy : IImageStrategy
    {
        public Task<byte[]> LoadImage(string href)
        {
            return File.ReadAllBytesAsync(href);
        }
    }
}
