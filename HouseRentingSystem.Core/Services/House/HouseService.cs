﻿using HouseRentingSystem.Core.Contracts.House;
using HouseRentingSystem.Core.Models.Home;
using HouseRentingSystem.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Core.Services.House
{
    public class HouseService : IHouseService
    {
        private readonly IRepository repository;

        public HouseService(IRepository repository)
        {
            this.repository = repository;
        }


        public async Task<IEnumerable<HouseIndexServiceModel>> LastThreeHouses()
        {
            return await repository
                .AllReadOnly<Infrastructure.Data.Models.House>()
                .OrderByDescending(h => h.Id)
                .Take(3)
                .Select(h => new HouseIndexServiceModel()
                {
                    Id = h.Id,
                    Title = h.Title,
                    ImageUrl = h.ImageUrl
                })
                .ToListAsync();
        }
    }
}