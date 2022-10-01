﻿using Application.Repositories.BrandRepositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories.BrandRepositories;

public class BrandWriteRepository : WriteRepository<Brand>, IBrandWriteRepository
{
    public BrandWriteRepository(RentACarDbContext context) : base(context)
    {
    }
}