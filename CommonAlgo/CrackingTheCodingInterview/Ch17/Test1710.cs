using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace CommonAlgo.CrackingTheCodingInterview.Ch17
{
    /// <summary>
    ///     Since XML is very verbose, you are given a way of encoding it where each tag gets
    ///     mapped to a pre-defined integer value.
    /// </summary>
    public class Test1710
    {
        [TestCase]
        public void Test()
        {
            var root = new Element {Value = "root"};
            string encodetoString = EncodetoString(root);
            Console.WriteLine(encodetoString);
        }

        private void Encode(StringBuilder sb, string s)
        {
            sb.Append(s);
            sb.Append(" ");
        }

        private void Encode(StringBuilder sb, Attribute a)
        {
            Encode(sb, a.GetNameCode());
            Encode(sb, a.Value);
        }

        private void Encode(StringBuilder sb, Element root)
        {
            Encode(sb, root.GetNameCode());
            foreach (Attribute attribute in root.Attributes)
            {
                Encode(sb, attribute);
            }
            Encode(sb, "0");
            if (!string.IsNullOrEmpty(root.Value))
            {
                Encode(sb, root.Value);
            }
            else
            {
                foreach (Element element in root.Children)
                {
                    Encode(sb, element);
                }
            }
            Encode(sb, "0");
        }

        private string EncodetoString(Element root)
        {
            var sb = new StringBuilder();
            Encode(sb, root);
            return sb.ToString();
        }
    }

    public class Element : XmlElement
    {
        public Element()
        {
            Attributes = new List<Attribute>();
            Children = new List<Element>();
        }

        protected override ElementType Type
        {
            get { return ElementType.Element; }
            set { }
        }

        public List<Attribute> Attributes { get; set; }
        public IEnumerable<Element> Children { get; set; }
    }

    public class Attribute : XmlElement
    {
        #region Overrides of XmlElement

        protected override ElementType Type
        {
            get { return ElementType.Attribute; }
            set { }
        }

        #endregion
    }

    public class XmlElement
    {
        protected virtual ElementType Type { get; set; }

        public string Value { get; set; }

        public string GetNameCode()
        {
            switch (Type)
            {
                case ElementType.Element:
                    return "1";
                case ElementType.Attribute:
                    return "4";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    public enum ElementType
    {
        Element,
        Attribute
    }
}