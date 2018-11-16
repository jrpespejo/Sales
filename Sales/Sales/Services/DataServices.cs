﻿
namespace Sales.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Common.Models;
    using Interfaces;
    using SQLite;
    using Xamarin.Forms;

    public class DataService
    {
        private SQLiteAsyncConnection connection;

        public DataService()
        {
            this.OpenOrCreateDB();
        }

        private async Task OpenOrCreateDB()
        {
            var databasePath = DependencyService.Get<IPathService>().GetDatabasePath();
            this.connection = new SQLiteAsyncConnection(databasePath);
            await connection.CreateTableAsync<Products>().ConfigureAwait(false);
        }

        public async Task Insert<T>(T model)
        {
            await this.connection.InsertAsync(model);
        }

        public async Task Insert<T>(List<T> models)
        {
            await this.connection.InsertAllAsync(models);
        }

        public async Task Update<T>(T model)
        {
            await this.connection.UpdateAsync(model);
        }

        public async Task Update<T>(List<T> models)
        {
            await this.connection.UpdateAllAsync(models);
        }

        public async Task Delete<T>(T model)
        {
            await this.connection.DeleteAsync(model);
        }

        public async Task<List<Products>> GetAllProducts()
        {
            var query = await this.connection.QueryAsync<Products>("select * from [Products]");
            var array = query.ToArray();
            var list = array.Select(p => new Products
            {
                Description = p.Description,
                ImagePath = p.ImagePath,
                IsAvailable = p.IsAvailable,
                Price = p.Price,
                ProductId = p.ProductId,
                PublisOn = p.PublisOn,
                Remarks = p.Remarks,
            }).ToList();
            return list;
        }

        public async Task DeleteAllProducts()
        {
            var query = await this.connection.QueryAsync<Products>("delete from [Products]");
        }
    }

}
