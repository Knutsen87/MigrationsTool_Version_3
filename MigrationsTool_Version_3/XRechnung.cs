using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace MigrationsTool_Version_3
{
    internal class XRechnung
    {
        internal void MakeXml(string filePath, List<string[]> varList)
        {
            // Falls die Datei nicht existiert - dann:
            if (!File.Exists(filePath))
            {
                //Wenn die varList Zählung 2 Elemente enthält - dann:
                if (varList.Count() == 2)
                {
                    /* Speichert die XML Datei im angegeben Pfad
                     * Die Liste ElementAt beginnt mit dem 2ten Eintrag.
                     * 0 Wäre die Kopfzeile - dies sagt nicht aus ob in unsere
                     * XML Datei Daten enthalten sind, sondern erst mit dem 
                     * zweiten Eintrag. 
                     */
                    var xw = XmlWriter.Create(filePath);
                    WriteXml(xw, varList.ElementAt(1));
                }
                /* Wenn die obigen IF-Anweisungen nicht durchgeführt werden können, 
                 * wird geprüft ob die Liste mehr als 2 Elemente enthält
                 */
                else if (varList.Count() > 2)
                {
                    /* Eine Schleife: Int Wert beträgt 1. Solange i gleich oder kleiner als
                     * die varList ist, wird i um jeweils 1 erhöht. So wird die Datei abgerufen
                     * und beim Speichern der Dateiname um den Wert 1 erhöht. Beim nächsten speichern
                     * dann um 2. Bsp.: Dateiname1, Dateiname2, Dateiname3 usw. 
                     */
                    for (var i = 1; i <= varList.Count(); i++)
                    {
                        var xw = XmlWriter.Create(filePath + i);
                        WriteXml(xw, varList.ElementAt(i));
                    }
                }
            }
        }

        private void WriteXml(XmlWriter xw, string[] content)
        {
            xw.WriteStartDocument();
            xw.WriteStartElement("Test");

            xw.WriteStartElement(content[0]);
            xw.WriteAttributeString(content[1], content[2]);
            xw.WriteEndElement();

            xw.WriteEndElement();
            xw.WriteEndDocument();
        }

        private void addInvoice(string[] arr, XmlWriter xw)
        {
            xw.WriteStartElement("ubl:Invoice");
            xw.WriteStartAttribute("xmlns:ubl","urn:oasis:names:specification:ubl:schema:xsd:Invoice-2");
            xw.WriteStartAttribute("xmlns:cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");
            xw.WriteStartAttribute("xmnls:cbc","urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
            xw.WriteStartAttribute("xmnls:xsi", "http://www.w3.org/2001/XMLSchema-instance");
            xw.WriteStartAttribute("xsi:schemaLocation", "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2 http://docs.oasis-open.org/ubl/os-UBL-2.1/xsd/maindoc/UBL-Invoice-2.1.xsd");
            xw.WriteEndElement();
            
            xw.WriteStartElement("cbc:CustomizationID");
            xw.WriteString("urn:cen.eu:en16931:2017#compliant#urn:xoev-de:kosit:standard:xrechnung_1.2");
            xw.WriteEndElement();
            
            xw.WriteStartElement("cbc:ProfileID");
            xw.WriteString("XRechnung 1.2");
            xw.WriteEndElement();
            
            xw.WriteStartElement("cbc:ID");
            xw.WriteString("Re10001"); // Invoice Number
            xw.WriteEndElement();
            
            xw.WriteStartElement("cbc:IssueDate");
            xw.WriteString("2020-11-01"); // Invoice Date
            xw.WriteEndElement();
            
            xw.WriteStartElement("cbc:DueDate");
            xw.WriteString("2020-11-15"); // Due Date of payment
            xw.WriteEndElement();
            
            xw.WriteStartElement("cbc:InvoiceTypeCode");
            xw.WriteString("380"); // a code
            xw.WriteEndElement();
            
            xw.WriteStartElement("cbc:Note");
            xw.WriteString("AdditionalInvoiceText"); // additional text of invoice = Booking additional text
            xw.WriteEndElement();
            
            xw.WriteStartElement("cbc:DocumentCurrencyCode");
            xw.WriteString("EUR");
            xw.WriteEndElement();
            
            xw.WriteStartElement("cdc:TaxCurrencyCode");
            xw.WriteString("EUR");
            xw.WriteEndElement();
            
            xw.WriteStartElement("cdc:BuyerReference");
            xw.WriteString("04011000-12345 12345-35"); // LeitwegId
            xw.WriteEndElement();
            
            xw.WriteStartElement("cac:OrderReference"); 
            xw.WriteStartElement("cbc:ID");
            xw.WriteString("OrderNumber345678"); // additional text of invoice = Booking additional text
            xw.WriteEndElement();
            xw.WriteEndElement();

            xw.WriteStartElement("cac:ContractDocumentReference");
            xw.WriteStartElement("cbc:ID");
            xw.WriteString("Contract123456"); // additional text of invoice = Booking additional text
            xw.WriteEndElement();
            xw.WriteEndElement();
            
            xw.WriteStartElement("cac:ProjectReference");
            xw.WriteStartElement("cbc:ID");
            xw.WriteString("Project123456"); // additional text of invoice = Booking additional text
            xw.WriteEndElement();
            xw.WriteEndElement();
        }
        
        
        
    }
}