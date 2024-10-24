using System.Text;

namespace Currency_winform;

public class Curs
{
    private Parser Parser { get; set; }

    async public Task<Dictionary<int,double>> GetCursOnDate(int vcode, HttpClient client)
    {
        var action = "http://web.cbr.ru/GetCursOnDate";
        var curses = new Dictionary<int, double>();
        for (int i = 10; i < 30; i++)
        {
            var date = $"2024-09-{i}";
            StringContent content = new StringContent(
                $@"<?xml version='1.0' encoding='utf-8'?>
                    <soap:Envelope xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema' xmlns:soap='http://schemas.xmlsoap.org/soap/envelope/'>
                      <soap:Body>
                        <GetCursOnDate xmlns='http://web.cbr.ru/'>
                          <On_date>{date}</On_date>
                        </GetCursOnDate>
                      </soap:Body>
                    </soap:Envelope>",
                Encoding.UTF8,
                "text/xml");
            content.Headers.Add("SOAPAction", action);
            content.Headers.Add("Content-Lenght", content.ToString());
                
            var response = await client.PostAsync(client.BaseAddress, content);
            var answer = await response.Content.ReadAsStringAsync();
            this.Parser = new Parser(answer, vcode);
            curses.Add(i,this.Parser.Parse());
        }

        return curses;
    }
}