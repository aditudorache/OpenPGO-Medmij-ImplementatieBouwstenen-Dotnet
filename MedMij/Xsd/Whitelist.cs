﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;

// 
// This source code was auto-generated by xsd, Version=4.6.1055.0.
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(Namespace="xmlns://afsprakenstelsel.medmij.nl/whitelist/release2/")]
[System.Xml.Serialization.XmlRootAttribute(Namespace="xmlns://afsprakenstelsel.medmij.nl/whitelist/release2/", IsNullable=false)]
public partial class Whitelist {
    
    private System.DateTime tijdstempelField;
    
    private string volgnummerField;
    
    private string[] medMijNodesField;
    
    /// <remarks/>
    public System.DateTime Tijdstempel {
        get {
            return this.tijdstempelField;
        }
        set {
            this.tijdstempelField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="positiveInteger")]
    public string Volgnummer {
        get {
            return this.volgnummerField;
        }
        set {
            this.volgnummerField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("MedMijNode", IsNullable=false)]
    public string[] MedMijNodes {
        get {
            return this.medMijNodesField;
        }
        set {
            this.medMijNodesField = value;
        }
    }
}