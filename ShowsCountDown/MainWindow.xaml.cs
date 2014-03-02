using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Timers;

namespace ShowsCountDown
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool inDrag = false;
        Point anchorPoint;
        List<ShowData> showsDB;
        public MainWindow()
        {
            InitializeComponent();
            showsDB = new List<ShowData>();
            this.ShowInTaskbar = false;
            showWindow.Title = "";

            setupHeaders();
            fromBin();
            populateGrid();

            setupUpdateTimer();

        }

        private void runUpdate(object source, ElapsedEventArgs e)
        {
            foreach (var show in showsDB)
            {
                if (show.NextAiring.AddHours(-24) >= DateTime.Now)
                {
                    Search updateSearch = new Search(show.Show);
                    show.NextAiring = updateSearch.nextShowingDateTime();
                    show.Last24Hours = updateSearch.last24Hours();
                }
            }
        }

        private void setupUpdateTimer()
        {
            Timer updateTimer = new System.Timers.Timer(3600000);
            updateTimer.Elapsed += new ElapsedEventHandler(runUpdate);

        }

        private void setupHeaders()
        {
            DataGridTextColumn c1 = new DataGridTextColumn();
            c1.Header = "Show";
            c1.Binding = new Binding("Show");
            c1.Width = 110;
            showGrid.Columns.Add(c1);
            DataGridTextColumn c2 = new DataGridTextColumn();
            c2.Header = "Last 24Hrs";
            c2.Width = 110;
            c2.Binding = new Binding("Last24Hours");
            showGrid.Columns.Add(c2);
            DataGridTextColumn c3 = new DataGridTextColumn();
            c3.Header = "Next Airing";
            c3.Width = 110;
            c3.Binding = new Binding("NextAiring");
            showGrid.Columns.Add(c3);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void populateGrid()
        {
            if (showsDB == null)
                return;

            foreach (var showData in showsDB)
            {
                showGrid.Items.Add(showData);
            }
        }

        private void RemoveShowClick(object sender, RoutedEventArgs e)
        {
            if (showGrid.Items.Count > 0)
                showGrid.Items.RemoveAt(0);
        }


        private void HandleAddShowFormButtonClicked(object sender)
        {
            AddShowForm form = (AddShowForm)sender;

            string showToAdd = form.getSelectedShow();

            Search searchForShow = new Search(showToAdd);
            var foundShow = showsDB.Find(show => show.Show == showToAdd);

            if (foundShow != null)
            {
                form.Close();
                return;
            }

            ShowData newItem = new ShowData(showToAdd, searchForShow.last24Hours(), searchForShow.nextShowingDateTime());
            showGrid.Items.Add(newItem);
            showsDB.Add(newItem);

            toBin();

        }

        private void AddItemClick(object sender, RoutedEventArgs e)
        {
            AddShowForm addShowForm = new AddShowForm();
            addShowForm.ThrowEvent += (_sender, args) => { HandleAddShowFormButtonClicked(_sender); };
            addShowForm.Show();

        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            anchorPoint = PointToScreen(e.GetPosition(this));
            inDrag = true;
            CaptureMouse();
            e.Handled = true;
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            if (inDrag)
            {
                Point currentPoint = PointToScreen(e.GetPosition(this));
                this.Left = this.Left + currentPoint.X - anchorPoint.X;
                this.Top = this.Top + currentPoint.Y - anchorPoint.Y;
                anchorPoint = currentPoint;
            }
        }

        private void Grid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (inDrag)
            {
                ReleaseMouseCapture();
                inDrag = false;
                e.Handled = true;
            }
        }

        private void showWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void toBin()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<ShowData>));
            TextWriter textWriter = new StreamWriter("XMLSerilazermovie.xml");
            serializer.Serialize(textWriter, showsDB);
            textWriter.Close();


            try
            {
                using (Stream stream = File.Open("shows.bin", FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, showsDB);
                }
            }
            catch (IOException)
            {
            }
        }

        private void fromBin()
        {
            try
            {
                using (Stream stream = File.Open("shows.bin", FileMode.Open))
                {
                    BinaryFormatter binFormater = new BinaryFormatter();
                    showsDB = (List<ShowData>)binFormater.Deserialize(stream);
                }
            }
            catch(System.IO.FileNotFoundException)
            {
            }
        }
    }

    [Serializable()]
    public class ShowData
    {
        private string _show;
        private bool _last24Hours;
        private DateTime _nextAiring;

        public ShowData()
        {

        }

        public ShowData (string show, bool last24Hours, DateTime nextAiring)
        {
            _show = show;
            _last24Hours = last24Hours;
            _nextAiring = nextAiring;
        }

        public string Show
        {
            get { return _show;  }
            set { _show = value; }
        }

        public bool Last24Hours
        {
            get { return _last24Hours; }
            set { _last24Hours = value; }
        }

        public DateTime NextAiring
        {
            get { return _nextAiring; }
            set { _nextAiring = value; }
        }

    }
}
