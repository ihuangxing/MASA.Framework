﻿// Copyright (c) MASA Stack All rights reserved.
// Licensed under the MIT License. See LICENSE.txt in the project root for license information.

namespace Masa.Utils.Extensions.DependencyInjection.Tests.Infrastructure.Repositories;

public abstract class RepositoryBase<TEntity> : IRepository<TEntity>
    where TEntity : class
{

}

public class Repository<TEntity> : RepositoryBase<TEntity>
    where TEntity : class
{

}

public class UserRepository<TEntity> : IRepository<UserDbContext, TEntity>
    where TEntity : class
{

}
