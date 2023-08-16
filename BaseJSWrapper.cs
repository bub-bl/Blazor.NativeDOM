using Blazor.NativeDOM.Extensions;
using Microsoft.JSInterop;

namespace Blazor.NativeDOM;

/// <summary>
/// A base class for all wrapper classes from the Blazor.DOM library.
/// </summary>
public abstract class BaseJSWrapper : IJSWrapper, IAsyncDisposable
{
    /// <summary>
    /// A lazily loaded task that provide access to JS helper functions.
    /// </summary>
    protected readonly Lazy<Task<IJSObjectReference>> HelperTask;

    /// <inheritdoc/>
    public IJSObjectReference JSReference { get; }

    /// <inheritdoc/>
    public IJSRuntime JSRuntime { get; }

    /// <summary>
    /// Constructs a wrapper instance for an equivalent JS instance.
    /// </summary>
    /// <param name="jsRuntime">An <see cref="IJSRuntime"/> instance.</param>
    /// <param name="jsReference">A JS reference to an existing JS instance that should be wrapped.</param>
    internal BaseJSWrapper(IJSRuntime jsRuntime, IJSObjectReference jsReference)
    {
        HelperTask = new Lazy<Task<IJSObjectReference>>(jsRuntime.GetHelperAsync);
        JSReference = jsReference;
        JSRuntime = jsRuntime;
    }

    protected async ValueTask<TAttribute> GetAttributeAsync<TAttribute>(string attributeName)
    {
        var helper = await HelperTask.Value;
        return await helper.InvokeAsync<TAttribute>("getAttribute", JSReference, attributeName);
    }

    protected async ValueTask<TAttribute> GetAttributeFromRefAsync<TAttribute>(string attributeName)
    {
        var helper = await HelperTask.Value;
        var instance = await helper.InvokeAsync<IJSObjectReference>("getAttribute", JSReference, attributeName);
        return (TAttribute)Activator.CreateInstance(typeof(TAttribute), JSRuntime, instance)!;
    }

    protected async ValueTask SetAttributeAsync(string attributeName, object value)
    {
        var helper = await HelperTask.Value;
        await helper.InvokeVoidAsync("setAttribute", JSReference, attributeName, value);
    }

    /// <inheritdoc/>
    public async ValueTask DisposeAsync()
    {
        if (HelperTask.IsValueCreated)
        {
            var module = await HelperTask.Value;
            await module.DisposeAsync();
        }

        GC.SuppressFinalize(this);
    }
}