using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusTicket.API.Models;
using Microsoft.AspNetCore.Mvc;


namespace BusTicket.API.Repositories
{
    public interface IDataRepository<T> where T: class
    {
        Task<IEnumerable<T>> Get();
        Task<T> GetByID(int id);
        Task<T> Post(T entity);
        Task<IActionResult> Put(int id, T entity);
        Task<ActionResult<T>> Delete(int id);
    }
}
