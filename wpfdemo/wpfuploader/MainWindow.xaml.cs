using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Runtime.Caching;
using System.Windows.Controls;
using System.ComponentModel;
using Microsoft.Win32;

namespace wpfuploader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string pathoffile { get; set; }
        List<Patient> _list;
        public MainWindow()
        {
            InitializeComponent();
        }

        public void show1_Click(object sender, RoutedEventArgs e)
        {
           var patients = new List<Patient>();
           using (StreamReader reader = new StreamReader(pathoffile))
            {
                lable2.Content = "";
                if ((System.IO.Path.GetFileName(pathoffile)).Contains(".txt"))
                {
                    while (true)
                    {
                        string line = reader.ReadLine();
                        if (line == null)
                        { break; }
                        patients.Add(new Patient(line));
                    }
                    this._list = patients;
                    databind(patients);
                }
                else
                    lable2.Content = "Not a valid text file";
            }
        }
        private void databind(List<Patient> patients)
        {
            if (patients.Count > 0)
            {
                //var grid = sender as DataGrid;
                datagrid1.ItemsSource = patients;
            }
        }
        class Patient
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Code { get; set; }
            public int Insurance { get; set; }
            public Patient(string line)
            {
                string[] parts = line.Split(',');
                this.FirstName = parts[0];
                this.LastName = parts[1];
                this.Code = parts[2];
                this.Insurance = int.Parse(parts[3]);
            }
            public string GetLine()
            {
                return this.FirstName + "," + this.LastName + "," + this.Code + "," +
                    this.Insurance.ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();
            //Open the Pop-Up Window to select the file 
            if (dlg.ShowDialog() == true)
            {
                new FileInfo(dlg.FileName);
            }
            pathoffile = @dlg.FileName;
            if (@dlg.FileName.Length > 0)
            {
                lable1.Content = System.IO.Path.GetFileName(@dlg.FileName);
                show1.Visibility = System.Windows.Visibility.Visible;
            }
        }
    }
}
