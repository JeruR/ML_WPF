using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
using API_for_footbal;
using CsvHelper;
using CsvHelper.Configuration;
using Footbal_predict;
using ML_WPF.Class;

namespace ML_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      
        public MainWindow()
        {
            InitializeComponent();
            StateChanged += MainWindowStateChangeRaised;

            //Test();
            Confg();
        }
        #region Load
        #region variable

        private static string _pathData_A = @"File\dane_a.csv";
        private static string _pathData_H = @"File\dane_h.csv";
        private static string _pathData_f = @"File\dane.csv";
        static List<CsvFull> csvFullsList = new List<CsvFull>();
        static List<Csv> csv_a_List = new List<Csv>();
        static List<Csv> csv_h_List = new List<Csv>();
        static PredictModel model = new PredictModel();
        #endregion
        #region ChromeCommans

        // Can execute
        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        // Minimize
        private void CommandBinding_Executed_Minimize(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.MinimizeWindow(this);
        }

        // Maximize
        private void CommandBinding_Executed_Maximize(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.MaximizeWindow(this);
        }

        // Restore
        private void CommandBinding_Executed_Restore(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.RestoreWindow(this);
        }

        // Close
        private void CommandBinding_Executed_Close(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.CloseWindow(this);
        }

        // State change
        private void MainWindowStateChangeRaised(object sender, EventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                MainWindowBorder.BorderThickness = new Thickness(8);
                RestoreButton.Visibility = Visibility.Visible;
                MaximizeButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                MainWindowBorder.BorderThickness = new Thickness(0);
                RestoreButton.Visibility = Visibility.Collapsed;
                MaximizeButton.Visibility = Visibility.Visible;
            }
        }
        #endregion
        #region MenuClick
        private void Wersja_Click(object sender, RoutedEventArgs e)
        {

            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            MessageBox.Show("Wersja programu: " + version);
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion
        private void drop_csvFullsList()
        {
            View_team_home.Items.Clear();
            View_team_home.Items.Insert(0, "");
            int id = 0;
            foreach (var item in csvFullsList.OrderBy(x => x.HomeTeam).DistinctBy(x=>x.HomeTeam))
            {
                View_team_home.Items.Insert(id, item.HomeTeam);
                id++;
            }
            View_team_away.Items.Clear();
            View_team_away.Items.Insert(0, "");
            id = 0;
            foreach (var item in csvFullsList.OrderBy(x => x.AwayTeam).DistinctBy(x => x.AwayTeam))
            {
                View_team_away.Items.Insert(id, item.AwayTeam);
                id++;
            }
            view_referee.Items.Clear();
            view_referee.Items.Insert(0, "");
            id = 0;
            foreach (var item in csvFullsList.OrderBy(x => x.Referee).DistinctBy(x => x.Referee))
            {
                view_referee.Items.Insert(id, item.Referee);
                id++;
            }
           
        }
        private void Confg()
        {
            ReadCSV(_pathData_H, 2);
            ReadCSV(_pathData_A, 1);
            ReadCSV(_pathData_f, 0);
            drop_csvFullsList();
            drop_csvFullsList();
            drop_csvFullsList();

        }
        private void ReadCSV(string path, int value)
        {
            try
            {
                var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = false,
                };
                using (var reader = new StreamReader(path))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    if (value == 2)
                    {
                        csv.Context.RegisterClassMap<CsvMap>();
                        var records = csv.GetRecords<Csv>();
                        csv_h_List = records.ToList();
                    }
                    else if (value == 1)
                    {
                        csv.Context.RegisterClassMap<CsvMap>();
                        var records = csv.GetRecords<Csv>();
                        csv_a_List = records.ToList();
                    }
                    else
                    {
                        csv.Context.RegisterClassMap<CsvFullMap>();
                        var records = csv.GetRecords<CsvFull>();
                        csvFullsList = records.ToList();

                        //MessageBox.Show(records.Count().ToString());
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

               // throw;
            }
        }
        #endregion

        private void Test()
        {
            MLModel1.ModelInput sampleData = new MLModel1.ModelInput()
            {
                Date = @"13/08/16",
                HomeTeam = @"Crystal Palace",
                AwayTeam = @"West Brom",
                FTHG = 0F,
                FTAG = 1F,
                Referee = @"C Pawson",
                HS = 14F,
                AS = 13F,
            };

            // Make a single prediction on the sample data and print results
            var predictionResult = MLModel1.Predict(sampleData);

            Console.WriteLine("Using model to make single prediction -- Comparing actual FTR with predicted FTR from sample data...\n\n");


            Console.WriteLine($"Date: {@"13/08/16"}");
            Console.WriteLine($"HomeTeam: {@"Crystal Palace"}");
            Console.WriteLine($"AwayTeam: {@"West Brom"}");
            Console.WriteLine($"FTHG: {0F}");
            Console.WriteLine($"FTAG: {1F}");
            Console.WriteLine($"FTR: {@"A"}");
            Console.WriteLine($"Referee: {@"C Pawson"}");
            Console.WriteLine($"HS: {14F}");
            Console.WriteLine($"AS: {13F}");


            Console.WriteLine($"\n\nPredicted FTR: {predictionResult.PredictedLabel}\n\n");
            Console.WriteLine("=============== End of process, hit any key to finish ===============");
            Console.ReadKey();


        }
        private void PredictModel1(string value, string value2)
        {
            MLModel1.ModelInput sampleData = new MLModel1.ModelInput()
            {
                Date = view_date.SelectedDate.ToString(),
                HomeTeam = View_team_home.SelectedValue.ToString(),
                AwayTeam = View_team_away.SelectedValue.ToString(),
                FTHG = float.Parse(value),
                FTAG = float.Parse(value2),
                Referee = view_referee.SelectedValue.ToString(),
                HS = float.Parse(view_home_s.Text),
                AS = float.Parse(view_away_s.Text),
            };

            var predictionResult = MLModel1.Predict(sampleData);
            model.PredictedLabel_1= predictionResult.PredictedLabel.ToString();
            model.PredictedResult_1 = predictionResult.Score;
        }
        private void PredictModel2()
        {
            MLModel2.ModelInput sampleData = new MLModel2.ModelInput()
            {
                Date = view_date.SelectedDate.ToString(),
                HomeTeam = View_team_home.SelectedValue.ToString(),
                AwayTeam = View_team_away.SelectedValue.ToString(),
                Referee = view_referee.SelectedValue.ToString(),
                HS = float.Parse(view_home_s.Text),
                AS = float.Parse(view_away_s.Text),
            };

            var predictionResult = MLModel2.Predict(sampleData);
            model.PredictedLabel_2 = predictionResult.PredictedLabel.ToString();
            model.PredictedResult_2 = predictionResult.Score;
        }
        private void PredictModel3()
        {
            MLModel_3_H.ModelInput sampleData = new MLModel_3_H.ModelInput()
            {
                Date = view_date.SelectedDate.ToString(),
                HomeTeam = View_team_home.SelectedValue.ToString(),
                AwayTeam = View_team_away.SelectedValue.ToString(),
                HS = float.Parse(view_home_s.Text),
                AS = float.Parse(view_away_s.Text),
            };

            var predictionResult = MLModel_3_H.Predict(sampleData);
            model.PredictedLabel_3 = predictionResult.PredictedLabel.ToString();
            model.PredictedResult_3 = predictionResult.Score;

        }
        private void PredictModel4()
        {
            MLModel_4_A.ModelInput sampleData = new MLModel_4_A.ModelInput()
            {
                Date = view_date.SelectedDate.ToString(),
                HomeTeam = View_team_home.SelectedValue.ToString(),
                AwayTeam = View_team_away.SelectedValue.ToString(),
                HS = float.Parse(view_home_s.Text),
                AS = float.Parse(view_away_s.Text),
            };

            var predictionResult = MLModel_4_A.Predict(sampleData);
            model.PredictedLabel_4 = predictionResult.PredictedLabel.ToString();
            model.PredictedResult_4 = predictionResult.Score;
        }

        private void TryIt(object sender, RoutedEventArgs e)
        {
            model = new PredictModel();
            try
            {
                bool resu = false;
                if (View_team_home.SelectedValue == null || View_team_away.SelectedValue == null || view_away_s.Text == "" || view_date.SelectedDate == null || view_home_s.Text == "" || view_referee.SelectedValue == null)
                {
                    resu = true;
                }


                if (resu == true)
                {
                    MessageBox.Show("Pola muszą zostać wypełnione!");
                }
                else
                {
                    PredictModel3();
                    PredictModel4();
                    PredictModel2();
                    PredictModel1(model.PredictedLabel_3,model.PredictedLabel_4);

                }
                MessageBox.Show
               ("Predykcja zwycięscy bez goli: " + GetFullName(model.PredictedLabel_2) + Environment.NewLine +
                "Predykcja liczby goli dla gospodarzy: " + model.PredictedLabel_3 + Environment.NewLine +
                "Predykcja liczby goli dla gości: " + model.PredictedLabel_4 + Environment.NewLine +
                "Predykcja zwycięzcy z predykcją goli: " + GetFullName(model.PredictedLabel_1) + Environment.NewLine
               );
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private string GetFullName(string value)
        {
            if (value == "H")
            {
                return "Gospodarz";
            }
            else if (value == "A")
            {
                return "Gość";

            }
            else
            {
                return "Remis";
            }
        }

    }
    
}
