namespace Currency_winform;
using System.Windows.Forms.DataVisualization.Charting;
public partial class Form1 : Form
{
    public Form1(Dictionary<int,double> data)
    {
        int i = 0;
        Chart chart = new Chart();
        chart.ChartAreas.Add(new ChartArea());
        for (i = 0; i < 20; i++)
        {
            chart.Series.Add($"Series {i}");
        }

        if (chart.Titles.Count == 0)
        {
            chart.Titles.Add("Курс Usd в сентябре 2024");
        }

        chart.Series[0].ChartType = SeriesChartType.Column;
        chart.Size = new Size(1920,1080);

        i = 0;
        foreach (var pair in data)
        {
            chart.Series[i].Points.AddXY(pair.Key, pair.Value);
            chart.Series[i].IsValueShownAsLabel = true;
            i++;
        }

        
        this.Controls.Add(chart);
        chart.Show();
    }
}
