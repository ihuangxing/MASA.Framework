// Copyright (c) MASA Stack All rights reserved.
// Licensed under the MIT License. See LICENSE.txt in the project root for license information.

global using Masa.BuildingBlocks.Configuration;
global using Masa.BuildingBlocks.Data;
global using Masa.BuildingBlocks.Data.UoW;
global using Masa.BuildingBlocks.Dispatcher.Events;
global using Microsoft.AspNetCore.Builder;
global using Microsoft.Data.Sqlite;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Options;
global using Microsoft.VisualStudio.TestTools.UnitTesting;
global using Moq;
global using System;
global using System.Threading.Tasks;
global using EntityState = Masa.BuildingBlocks.Data.UoW.EntityState;
