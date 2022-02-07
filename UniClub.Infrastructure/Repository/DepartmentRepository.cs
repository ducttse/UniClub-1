using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniClub.Application.Common.Interfaces;
using UniClub.Domain.Common;
using UniClub.Domain.Entities;
using UniClub.Domain.Repository.Interfaces;

namespace UniClub.Infrastructure.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly IApplicationDbContext _context;

        public DepartmentRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(Department entity, CancellationToken cancellationToken)
        {
            var department = await GetByIdAsync(entity.Id, cancellationToken);
            try
            {
                if (department == null)
                {
                    _context.Departments.Add(entity);
                    return await _context.SaveChangesAsync(cancellationToken);
                }
                else
                {
                    throw new Exception("Department has already existed");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<int> DeleteAsync(Department entity, CancellationToken cancellationToken)
        {
            var department = await GetByIdAsync(entity.Id, cancellationToken);
            try
            {
                if (department == null)
                {
                    _context.Departments.Remove(entity);
                    return await _context.SaveChangesAsync(cancellationToken);

                }
                else
                {
                    throw new Exception("Department has already existed");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Department> GetByIdAsync(int id, CancellationToken cancellationToken)
            => await _context.Departments.FirstOrDefaultAsync(department => department.Id == id, cancellationToken);

        public async Task<PaginatedList<Department>> GetListAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            List<Department> result = new();
            int count = 0;
            try
            {
                count = await _context.Departments.CountAsync(cancellationToken);
                result = await _context.Departments.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }
            return new PaginatedList<Department>(result, count, pageNumber, pageSize);
        }

        public async Task<int> UpdateAsync(Department entity, CancellationToken cancellationToken)
        {
            Department department = await GetByIdAsync(entity.Id, cancellationToken);

            try
            {
                if (department != null)
                {
                    _context.Departments.Update(entity);
                    return await _context.SaveChangesAsync(cancellationToken);

                }
                else
                {
                    throw new Exception("Department has already existed");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}