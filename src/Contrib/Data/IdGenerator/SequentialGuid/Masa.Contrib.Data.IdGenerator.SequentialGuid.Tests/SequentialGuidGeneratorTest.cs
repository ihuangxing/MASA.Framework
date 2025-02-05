﻿// Copyright (c) MASA Stack All rights reserved.
// Licensed under the MIT License. See LICENSE.txt in the project root for license information.

namespace Masa.Contrib.Data.IdGenerator.SequentialGuid.Tests;

[TestClass]
public class SequentialGuidGeneratorTest
{
    [TestMethod]
    public void TestNewId()
    {
        int count = 10000000;
        List<Guid> guids = new();
        for (int i = 0; i < count; i++)
        {
            guids.Add(new SequentialGuidGenerator(SequentialGuidType.SequentialAsString).NewId());
        }
        Assert.IsTrue(guids.Count == guids.Distinct().Count());
    }

    [TestMethod]
    public void TestNewId2()
    {
        var services = new ServiceCollection();
        services.AddSequentialGuidGenerator();

        Assert.AreNotEqual(Guid.Empty, MasaApp.GetRequiredService<IIdGenerator<Guid>>().NewId());
    }

    [TestMethod]
    public void TestNewId3()
    {
        var services = new ServiceCollection();
        services.AddSequentialGuidGenerator("test");
        MasaApp.SetServiceCollection(services);
        MasaApp.Build();
        var idGeneratorFactory = MasaApp.GetService<IIdGeneratorFactory>();
        Assert.IsNotNull(idGeneratorFactory);

        var idGenerator = idGeneratorFactory.Create<Guid>("test");
        Assert.IsNotNull(idGenerator);

        Assert.AreNotEqual(Guid.Empty, idGenerator.NewId());
    }

    [TestMethod]
    public void TestSequentialGuidReturnIdGeneratorIsNotNull()
    {
        var services = new ServiceCollection();
        services.AddSequentialGuidGenerator(SequentialGuidType.SequentialAtEnd);
        var serviceProvider = services.BuildServiceProvider();
        var idGenerator = serviceProvider.GetService<IIdGenerator<Guid>>();
        Assert.IsNotNull(idGenerator);
        Assert.IsTrue(idGenerator.GetType() == typeof(SequentialGuidGenerator));

        Assert.IsNotNull(serviceProvider.GetService<IIdGenerator>());
    }

    [TestMethod]
    public void TestSequentialGuidByMasaAppReturnIdGeneratorIsNotNull()
    {
        var services = new ServiceCollection();
        services.TestAddSequentialGuidGenerator(SequentialGuidType.SequentialAsString);

        var idGenerator = MasaApp.GetService<IIdGenerator<Guid>>();
        Assert.IsNotNull(idGenerator);
        Assert.IsTrue(idGenerator.GetType() == typeof(SequentialGuidGenerator));

        Assert.IsNotNull(MasaApp.GetService<IIdGenerator>());
    }

    [TestMethod]
    public void TestSequentialGuidByDefaultReturnIdGeneratorIsNotNull()
    {
        var services = new ServiceCollection();
        services.TestAddSequentialGuidGenerator();
        MasaApp.Build();

        var idGeneratorFactory = MasaApp.GetService<IIdGeneratorFactory>();
        Assert.IsNotNull(idGeneratorFactory);

        var idGenerator = idGeneratorFactory.Create();
        Assert.IsNotNull(idGenerator);
        Assert.IsTrue(idGenerator.GetType() == typeof(SequentialGuidGenerator));
    }

    [TestMethod]
    public void TestSequentialGuidByCustomNameReturnIdGeneratorIsNotNull()
    {
        var services = new ServiceCollection();
        services.TestAddSequentialGuidGenerator("sequentialGuid", SequentialGuidType.SequentialAsString);
        MasaApp.Build();

        var idGeneratorFactory = MasaApp.GetService<IIdGeneratorFactory>();
        Assert.IsNotNull(idGeneratorFactory);

        var idGenerator = idGeneratorFactory.Create("sequentialGuid");
        Assert.IsNotNull(idGenerator);
        Assert.IsTrue(idGenerator.GetType() == typeof(SequentialGuidGenerator));
    }

    [TestMethod]
    public void TestSequentialGuidByCustomName2ReturnIdGeneratorIsNotNull()
    {
        var services = new ServiceCollection();
        services.TestAddSequentialGuidGenerator("sequentialGuid");
        MasaApp.Build();

        var idGeneratorFactory = MasaApp.GetService<IIdGeneratorFactory>();
        Assert.IsNotNull(idGeneratorFactory);

        var idGenerator = idGeneratorFactory.Create("sequentialGuid");
        Assert.IsNotNull(idGenerator);
        Assert.IsTrue(idGenerator.GetType() == typeof(SequentialGuidGenerator));
    }

    [TestMethod]
    public void TestSequentialGuidByErrorTypeReturnNotSupportedException()
    {
        var services = new ServiceCollection();
        services.TestAddSequentialGuidGenerator("sequentialGuid", (SequentialGuidType)5);
        MasaApp.Build();

        var idGeneratorFactory = MasaApp.GetService<IIdGeneratorFactory>();
        Assert.IsNotNull(idGeneratorFactory);

        var idGenerator = idGeneratorFactory.Create("sequentialGuid");
        Assert.IsNotNull(idGenerator);
        Assert.IsTrue(idGenerator.GetType() == typeof(SequentialGuidGenerator));

        Assert.ThrowsException<NotSupportedException>(() => idGenerator.NewStringId());
    }

    [TestMethod]
    public void TestAddMultiSequentialGuidReturnIdGeneratorCountIs1()
    {
        var services = new ServiceCollection();
        services.TestAddSequentialGuidGenerator().TestAddSequentialGuidGenerator();
        MasaApp.Build();

        Assert.IsTrue(services.Count(d => d.ServiceType == typeof(IIdGenerator<Guid>)) == 1);
    }

    [TestMethod]
    public void TestSequentialGuidByNameIsNullReturnArgumentNullException()
    {
        var services = new ServiceCollection();
        Assert.ThrowsException<ArgumentNullException>(() => services.TestAddSequentialGuidGenerator(null!));
    }
}
