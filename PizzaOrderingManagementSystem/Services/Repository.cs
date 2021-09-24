using Microsoft.EntityFrameworkCore;
using PizzaOrderingManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOrderingManagementSystem.Services
{
    class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        PizzaContext _context;
        DbSet<TEntity> _dbSet;

        public Repository()
        {
            _context = new PizzaContext();
            _dbSet = _context.Set<TEntity>();
        }

        public IEnumerable<TEntity> Get()
        {
            try
            {
                return _dbSet.AsNoTracking().ToList();
            }
            catch (ArgumentNullException an)
            {
                Console.WriteLine(an.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            try
            {
                return _dbSet.AsNoTracking().Where(predicate).ToList();
            }
            catch (ArgumentNullException an)
            {
                Console.WriteLine(an.Message);
            }
            return null;
        }

        public TEntity FindById(int id)
        {
            try
            {
                return _dbSet.Find(id);
            }
            catch (ArgumentNullException an)
            {
                Console.WriteLine(an.Message);
            }
            return null;

        }

        public async Task<TEntity> Create(TEntity item)
        {
            try
            {
                var entry = await _dbSet.AddAsync(item);
                _context.SaveChanges();
                return entry.Entity;
            }
            catch (DbUpdateConcurrencyException ducex)
            {
                Console.WriteLine(ducex.Message);
            }
            catch (DbUpdateException dbuex)
            {
                Console.WriteLine(dbuex.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public void Update(TEntity item)
        {
            try
            {
                _context.Entry(item).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (DbUpdateConcurrencyException ducex)
            {
                Console.WriteLine(ducex.Message);
            }
            catch (DbUpdateException dbuex)
            {
                Console.WriteLine(dbuex.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Remove(TEntity item)
        {
            try
            {
                _dbSet.Remove(item);
                _context.SaveChanges();
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (DbUpdateConcurrencyException ducex)
            {
                Console.WriteLine(ducex.Message);
            }
            catch (DbUpdateException dbuex)
            {
                Console.WriteLine(dbuex.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
