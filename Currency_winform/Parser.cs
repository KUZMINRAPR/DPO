using System.Xml;
using System.Xml.Linq;

namespace Currency_winform;

public class Parser
{
    private string Xml { get; set; }
    private int Vcode { get; set; }

    public Parser(string xml, int vcode)
    {
        this.Xml = xml;
        this.Vcode = vcode;
    }
    public double Parse()
    {
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(this.Xml);
        XDocument xdoc = XDocument.Parse(doc.OuterXml);

        var elements = from element in xdoc.Elements()
            select element;

        var curs = from valute in elements.Descendants("ValuteCursOnDate")
            where (int)valute.Element("Vcode") == this.Vcode
            select valute;
        foreach (var valute in curs)
        {
            return (double)valute.Element("Vcurs");
        }

        return 0;
    }
}
