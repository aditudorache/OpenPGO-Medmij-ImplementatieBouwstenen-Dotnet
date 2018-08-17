// Copyright (c) Zorgdoc.  All Rights Reserved.  Licensed under the AGPLv3.

namespace MedMij
{
    using System;
    using System.Reflection;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Schema;

    internal static class XMLUtils
    {
        static readonly Assembly assembly = typeof(Whitelist).Assembly;

        public static XmlSchemaSet SchemaSetFromResource(string name, XNamespace ns)
        {
            var resourcename = $"MedMij.{name}";
            var resource = assembly.GetManifestResourceStream(resourcename);
            if (resource == null)
            {
                throw new InvalidOperationException($"Resource {resourcename} not found.");
            }

            var schemareader = XmlReader.Create(resource);
            var schemas = new XmlSchemaSet();
            schemas.Add(ns.ToString(), schemareader);
            return schemas;
        }

        public static void Validate(XDocument doc, XmlSchemaSet schemas, XName rootname)
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