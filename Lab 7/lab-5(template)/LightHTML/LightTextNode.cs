﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace lab_5.LightHTML
{
    public class LightTextNode : LightNode
    {
        public string? Text { get; set; }
        public LightTextNode(string tag, string text)
        {
            Tag = tag;
            Text = text;
            Lifecycle();
        }
        public LightTextNode(string tag)
        {
            Tag = tag;
        }

        public override string InnerHTML()
        {
            return Text;
        }

        public override string OuterHTML()

        {
            return $"<{Tag}>{Text}</{Tag}>";
        }

        public override LightNode Clone()
        {
            return new LightTextNode(Tag, Text);
        }
        public override void OnCreated()
        {
            Console.WriteLine("Text node created");
        }
        public override void OnInserted()
        {
            Console.WriteLine("Text node inserted");
        }
    }
}
