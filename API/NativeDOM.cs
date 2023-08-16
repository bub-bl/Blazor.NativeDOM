using Blazor.NativeDOM.WebIDL.JSInterop.ErrorHandling;
using Microsoft.JSInterop;

namespace Blazor.NativeDOM.API;

public interface INativeDOM
{
}

public sealed class NativeDOM : INativeDOM
{
    private readonly IJSRuntime _jsRuntime;
    private bool _isReady;

    public Window Window { get; private set; }

    public NativeDOM(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    internal async Task Initialize()
    {
        Window = await Window.CreateAsync(_jsRuntime);
        _isReady = true;
    }

    public async Task IsReady()
    {
        while (!_isReady) await Task.Delay(100);
    }
}