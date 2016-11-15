<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>TryIt Web App</h1>
    <br />
    
    <h4> Weather Service </h4>
    <br />
    <p>
        This serivce takes in a zipcode and give the location area and 5 day forcast <br />
        WSDL URL: http://localhost:39575/_weatherservice.svc?singleWsdl
    </p>
    Method Names:
    <ul>
        <li>public string getLocation(string zipcode)</li>
        <li>public List string getForcast(string zipcode, string units)</li>
        <li>public Tuple double,double getLatAndLong(string zipcode)</li>

    </ul>
    <p>
        Find the local weather!<br />
        Enter in the zipcode you want the weather for: 
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
        Enter in the Units([case sensitive] imperial or  metric):
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox> <br /> 
        <asp:Button ID="Button1" runat="server" Text="Get Weather" OnClick="Button1_Click" />
        <br />
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <br />
        <br />
        FOR The Area OF: 
        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
    </p>
    <br />
    <h4> Store Location Service </h4>
    <p>
        This service takes in a search term and a location name eg (wine, Tempe) <br />
        WSDL URL: http://localhost:42943/_StoreLocationService.svc?singleWsdl<br />
        It only has One Method!: public List string QueryYelpAPI(string term, string location)
    </p>
    <p>
        Find the 5 closest stores for specific type of shopping or dining you want <br />
        Enter in term:   
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox><br />
        Enter in the location:  
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox><br />
        <asp:Button ID="Button2" runat="server" Text="Get Stores" OnClick="Button2_Click" />
        <br />
    </p>
    <p>
        The top 5 stores are:   
        <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
    </p>

    <h4>Store Check-In Service </h4>
    <p>
        This serivce takes in a Store Name and its Location eg (Tempe, AZ or zipcode)<br />
        WSDL URL: http://localhost:61373/_StoreCheckInService.svc?wsdl
    </p>
    <p>
        Keep track of which stores you've visted by checking in: <br />
        Store Name: <asp:TextBox ID="StoreNameCheckInTextBox" runat="server"></asp:TextBox><br />
        Store Location: 
        <asp:TextBox ID="StoreLocationCheckInTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="CheckInButton" runat="server" Text="CheckIn" OnClick="CheckInButton_Click" /><br />
        <br />
        Lets see where you have been!!   


        <asp:Button ID="ListStoresButton" runat="server" Text="List Stores" OnClick="ListStoresButton_Click" /><br />
        <br />
        Visited Stores are: 

        <asp:Label ID="ListPlacesVisitedLabel" runat="server" Text="Label"></asp:Label>

    </p>
    <br />
    <h4>Store Rating Service </h4>
    <p>
        This Service takes in a store name and a location and returns the ratings of that store<br />
        WSDL URL: http://localhost:25413/StoreRatingService.svc?wsdl
    </p>
    <p>
        Enter in a store and location you want to see the rating of:  <br />
        Store Name:<asp:TextBox ID="StoreNameRatingTextBox" runat="server"></asp:TextBox><br />
        Store Location:<asp:TextBox ID="StoreLocationRatingTextBox" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="RatingButton" runat="server" Text="GetRating" OnClick="RatingButton_Click" />
        <br />

    </p>
    <p>
        The Store ratings are: 
        <asp:Label ID="RatingLabel" runat="server" Text=""></asp:Label>
    </p>

    
</asp:Content>
