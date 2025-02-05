﻿// Copyright (c) MASA Stack All rights reserved.
// Licensed under the MIT License. See LICENSE.txt in the project root for license information.

namespace Masa.Contrib.Authentication.Identity;

public class DefaultMultiEnvironmentUserContext: BaseUserContext, IMultiEnvironmentUserContext
{
    public string? Environment => GetUser<MultiEnvironmentIdentityUser>()?.Environment;

    public DefaultMultiEnvironmentUserContext(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }
}
