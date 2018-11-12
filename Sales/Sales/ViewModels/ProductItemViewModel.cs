

namespace Sales.ViewModels
{
    using Common.Models;
    using GalaSoft.MvvmLight.Command;
    using Sales.Helpers;
    using Sales.Views;
    using Services;
    using System;
    using System.Linq;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class ProductItemViewModel : Products
    {
        #region Attributes

        private ApiService apiService;

        #endregion

        #region Contructor

        public ProductItemViewModel()
        {
            this.apiService = new ApiService();
        }
        #endregion
        #region Commands
        public  ICommand EditProductCommand
        {
            get
            {
                return new RelayCommand(EditProduct);
            }
        }

        private async void EditProduct()
        {
            MainViewModel.Getinstance().EditProduct = new EditProductViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(new EditProductPage());
        }

        public ICommand DeleteProductCommand
        {
            get
            {
                return new RelayCommand(DeleteProduct);
            }
        }

        private async void DeleteProduct()
        {
            var answer = await Application.Current.MainPage.DisplayAlert(
                Languages.Confirm, 
                Languages.DeleteConfirmation, 
                Languages.Yes, 
                Languages.No);

            if (!answer)
            {
                return;
            }

            var conection = await this.apiService.CheckConnection();
            if (!conection.IsSuccess)
            {                
                await Application.Current.MainPage.DisplayAlert(Languages.Error, conection.Message, Languages.Accept);
                return;
            }
            var url = Application.Current.Resources["UrlAPI"].ToString();
            var prefix = Application.Current.Resources["UrlPrefix"].ToString();
            var controller = Application.Current.Resources["UrlProductsController"].ToString();

            var response = await this.apiService.Delete(url, prefix, controller,this.ProductId);
            if (!response.IsSuccess)
            {                
                await Application.Current.MainPage.DisplayAlert(Languages.Error, response.Message, Languages.Accept);
                return;
            }

            var productsViewModel = ProductsViewModel.Getinstance();
            var deletedProducts = productsViewModel.MyProducts.Where(p=>p.ProductId==this.ProductId).FirstOrDefault();
            if (deletedProducts!=null)
            {
                productsViewModel.MyProducts.Remove(deletedProducts);
            }
            productsViewModel.RefreshList();

        }

        #endregion
    }
}
