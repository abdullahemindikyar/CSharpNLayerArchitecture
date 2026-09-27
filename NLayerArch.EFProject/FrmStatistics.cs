using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NLayerArch.EFProject
{
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }

        NLayerArchEFTravelDbEntities db = new NLayerArchEFTravelDbEntities();

        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            // Toplam Lokasyon Sayısı
            lblLocationCount.Text = db.TblLocation.Count().ToString();

            // Toplam Kapasite Sayısı
            lblSumCapacity.Text = db.TblLocation.Sum(x => x.LocationCapacity).ToString();

            // Toplam Rehber Sayısı
            lblGuideCount.Text = db.TblGuide.Count().ToString();

            // Bir Lokasyonda Ortalama Kapasite (Virgülden sonra 2 basamak)
            lblAverageCapacity.Text = db.TblLocation.Average(x => x.LocationCapacity)?.ToString("0.00");

            // Ortalama Tur Fiyatı (Virgülden sonra 2 basamak)
            lblAvrLocationPrice.Text = db.TblLocation.Average(x => x.LocationPrice)?.ToString("0.00");

            // Eklenen Son Ülke
            int lastCountryId = db.TblLocation.Max(x => x.LocationId);
            lblLastCountryName.Text = db.TblLocation.Where(x => x.LocationId == lastCountryId).Select(y => y.LocationCountry).FirstOrDefault();
            
            // Gaziantep'in Tur Kapasitesi
            lblGaziantepLocationCapacity.Text = db.TblLocation.Where(x => x.LocationCity == "Gaziantep").Select(y => y.LocationCapacity).FirstOrDefault().ToString();

            // Türkiye'nin Ortalama Tur Kapasitesi
            lblTurkiyeCapacityAvg.Text = db.TblLocation.Where(x => x.LocationCountry == "Türkiye").Average(y => y.LocationCapacity)?.ToString("0.00");

            // Roma Gezisinin Rehberinin Adı
            var romeGuideId = db.TblLocation.Where(x => x.LocationCity=="Roma").Select(y=> y.GuideId).FirstOrDefault();
            lblRomeGuideName.Text = db.TblGuide.Where(x => x.GuideId == romeGuideId).Select(y => y.GuideName + " " + y.GuideSurname).FirstOrDefault().ToString();

            // En Yüksek Kapasiteli Tur Lokasyonu
            var maxCapacity = db.TblLocation.Max(x => x.LocationCapacity);
            lblMaxCapacityLocation.Text = db.TblLocation.Where(x => x.LocationCapacity == maxCapacity).Select(y => y.LocationCity).FirstOrDefault().ToString();

            // En Pahalı Tur
            var maxPrice = db.TblLocation.Max(x => x.LocationPrice);
            lblMostPriceLocation.Text = db.TblLocation.Where(x => x.LocationPrice == maxPrice).Select(y => y.LocationCity).FirstOrDefault().ToString();

            // Adı Zeynep Dikyar olan Kişinin Rehber Olduğu Tur Lokasyonu
            var zeynepGuideId = db.TblGuide.Where(x => x.GuideName == "Zeynep" && x.GuideSurname == "Dikyar").Select(y => y.GuideId).FirstOrDefault();
            lblZeynepDikyarLocationCount.Text = db.TblLocation.Where(x => x.GuideId == zeynepGuideId).Count().ToString();


        }

        private void label18_Click(object sender, EventArgs e)
        {

        }
    }
}