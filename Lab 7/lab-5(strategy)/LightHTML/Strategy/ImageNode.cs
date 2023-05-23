using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_5.LightHTML.Strategy
{
    public class ImageNode : LightNode
    {
        public IImageStrategy Strategy;
        private string _href;
        private byte[]? data;
        public string Href
        {
            get { return _href; }
            set
            {
                _href = value;
                setStrategy();
            }
        }
        public ImageNode(string href)
        {
            Tag = "img";
            _href = href;
            setStrategy();
        }
        private void setStrategy()
        {
            if (Uri.IsWellFormedUriString(_href, UriKind.Absolute))
            {
                Strategy = new UrlImageStrategy();
            }
            else
            {
                Strategy = new LocalImageStrategy();
            }
        }
        public async Task LoadImage()
        {
            if (_href != null)
            {
                data = await Strategy.LoadImage(_href);
                Console.WriteLine($"Loaded bytes: {data.Length}");
            }
        }

        public override LightNode Clone()
        {
            return new ImageNode(_href);
        }

        public override string InnerHTML()
        {
            return $"";
        }

        public override string OuterHTML()
        {
            return $"<{Tag} href=\"{_href}\"/>";
        }
    }
}
