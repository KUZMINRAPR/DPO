namespace Currency_winform;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Drawing;

static class Program
{

    [STAThread]
    static async Task Main()
    {
        HttpClient client = new()
        {
            BaseAddress = new Uri("https://www.cbr.ru/DailyInfoWebServ/DailyInfo.asmx")
        };

        Curs curs = new Curs();

        var data = await curs.GetCursOnDate(840,client);
        foreach (var elem in data)
        {
            Console.WriteLine(elem);
        }
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1(data));

    }
}