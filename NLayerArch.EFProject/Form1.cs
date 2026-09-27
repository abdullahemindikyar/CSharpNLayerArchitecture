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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        NLayerArchEFTravelDbEntities db = new NLayerArchEFTravelDbEntities();

        private void btnList_Click(object sender, EventArgs e)
        {
            var list = db.TblGuide.ToList();
            
            dataGridView.DataSource = list;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TblGuide guide = new TblGuide();
            guide.GuideName = txtName.Text;
            guide.GuideSurname = txtSurname.Text;
            
            db.TblGuide.Add(guide);
            db.SaveChanges();

            MessageBox.Show("Guide added successfully!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text); 

            var removeValue = db.TblGuide.Find(id);
            db.TblGuide.Remove(removeValue);
            db.SaveChanges();

            MessageBox.Show("Guide deleted successfully!");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);

            var updateValue = db.TblGuide.Find(id);
            updateValue.GuideName = txtName.Text;
            updateValue.GuideSurname = txtSurname.Text;
            db.SaveChanges();

            MessageBox.Show("Guide updated successfully!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnGetByID_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var values = db.TblGuide.Where(g => g.GuideId == id).ToList();
            if (values.Count > 0)
            {
                dataGridView.DataSource = values;
            }
            else
            {
                MessageBox.Show("No guide found with the specified ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
