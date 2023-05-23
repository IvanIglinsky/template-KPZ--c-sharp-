using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace lab_5.LightHTML.Strategy
{
    public class UrlImageStrategy : IImageStrategy
    {
        public async Task<byte[]> LoadImage(string href)
        {
            using (HttpClient client = new HttpClient())
            {
                var bytes = await client.GetByteArrayAsync(href);
                return bytes;
            }
        }
    }
}
