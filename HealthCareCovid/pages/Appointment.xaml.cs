using HealthCareCovid.model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Net;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using DocumentFormat.OpenXml;

namespace HealthCareCovid.pages
{
    /// <summary>
    /// Logique d'interaction pour Appointment.xaml
    /// </summary>
    public partial class Appointment : Page
    {
        List<Healthcare> healthCares;

        public Appointment()
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
                HealthCareItems.ItemsSource = healthCares;
            }
        }

        public async void postAppointment(model.Appointment appointment)
        {
            using (var client = new HttpClient())
            {
                var url = $"http://localhost:8080/appointment";

                string jsonData = JsonConvert.SerializeObject(appointment);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);
                if (!response.IsSuccessStatusCode)
                    throw new Exception();
            }
        }

        private void addAppointment_Click(object sender, RoutedEventArgs e)
        {
            if(isValid())
            {
                model.Appointment appointment = new model.Appointment();
                appointment.date = (DateTime)date.SelectedDate; ; 
                appointment.notes = notes.Text;
                appointment.healthcare = new Healthcare();
                int healthcareid = Int16.Parse(HealthCareItems.SelectedValue.ToString());
                appointment.healthcare.healthcareid = healthcareid;
                appointment.doseType = doseType.Text.ToString();
                postAppointment(appointment);
                System.Windows.MessageBox.Show("Enregistré");
            }
        }

        public Boolean isValid()
        {
            if (HealthCareItems.SelectedValue == null)
            {
                System.Windows.MessageBox.Show("Veuillez selectionner une structure de santé");
                return false;
            }
            if (doseType.SelectedValue == null)
            {
                System.Windows.MessageBox.Show("Veuillez selectionner un DoseType");
                return false;
            }
            if(date.SelectedDate == null)
            {
                System.Windows.MessageBox.Show("Veuillez selectionner une date");
                return false;
            }
            return true;
        }
    }
}
