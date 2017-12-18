using ICT13580100B2.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ICT13580100B2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            newButton.Clicked += NewButton_Clicked;

        }

        protected override void OnAppearing()
        {
            LoradData();
        }

        void LoradData()
        {
            productListView.ItemsSource = App.dbHelpers.GetProducts();        
        }

        private void NewButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ProductNewPage());
        }

        async void Edit_Clicked(object sender, EventArgs e)
        {
            var button = sender as MenuItem;
            var product = button.CommandParameter as Product;
            Navigation.PushModalAsync(new ProductNewPage(product));
        }
        async void Delete_Clicked(object sender, EventArgs e)
        {
            var isOk = await DisplayAlert("ยืนยัน", "คุณต้องการลบหรือไม่", "ใช่", "ไม่ใช่");
            if(isOk)
            {
                var button = sender as MenuItem;
                var product = button.CommandParameter as Product;
                App.dbHelpers.DeleteProduct(product);

                await DisplayAlert("สบเส็จ", "ลบสินค้าเรียบร้อย", "ตกลง");
                LoradData();

            }
        }
    }
}
