using InventoryManagementAPI.Data;
using InventoryManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementAPI.Repository
{
    public class SupplierRepository
    {
        private readonly InventoryManagementContext _context;

        public SupplierRepository(InventoryManagementContext context)
        {
            _context = context;
        }

        public async Task<List<Supplier>> GetAllSuppliersAsync()
        {
            return await _context.Suppliers
                .Include(supplier => supplier.Products)
                .ToListAsync();
        }

        public async Task<Supplier?> GetSupplierByIdAsync(int id)
        {
            return await _context.Suppliers
                .Include(supplier => supplier.Products)
                .FirstOrDefaultAsync(supplier => supplier.Id == id);
        }

        public async Task<Supplier> CreateSupplierAsync(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();
            return supplier;
        }

        public async Task<bool> UpdateSupplierAsync(Supplier supplier)
        {
            var existingSupplier = await _context.Suppliers.FindAsync(supplier.Id);

            if (existingSupplier == null)
            {
                return false;
            }

            existingSupplier.Name = supplier.Name;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteSupplierAsync(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);

            if (supplier == null)
            {
                return false;
            }

            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
