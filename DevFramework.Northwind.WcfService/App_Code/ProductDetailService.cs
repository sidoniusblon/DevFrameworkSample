﻿using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.DependencyResolvers;
using DevFramework.Northwind.Business.ServiceContracts.Wcf;
using DevFramework.Northwind.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// ProductDetailService için özet açıklama
/// </summary>
public class ProductDetailService : IProductDetailService
{
    IProductService _productService = InstanceFactory.GetInstance<IProductService>();
    public List<Product> GetAll()
    {
       return _productService.GetAll();
    }
}