using NLayerArch.BussinessLayer.Abstract;
using NLayerArch.BussinessLayer.Concrete;
using NLayerArch.DataAccessLayer.EntityFramework;
using NLayerArch.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NLayerArch.PresentationLayer
{
    public partial class FrmCategory : Form
    {
        private readonly ICategoryService _categoryService;

        public FrmCategory()
        {
            _categoryService = new CategoryManager(new EfCategoryDal());
            InitializeComponent();

        }

        private void FrmCategory_Load(object sender, EventArgs e)
        {
            var categoryValues = _categoryService.TGetAll();
            dataGridView1.DataSource = categoryValues;
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            var categoryValues = _categoryService.TGetAll();
            dataGridView1.DataSource = categoryValues;
        }

        private void btnLAdd_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.CategoryName = txtCategoryName.Text;
            category.CategoryStatus = true;
            _categoryService.TInsert(category);
            MessageBox.Show("Category Added");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCategoryId.Text);
            var deletedValues = _categoryService.TGetById(id);
            _categoryService.TDelete(deletedValues);
            MessageBox.Show("Category Deleted");
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCategoryId.Text);
            var categoryValues = _categoryService.TGetById(id);
            if (categoryValues == null)
            {
                MessageBox.Show("Category not found.");
                dataGridView1.DataSource = null;
                return;
            }

            // bind a single entity as a one-item list so DataGridView can display it
            dataGridView1.DataSource = new System.Collections.Generic.List<EntityLayer.Concrete.Category> { categoryValues };
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int updatedId = int.Parse(txtCategoryId.Text);
            var updatedValues = _categoryService.TGetById(updatedId);
            if (updatedValues == null)
            {
                MessageBox.Show("Category not found (update failed).");
                return;
            }

            updatedValues.CategoryName = txtCategoryName.Text;
            updatedValues.CategoryStatus = true;
            _categoryService.TUpdate(updatedValues);
            MessageBox.Show("Category Updated");
        }
    }
}
