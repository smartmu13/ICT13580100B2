using ICT13580100B2.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ICT13580100B2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductNewPage : ContentPage
    {
        Product product;

        public ProductNewPage(Product product=null)
        {
            InitializeComponent();

            this.product = product;

            titleLabel.Text = product == null ? "เพิ่มสินค้าใหม่" : "แก้ไขข้อมูลสินค้า";

            submitButton.Clicked += SubmitButton_Clicked;
            cancelButton.Clicked += CancelButton_Clicked;

            categoryPicker.Items.Add("เสื้อ");
            categoryPicker.Items.Add("กางเกง");
            categoryPicker.Items.Add("ถุงเท้า");

            if(product != null)
            {
                productNameEntry.Text = product.name;
                productDetailEntry.Text = product.Description;
                categoryPicker.SelectedItem = product.Category;
                productPriceEntry.Text = product.ProductPrice.ToString();
                sellPriceEntry.Text = product.SellPrice.ToString();
                stockEntry.Text = product.Stock.ToString();

            }
        }

        void CancelButton_Clicked(object sender, EventArgs e)
        {

            Navigation.PopModalAsync();

        }

        async void SubmitButton_Clicked(object sender, EventArgs e)
        {
            var isOk = await DisplayAlert("ยืนยัน", "คุณต้องการบันทึกใช่ไหม", "ใช่", "ไม่ใช่");
            if (isOk)
            {
                if (product == null)
                {
                    product = new Product();
                    product.name = productNameEntry.Text;
                    product.Description = productDetailEntry.Text;
                    product.Category = categoryPicker.SelectedItem.ToString();
                    product.ProductPrice = decimal.Parse(productPriceEntry.Text);
                    product.SellPrice = decimal.Parse(sellPriceEntry.Text);
                    product.Stock = int.Parse(stockEntry.Text);
                    var id = App.dbHelpers.AppProduct(product);
                    await DisplayAlert("บันทึกสำเส็จ", "รหัสสินค้าของท่านคือ #" + id, "ตกลง");
                }    
                else
                {
                    product.name = productNameEntry.Text;
                    product.Description = productDetailEntry.Text;
                    product.Category = categoryPicker.SelectedItem.ToString();
                    product.ProductPrice = decimal.Parse(productPriceEntry.Text);
                    product.SellPrice = decimal.Parse(sellPriceEntry.Text);
                    product.Stock = int.Parse(stockEntry.Text);
                    var id = App.dbHelpers.UpdateProduct(product);
                    await DisplayAlert("บันทึกสำเส็จ", "แก้ไขข้อมูลสินค้าเรียบร้อย", "ตกลง");
                }
                await Navigation.PopModalAsync();

            }
        }
    }
}