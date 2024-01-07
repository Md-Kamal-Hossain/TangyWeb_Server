using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangy_Business.Repository.IRepository;
using Tangy_DataAccess;
using Tangy_DataAccess.Data;
using Tangy_Models;

namespace Tangy_Business.Repository
{
    public class ProductRepository:IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public ProductRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;

        }
        public async Task<ProductDTO> Create(ProductDTO objDTO)
        {
            var obj = _mapper.Map<Product>(objDTO);
            

            var addedObj = _db.Products.Add(obj);
            await _db.SaveChangesAsync();
            return _mapper.Map<Product, ProductDTO>(addedObj.Entity);

        }

        public async Task<int> Delete(int id)
        {
            var obj = await _db.Products.FirstOrDefaultAsync(c => c.Id == id);
            if (obj != null)
            {
                _db.Products.Remove(obj);
                return await _db.SaveChangesAsync();

            }
            return 0;

        }

        public async Task<ProductDTO> Get(int id)
        {
            var obj = await _db.Products.Include(u=>u.Category).Include(u=>u.ProductPrices).FirstOrDefaultAsync(u => u.Id == id);
            if (obj != null)
            {
                return _mapper.Map<Product, ProductDTO>(obj);
            }
            return new ProductDTO();

        }

        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(_db.Products.Include(u => u.Category).Include(u=>u.ProductPrices));
        }

        public async Task<ProductDTO> Update(ProductDTO objDTO)
        {
            var objFromDB = await _db.Products.FirstOrDefaultAsync(c => c.Id == objDTO.Id);
            if (objFromDB != null)
            {
                objFromDB.Name = objDTO.Name;
                objFromDB.Description = objDTO.Description;
                objFromDB.ImageUrl = objDTO.ImageUrl;
                objFromDB.CategoryId = objDTO.CategoryId;
                objFromDB.Color = objDTO.Color;
                objFromDB.ShopFavorites = objDTO.ShopFavorites;
                objFromDB.CustomerFavorites = objDTO.CustomerFavorites;

                _db.Products.Update(objFromDB);
                await _db.SaveChangesAsync();
                return _mapper.Map<Product, ProductDTO>(objFromDB);
            }
            return objDTO;


        }


    }
}
