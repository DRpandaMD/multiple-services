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
    
</asp:Content>
