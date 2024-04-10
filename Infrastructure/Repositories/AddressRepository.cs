using Infrastructure.Context;
using Infrastructure.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AddressRepository: GenericRepository<AddressEntity>
    {
        private readonly DataContext _context;

        public AddressRepository(DataContext context) : base(context) { _context = context; }
        
    
    }
}
