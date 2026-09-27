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
    public partial class FrmProduct : Form
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public FrmProduct()
        {
            InitializeComponent();
            _productService = new ProductManager(new EfProductDal());
            _categoryService = new CategoryManager(new EfCategoryDal());
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            var values = _productService.TGetAll();
            dataGridView1.DataSource = values;
        }

        private void btnList2_Click(object sender, EventArgs e)
        {
            var values = _productService.TGetProductWithCategory();
            dataGridView1.DataSource = values;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtProductId.Text);
            var deletedValues = _productService.TGetById(id);
            if (deletedValues == null)
            {
                MessageBox.Show("Product not found (delete failed).");
                return;
            }
            _productService.TDelete(deletedValues);
            MessageBox.Show("Product Deleted");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            // use SelectedValue which is bound to CategoryId
            if (cmbCategory.SelectedValue == null)
            {
                MessageBox.Show("Please select a category first.");
                return;
            }
            product.CategoryId = (int)cmbCategory.SelectedValue;
            product.ProductName = txtProductName.Text;
            product.ProductStock = int.Parse(txtProductStock.Text);
            product.ProductPrice = decimal.Parse(txtProductPrice.Text);
            product.ProductDescription = txtDescription.Text;
            _productService.TInsert(product);
            MessageBox.Show("Product Added");
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtProductId.Text);
            var getProduct = _productService.TGetById(id);
            if (getProduct == null)
            {
                MessageBox.Show("Product not found.");
                return;
            }
            else
            {
                // bind single product as a one-item list so DataGridView displays it
                dataGridView1.DataSource = new System.Collections.Generic.List<EntityLayer.Concrete.Product> { getProduct };
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtProductId.Text);
            var updatedProduct = _productService.TGetById(id);
            if (updatedProduct == null)
            {
                MessageBox.Show("Product not found.");
                return;
            }
            else
            {
                updatedProduct.ProductName = txtProductName.Text;
                updatedProduct.ProductStock = int.Parse(txtProductStock.Text);
                updatedProduct.ProductPrice = decimal.Parse(txtProductPrice.Text);
                updatedProduct.ProductDescription = txtDescription.Text;
                _productService.TUpdate(updatedProduct);
                MessageBox.Show("Product Updated");
            }
        }

        private void FrmProduct_Load(object sender, EventArgs e)
        {
            // populate categories into the combo box (moved here from constructor)
            var categories = _categoryService.TGetAll();
            cmbCategory.DataSource = categories;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "CategoryId";

        }
    }
}
