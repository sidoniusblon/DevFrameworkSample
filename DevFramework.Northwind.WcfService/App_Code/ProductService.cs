using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.DependencyResolvers;
using DevFramework.Northwind.Entities.Concrete;

/// <summary>
/// ProductService için özet açıklama
/// </summary>
public class ProductService:IProductService
{
    public ProductService()
    {
        //
        //TODO: Buraya oluşturucu mantığı ekleyin
        //
    }
    IProductService _productService = InstanceFactory.GetInstance<IProductService>();
    public Product Add(Product p)
    {
        return _productService.Add(p);
    }

    public List<Product> GetAll()
    {
       return _productService.GetAll();
    }

    public Product GetById(int id)
    {
        return _productService.GetById(id);
    }

    public void TransactionalOperation(Product p1, Product p2)
    {
        _productService.TransactionalOperation(p1, p2);
    }

    public Product Update(Product p)
    {
        return _productService.Update(p);
    }
}