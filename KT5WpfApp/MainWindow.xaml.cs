using Kt5WCF;
using LiveCharts.Wpf;
using LiveCharts;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using LiveCharts.Wpf.Charts.Base;
namespace KT5WpfApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<OrderStatus> OrderStatuses { get; set; }
        public SeriesCollection PieSeriesCollection { get; set; }
        public ObservableCollection<LineSeries> LineSeriesCollection { get; set; }
        public SeriesCollection ColumnSeriesCollection { get; set; }
        public ChartValues<int> SecondColumnSeriesValues { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            OrderStatuses = new ObservableCollection<OrderStatus>();
            PieSeriesCollection = new SeriesCollection(); // Инициализируем PieSeriesCollection
            LineSeriesCollection = new ObservableCollection<LineSeries>();
            SecondColumnSeriesValues = new ChartValues<int>();
            LoadOrderStatuses();
        }

        private void LoadOrderStatuses()
        {

            ColumnSeriesCollection = new SeriesCollection();

            var client = new OrderService();
            var statuses = client.GetOrderStatuses();
            OrderStatuses.Clear();
            foreach (var status in statuses)
            {
                OrderStatuses.Add(status);
            }

            // Очищаем и затем обновляем данные для круговой диаграммы
            PieSeriesCollection.Clear();
            foreach (var status in OrderStatuses)
            {
                PieSeriesCollection.Add(new PieSeries
                {
                    Title = status.Status,
                    Values = new ChartValues<int> { status.Count },
                    DataLabels = true
                });
                LineSeriesCollection.Add(new LineSeries
                {
                    Title = status.Status,
                    Values = new ChartValues<int> { status.Count },
                   
                }); 
                ColumnSeries mySeries = new ColumnSeries
                {
                    Title = status.Status,
                    Values = new ChartValues<int> { status.Count },
                    DataLabels = true,
                  
                };
                SecondColumnSeriesValues.Add(status.Count);
                ColumnSeriesCollection.Add(mySeries);
            }
            myChart.Series = ColumnSeriesCollection;
            // Установка коллекции данных для столбчатой диаграммы
            //myChart.Series = ColumnSeriesCollection;
            DataContext = this;

        }
    }
}
