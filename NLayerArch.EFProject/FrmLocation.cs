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
    public partial class FrmLocation : Form
    {
        public FrmLocation()
        {
            InitializeComponent();
        }

        NLayerArchEFTravelDbEntities db = new NLayerArchEFTravelDbEntities();

        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.TblLocation.ToList();
            dataGridView.DataSource = values;

        }

        private void FrmLocation_Load(object sender, EventArgs e)
        {
            var values = db.TblGuide.Select(g => new {
                FullName = g.GuideName + " " + g.GuideSurname, g.GuideId
            }).ToList();
            cmbGuide.DisplayMember = "FullName";
            cmbGuide.ValueMember = "GuideID";
            cmbGuide.DataSource = values; cmbGuide.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TblLocation location = new TblLocation();
            location.LocationCapacity = byte.Parse(nudCapacity.Text);

            location.LocationCity = txtCity.Text;
            location.LocationCountry = txtCountry.Text;
            location.LocationPrice = decimal.Parse(txtPrice.Text);
            location.DayNight = txtDayNight.Text;
            location.GuideId = int.Parse(cmbGuide.SelectedValue.ToString());

            db.TblLocation.Add(location);

            if (db.SaveChanges() > 0)
            {
                MessageBox.Show("Location added successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to add location.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            db.SaveChanges();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var deletedValue = db.TblLocation.Find(id);
            if (deletedValue != null)
            {
                db.TblLocation.Remove(deletedValue);
                if (db.SaveChanges() > 0)
                {
                    MessageBox.Show("Location deleted successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to delete location.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var updatedValue = db.TblLocation.Find(id);
            updatedValue.DayNight = txtDayNight.Text;
            updatedValue.LocationCapacity = byte.Parse(nudCapacity.Text);
            updatedValue.LocationPrice = decimal.Parse(txtPrice.Text);
            updatedValue.LocationCity = txtCity.Text;
            updatedValue.LocationCountry = txtCountry.Text;
            updatedValue.GuideId = int.Parse(cmbGuide.SelectedValue.ToString());

            if (db.SaveChanges() > 0)
            {
                MessageBox.Show("Location updated successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to update location.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}