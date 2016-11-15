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
        WeatherService2.WeatherServiceClient weatherService = new WeatherService2.WeatherServiceClient();
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
        YelpService2.StoreLocationServiceClient locationService = new YelpService2.StoreLocationServiceClient();
        string term = TextBox3.Text;
        string location = TextBox4.Text;
        string[] stores = locationService.QueryYelpAPI(term, location);
        for(int i = 0; i != stores.Length; i++)
        {
            Label3.Text += stores[i];
        }
    }

    protected void CheckInButton_Click(object sender, EventArgs e)
    {
        StoreCheckInService2.StoreCheckInServiceClient storecheckinservice = new StoreCheckInService2.StoreCheckInServiceClient();
        string storeName = StoreNameCheckInTextBox.Text;
        string location = StoreLocationCheckInTextBox.Text;
        storecheckinservice.CheckInToStore(storeName, location);
    }

    protected void ListStoresButton_Click(object sender, EventArgs e)
    {
        StoreCheckInService2.StoreCheckInServiceClient storecheckinservice = new StoreCheckInService2.StoreCheckInServiceClient();
        string[] places = storecheckinservice.getListofStores();
        for(int i = 0; i != places.Length; i++)
        {
            ListPlacesVisitedLabel.Text += places[i];
        }
    }

    protected void RatingButton_Click(object sender, EventArgs e)
    {
        StoreRatingService2.StoreRatingServiceClient storeRatingService = new StoreRatingService2.StoreRatingServiceClient();
        string storeName = StoreNameRatingTextBox.Text;
        string storeLocation = StoreLocationRatingTextBox.Text;
        string[] ratings = storeRatingService.QueryYelpAPI(storeName, storeLocation);
        for (int i = 0; i != ratings.Length; i++)
        {
            RatingLabel.Text += ratings[i];
        }
    }
}