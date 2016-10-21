using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;


public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        weatherservice.WeatherServiceClient weatherService = new weatherservice.WeatherServiceClient();
        string zipcode = TextBox1.Text;
        string units = TextBox2.Text;
        string[] forcast = weatherService.getForcast(zipcode, units);
        for(int i = 0; i != forcast.Length; i++)
        {
            Label1.Text += forcast[i];
        }

        Label2.Text = weatherService.getLocation(zipcode);
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        YelpService.StoreLocationServiceClient locationService = new YelpService.StoreLocationServiceClient();
        string term = TextBox3.Text;
        string location = TextBox4.Text;
        string[] stores = locationService.QueryYelpAPI(term, location);
        for(int i = 0; i != stores.Length; i++)
        {
            Label3.Text += stores[i];
        }
    }
}