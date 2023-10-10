using HealthCareCovid.model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace HealthCareCovid.pages
{
    /// <summary>
    /// Logique d'interaction pour AvailableStructureDose.xaml
    /// </summary>
    public partial class AvailableStructureDose : Page
    {
        List<Healthcare> healthCares;
        public AvailableStructureDose()
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
                var filteredHealthCares = healthCares.Where(healthCare => (bool)!healthCare.vaccineavailability || (bool)!healthCare.testavailability).ToList();
                datagrid.ItemsSource = filteredHealthCares;
            }
        }

    }
}
