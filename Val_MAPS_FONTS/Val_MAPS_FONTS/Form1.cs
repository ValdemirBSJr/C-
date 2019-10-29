using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Val_MAPS_FONTS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            StringBuilder mapa = new StringBuilder();


        mapa.Append("<html>");
   mapa.Append("<head>");
   mapa.Append("<title>Exibindo no Google Maps o endereço digitado</title>");
   mapa.Append("<script src='https://maps.googleapis.com/maps/api/js?key=SUA-CHAVE-DE-API&sensor=false'></script>");
    mapa.Append("</head>");
    mapa.Append("<body>");
            mapa.Append("<div id='map-canvas' style='width: 640px; height:480px'></div>");
           mapa.Append("<script>");
mapa.Append("var geocoder;");
mapa.Append("var map;");

mapa.Append("function initialize() {");
    mapa.Append("geocoder = new google.maps.Geocoder();");
    mapa.Append("var latlng = new google.maps.LatLng(-34.397, 150.644);");
    mapa.Append("var mapOptions = {");
        mapa.Append("zoom: 15,");
        mapa.Append("center: latlng,");
        mapa.Append("mapTypeId: google.maps.MapTypeId.ROADMAP");
    mapa.Append("}");

    mapa.Append("map = new         google.maps.Map(document.getElementById('map-canvas'), mapOptions);");
    mapa.Append("codeAddress();");
mapa.Append("}");
 
mapa.Append("function codeAddress() {");
   // mapa.Append("var address = '" + txtEndereco.Text + "';"); //Aqui vai o endereço

mapa.Append(" var address = 'Av. Atlântica, 1702 - Copacabana - Rio de Janeiro';");
    
    mapa.Append("geocoder.geocode( { 'address': address},     function(results, status) {");
       mapa.Append("if (status == google.maps.GeocoderStatus.OK) {");
            mapa.Append("map.setCenter(results[0].geometry.location);");
            mapa.Append("var marker = new google.maps.Marker({");
            mapa.Append("map: map,");
            mapa.Append("position: results[0].geometry.location");
        mapa.Append("});");
    mapa.Append("} else {");
        mapa.Append("alert('Geocode was not successful for the following reason: ' + status);");
  mapa.Append("  }");
    mapa.Append("});");
mapa.Append("}");
 
mapa.Append("google.maps.event.addDomListener(window, 'load', initialize);");

mapa.Append("</script>");



    mapa.Append("</body>");
    mapa.Append("</html>");
       

        }
    }
}
