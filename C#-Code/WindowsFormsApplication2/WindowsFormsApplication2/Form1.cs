using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
        }


        private void Button2_Click(object sender, EventArgs e)
        {

            progressBarDashboardMain.Value = (0);
            timer1.Start();
           

            

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            //Insert your Postman Client --> https://ussouthcentral.services.azureml.net/workspaces/ <-- your unique line here
            var client = new RestClient("https://ussouthcentral.services.azureml.net/workspaces/");
            var request = new RestRequest(Method.POST);
           
            //Insert Postman-token
            request.AddHeader("postman-token", "");
            request.AddHeader("cache-control", "no-cache");
           
            //Insert, "Bearer followed by your Microsoft Azures API Key 
            //For Example --> Bearer 35hsds359XZSX9sdsda3525== etc.
            request.AddHeader("authorization", "Bearer ");
            request.AddHeader("content-type", "application/json");
           
            //Below are the variables, make sure to insert your own 
            //For Example --> 'Variable': \"" + comboBox1.Text + "\",
            request.AddParameter("application/json", " INSERT YOUR POSTMAN BODY INTO THIS SECTION", ParameterType.RequestBody);

            //Data Pulled
            IRestResponse response = client.Execute(request);
            label1.Text = response.Content.ToString();
            progressBarDashboardMain.Increment(+1);


            if (progressBarDashboardMain.Value == 100)
            {
                
                timer1.Stop();
                //These are the results that show
                MessageBox.Show(label1.Text.ToString());
            }
        }
    }
}
//CoderRevolt :D 