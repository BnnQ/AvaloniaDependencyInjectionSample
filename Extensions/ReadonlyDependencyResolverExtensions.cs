using System;
using Splat;

namespace LauncherDesktop.Extensions;

public static class ReadonlyDependencyResolverExtensions
{
    public static T GetRequiredService<T>(this IReadonlyDependencyResolver resolver)
    {
        return resolver.GetService<T>() ?? throw new InvalidOperationException($"Service {typeof(T)} not found");
    }
}