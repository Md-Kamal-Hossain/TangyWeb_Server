using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tangy_Models;

namespace Tangy_Business.Repository.IRepository
{
    public interface IProductPriceRepository
    {
        public Task<ProductPriceDTO> Create(ProductPriceDTO prodDTO);
        public Task<ProductPriceDTO> Update(ProductPriceDTO prodDTO);
        public Task<int> Delete(int id);
        public Task<ProductPriceDTO> Get(int id);
        public Task<IEnumerable<ProductPriceDTO>> GetAll(int? id=null);
    }
}
