using DevFramework.Core.CrossCuttingConcerns.Validation.FluentValidation;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.ValidationRules.FluentValidation;
using DevFramework.Northwind.DataAccess.Abstracts;
using DevFramework.Northwind.Entities.Concrete;
using DevFramework.Core.Aspects.PostSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.Aspects.PostSharp.ValidationAspects;
using DevFramework.Core.Aspects.PostSharp.TransactionAspects;
using DevFramework.Core.Aspects.PostSharp.CacheAspects;
using DevFramework.Core.CrossCuttingConcerns.Caching;
using DevFramework.Core.Aspects.PostSharp.LogAspects;
using System.Data.Entity.Infrastructure.Interception;
using DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using DatabaseLogger = DevFramework.Core.CrossCuttingConcerns.Logging.Log4Net.Loggers.DatabaseLogger;
using System.Threading;
using DevFramework.Core.Aspects.PostSharp.AuthorizationAspect;
using AutoMapper;
using DevFramework.Core.Utilities.Mappers;

namespace DevFramework.Northwind.Business.Concrete.Managers
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        readonly IMapper _mapper;
        public ProductManager(IProductDal productDal, IMapper mapper)
        {
            _productDal = productDal;
            _mapper = mapper;
        }
        [FluentValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public Product Add(Product p)
        {
           
           return _productDal.Add(p);
        }
        [CacheAspect(typeof(MemoryCacheManager),60)]
      
       
        //[LogAspect(typeof(DatabaseLogger))]
       // [LogAspect(typeof(FileLogger))]
        //[SecuredOperation(Roles ="Admin")] 
        public List<Product> GetAll()
        {
            return _mapper.Map<List<Product>>(_productDal.GetList());
        }
       
        public Product GetById(int id)
        {
            return _productDal.get(x => x.ProductId == id);
        }

      
        [TransactionScopeAspect]
        public void TransactionalOperation(Product p1, Product p2)
        {
            _productDal.Add(p1);
            _productDal.Add(p2);
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        public Product Update(Product p)
        {
            
            return _productDal.Update(p);
        }
    }
}
