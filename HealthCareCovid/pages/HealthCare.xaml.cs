using HealthCareCovid.model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;

namespace HealthCareCovid.pages
{
    /// <summary>
    /// Logique d'interaction pour HealthCare.xaml
    /// </summary>
    /// 

    public partial class HealthCare : Page
    {
        List<Healthcare> healthCares;
        public HealthCare()
        {
            InitializeComponent();
            getAllHealthCare();
        }

        public async void getAllHealthCare()
        {
            using (var client = new HttpClient())
            {
                var url = $"http://localhost:8080/healthcares";

                HttpResponseMessage response = await client.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                    throw new Exception();
                string content = await response.Content.ReadAsStringAsync();
                healthCares = JsonConvert.DeserializeObject<List<Healthcare>>(content);
                datagrid.ItemsSource = healthCares;
            }
        }

        private void map_Click(object sender, RoutedEventArgs e)
        {
            Healthcare selectedRow = datagrid.SelectedItem as Healthcare;
            double latitude = Decimal.ToDouble(selectedRow.map.latitude);
            double longitude = Decimal.ToDouble(selectedRow.map.longitude);

            Map map = new Map(latitude, longitude);
            map.ShowDialog();
        }
    }
}

