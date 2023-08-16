using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blazor.NativeDOM;

// This class provides an example of how JavaScript functionality can be wrapped
// in a .NET class for easy consumption. The associated JavaScript module is
// loaded on demand when first needed.
//
// This class can be registered as scoped DI service and then injected into Blazor
// components for use.

public class ExampleJsInterop : IAsyncDisposable
{
    private readonly Lazy<Task<IJSObjectReference>> _moduleTask;

    public ExampleJsInterop(IJSRuntime jsRuntime)
    {
        _moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/Blazor.NativeDOM/exampleJsInterop.js").AsTask());
    }

    public async ValueTask<ElementReference> GetElementById(string id)
    {
        var module = await _moduleTask.Value;
        return await module.InvokeAsync<ElementReference>("document.getElementById", id);
    }

    public async ValueTask DisposeAsync()
    {
        if (!_moduleTask.IsValueCreated) return;

        var module = await _moduleTask.Value;
        await module.DisposeAsync();
    }
}