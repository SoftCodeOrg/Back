﻿using Hakaton.Infrastruct;
using Microsoft.EntityFrameworkCore;

namespace Hakaton_UUNIT.HostedServices;

public class MigrationHostedService: IHostedService
{
    private readonly IServiceProvider _serviceProvider;

    public MigrationHostedService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var context = scope.ServiceProvider.GetService<DataContext>();

            if (context == null)
            {
                throw new Exception($"{nameof(DataContext)} not register");
            }

            context.Database.Migrate();
        }

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

}