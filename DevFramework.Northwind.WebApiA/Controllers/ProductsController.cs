﻿using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace DevFramework.Northwind.WebApiA.Controllers
{
    public class ProductsController : ApiController
    {
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        public List<Product> Get()
        {
           return _productService.GetAll();
        }
    }
}