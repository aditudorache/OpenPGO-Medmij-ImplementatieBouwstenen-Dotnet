// Copyright (c) Zorgdoc.  All rights reserved.  Licensed under the AGPLv3.

namespace MedMij
{
    using System;
    using System.Net.Http;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Schema;

    internal static class XMLUtils
    {
        internal static XmlSchemaSet SchemaSetFromResource(string name, XNamespace ns)
        {
            var resourcename = $"MedMij.{name}";
            var resource = typeof(XMLUtils).Assembly.GetManifestResourceStream(resourcename);
            if (resource == null)
            {
                throw new InvalidOperationException($"Resource {resourcename} not found.");
            }

            var schemareader = XmlReader.Create(resource);
            var schemas = new XmlSchemaSet();
            schemas.Add(ns.ToString(), schemareader);
            return schemas;
        }

        internal static void Validate(XDocument doc, XmlSchemaSet schemas, XName rootname)
        {
            doc.Validate(schemas, (a, b) => throw b.Exception);
            var root = doc.Element(rootname);

            if (root == null)
            {
                throw new XmlSchemaException($"Wrong root element: got {doc.Root.Name} expected {rootname}");
            }
        }
    }
}
