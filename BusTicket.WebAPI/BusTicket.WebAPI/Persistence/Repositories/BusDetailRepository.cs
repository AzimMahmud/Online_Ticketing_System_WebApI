using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;



using BusTicket.API.Persistence;
using BusTicket.API.Persistence.Repositories;
using BusTicket.WebAPI.Core.Domain;
using BusTicket.WebAPI.Core.Repositories;
using BusTicket.WebAPI.Models;
using BusTicket.WebAPI.Persistence;
using BusTicket.WebAPI.Persistence.Repositories;


namespace BusTicket.API.Persistence.Repositories
{
    public class BusDetailRepository : Repository<BusDetail>, IBusDetails
    {

        public BusDetailRepository(BusTicketContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<object>> GetALLDetailsWithVendorCategoryBrand(int busDetailsid)
        {
            return await BusTicketContext.BusDetails
                .Join(BusTicketContext.Vendors, b => b.VendorID, br => br.VendorID, (b, br) => new
                {
                    b,
                    BusDetailID = b.BusDetailID,
                    VendorID = br.VendorID,
                    Vendor = br.VendorName
                }).Join(BusTicketContext.Brands, b => b.b.BrandID, br => br.BrandID, (b, br) => new
                {
                    b,
                    BusDetailID = b.BusDetailID,
                    VendorID = b.VendorID,
                    Vendor = b.Vendor,
                    BrandID = br.BrandID,
                    Brand = br.Name
                })
                .Join(BusTicketContext.BusCategories, b => b.b.b.BusCategoryID, br => br.BusCategoryID, (b, br) => new
                {
                    BusDetailID = b.BusDetailID,
                    VendorID = b.VendorID,
                    Vendor = b.Vendor,
                    BrandID = b.BrandID,
                    Brand = b.Brand,
                    CategoryID = br.BusCategoryID,
                    Category = br.Name
                }).Where(id => id.BusDetailID == busDetailsid)
                .ToListAsync();
        }


        public async Task<IEnumerable<object>> GetBusDetailWithBrand()
        {
            return await BusTicketContext.BusDetails
                .Join(BusTicketContext.Brands, b => b.BrandID, br => br.BrandID, (b, br) => new
                {
                    BrandID = br.BrandID,
                    Brand = br.Name
                }).Distinct()
                .ToListAsync();
        }

        public async Task<IEnumerable<object>> GetBusDetailWithVendor()
        {
            return await BusTicketContext.BusDetails
                .Join(BusTicketContext.Vendors, b => b.VendorID, br => br.VendorID, (b, br) => new
                {
                    VendorID = br.VendorID,
                    Vendor = br.VendorName
                }).Distinct()
                .ToListAsync();
        }
        public async Task<IEnumerable<object>> GetBusDetailWithCategory()
        {
            return await BusTicketContext.BusDetails
                .Join(BusTicketContext.BusCategories, b => b.BusCategoryID, br => br.BusCategoryID, (b, br) => new
                {
                    BusCategoryID = br.BusCategoryID,
                    BusCategory = br.Name
                }).Distinct()
                .ToListAsync();
        }

        public async Task<IEnumerable<Object>> GetBusInfo()
        {
            var data = await BusTicketContext.BusDetails.Join(BusTicketContext.Brands, r => r.BrandID, b => b.BrandID, (bs, br) => new
            {
                BusDetailID = bs.BusDetailID,
                BrandName = br.Name,
                IsActive = bs.IsActive
            }).Join(BusTicketContext.BusCategories, b => b.BusDetailID, bc => bc.BusCategoryID, (b, bc) => new
            {
                BusDetailID = b.BusDetailID,
                BrandName = b.BrandName,
                Catetory = bc.Name,
                IsActive = b.IsActive
            }).Join(BusTicketContext.Vendors, b => b.BusDetailID, v => v.VendorID, (b, v) => new
            {
                BusDetailID = b.BusDetailID,
                BrandName = b.BrandName,
                Catetory = b.Catetory,
                Vendor = v.VendorName,
                IsActive = b.IsActive
            }).Where(i => i.IsActive == true).ToListAsync();
            return data;
        }

        public async Task<IEnumerable<Object>> GetArchiveBusInfo()
        {
            var data = await BusTicketContext.BusDetails.Join(BusTicketContext.Brands, r => r.BrandID, b => b.BrandID, (bs, br) => new
            {
                BusDetailID = bs.BusDetailID,
                BrandName = br.Name,
                IsActive = bs.IsActive
            }).Join(BusTicketContext.BusCategories, b => b.BusDetailID, bc => bc.BusCategoryID, (b, bc) => new
            {
                BusDetailID = b.BusDetailID,
                BrandName = b.BrandName,
                Catetory = bc.Name,
                IsActive = b.IsActive
            }).Join(BusTicketContext.Vendors, b => b.BusDetailID, v => v.VendorID, (b, v) => new
            {
                BusDetailID = b.BusDetailID,
                BrandName = b.BrandName,
                Catetory = b.Catetory,
                Vendor = v.VendorName,
                IsActive = b.IsActive
            }).Where(i => i.IsActive == false).ToListAsync();
            return data;
        }

        public BusTicketContext BusTicketContext
        {
            get { return Context as BusTicketContext; }
        }
    }
}
