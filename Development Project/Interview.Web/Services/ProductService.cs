using AutoMapper;
using Interview.Web.Dtos;
using Interview.Web.EntityFrameworkCore;
using Interview.Web.Interfaces;
using Interview.Web.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Interview.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly InventoryDbContext _dbContext;

        private readonly IMapper _mapper;

        public ProductService(InventoryDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            return await Task.Run(() => new List<ProductDto>()
            {
                new ProductDto
                {
                    InstanceId = 1,
                    Name = "Product 1",
                    Description = "Product 1 Description",
                    IsDeleted = true,
                    ValidSkus = "12345, 23456",
                    ProductImageUris = "https://www.google.com",
                    DeletionTimeStamp = DateTime.UtcNow,
                    Categories = new List<Models.Category>
                    {
                        new Models.Category
                        {
                            InstanceId = 1,
                            Name = "Category 1",
                            Description = "Category 1 Description",
                            CreatedTimestamp = DateTime.UtcNow
                        }
                    },
                    Attributes = new List<Models.ProductAttribute>
                    {
                        new Models.ProductAttribute
                        {
                            InstanceId = 1,
                            Key = "Sku",
                            Value = "12345"
                        }
                    }
                },
                new ProductDto
                {
                    InstanceId = 2,
                    Name = "Product 2",
                    Description = "Product 2 Description",
                    IsDeleted = false,
                    ValidSkus = "12345, 67890",
                    ProductImageUris = "https://www.google.com",
                    Categories = new List<Models.Category>
                    {
                        new Models.Category
                        {
                            InstanceId = 1,
                            Name = "Category 1",
                            Description = "Category 1 Description",
                            CreatedTimestamp = DateTime.UtcNow
                        }
                    },
                    Attributes = new List<Models.ProductAttribute>
                    {
                        new Models.ProductAttribute
                        {
                            InstanceId = 1,
                            Key = "Sku",
                            Value = "12345"
                        }
                    }
                }
            }.Where(product => !product.IsDeleted));

        }

        public async Task<bool> AddProductAsync(ProductDto product)
        { 
            if (product is not null)
            {
                _dbContext.Add(_mapper.Map<Product>(product));
                await _dbContext.SaveChangesAsync();
            }
            // using dapper
            using (var connection = new SqlConnection("connection string from configuration setting"))
            {
                await connection.OpenAsync();
                // save to db 
                await connection.CloseAsync();
            }

            return true;
        }

        public async Task<IEnumerable<ProductDto>> SearchProductsAsync(string searchText)
        {
            // get list of products using dapper connection to db
            // return list of products
            var listFromDb = new List<ProductDto>()
            {
                new ProductDto
                {
                    InstanceId = 1,
                    Name = "Product 1",
                    Description = "Product 1 Description",
                    IsDeleted = true,
                    ValidSkus = "12345, 23456",
                    ProductImageUris = "https://www.google.com",
                    DeletionTimeStamp = DateTime.UtcNow,
                    Categories = new List<Models.Category>
                    {
                        new Models.Category
                        {
                            InstanceId = 1,
                            Name = "Category 1",
                            Description = "Category 1 Description",
                            CreatedTimestamp = DateTime.UtcNow
                        }
                    },
                    Attributes = new List<Models.ProductAttribute>
                    {
                        new Models.ProductAttribute
                        {
                            InstanceId = 1,
                            Key = "Sku",
                            Value = "12345"
                        }
                    }
                },
                new ProductDto
                {
                    InstanceId = 2,
                    Name = "Product 2",
                    Description = "Product 2 Description",
                    IsDeleted = false,
                    ValidSkus = "12345, 67890",
                    ProductImageUris = "https://www.google.com",
                    Categories = new List<Models.Category>
                    {
                        new Models.Category
                        {
                            InstanceId = 1,
                            Name = "Category 1",
                            Description = "Category 1 Description",
                            CreatedTimestamp = DateTime.UtcNow
                        }
                    },
                    Attributes = new List<Models.ProductAttribute>
                    {
                        new Models.ProductAttribute
                        {
                            InstanceId = 1,
                            Key = "Sku",
                            Value = "12345"
                        }
                    }
                }
            }.Where(product => product.Name.Contains(searchText));

            return await Task.Run(() => listFromDb.Where(product => !product.IsDeleted));
        }


    }
}
