using Blazor.NativeDOM.API.Attributes;
using Blazor.NativeDOM.Extensions;
using Microsoft.JSInterop;

namespace Blazor.NativeDOM.API;

public class Location : BaseJSWrapper
{
    public Location(IJSRuntime jsRuntime, IJSObjectReference jsReference) : base(jsRuntime, jsReference)
    {
    }

    /// <summary>
    /// Constructs a wrapper instance for a given JS Instance of a <see cref="Location"/>.
    /// </summary>
    /// <param name="jsRuntime">An <see cref="IJSRuntime"/> instance.</param>
    /// <param name="jsReference">A JS reference to an existing <see cref="Location"/>.</param>
    /// <returns>A wrapper instance for a <see cref="Location"/>.</returns>
    public static Task<Location> CreateAsync(IJSRuntime jsRuntime, IJSObjectReference jsReference)
    {
        return Task.FromResult(new Location(jsRuntime, jsReference));
    }

    public static async Task<Location> CreateAsync(IJSRuntime jsRuntime)
    {
        var helper = await jsRuntime.GetHelperAsync();
        var jsInstance = await helper.InvokeAsync<IJSObjectReference>("constructLocation");
        return new Location(jsRuntime, jsInstance);
    }

    [BrowserCompatibilities(Browsers.All)]
    public ValueTask<DOMStringList> GetAncestorOriginsAsync() =>
        GetAttributeFromRefAsync<DOMStringList>("ancestorOrigins");

    [BrowserCompatibilities(Browsers.All)]
    public ValueTask<string> GetHashAsync() => GetAttributeAsync<string>("hash");

    [BrowserCompatibilities(Browsers.All)]
    public ValueTask SetHashAsync(string hash) => SetAttributeAsync("hash", hash);

    [BrowserCompatibilities(Browsers.All)]
    public ValueTask<string> GetHostAsync() => GetAttributeAsync<string>("host");

    [BrowserCompatibilities(Browsers.All)]
    public ValueTask SetHostAsync(string host) => SetAttributeAsync("host", host);

    [BrowserCompatibilities(Browsers.All)]
    public ValueTask<string> GetHostNameAsync() => GetAttributeAsync<string>("hostname");

    [BrowserCompatibilities(Browsers.All)]
    public ValueTask SetHostNameAsync(string hostname) => SetAttributeAsync("hostname", hostname);

    [BrowserCompatibilities(Browsers.All)]
    public ValueTask<string> GetHrefAsync() => GetAttributeAsync<string>("href");

    [BrowserCompatibilities(Browsers.All)]
    public ValueTask SetHrefAsync(string href) => SetAttributeAsync("href", href);

    [BrowserCompatibilities(Browsers.All)]
    public ValueTask<string> GetOriginAsync() => GetAttributeAsync<string>("origin");

    [BrowserCompatibilities(Browsers.All)]
    public ValueTask<string> GetPathNameAsync() => GetAttributeAsync<string>("pathname");

    [BrowserCompatibilities(Browsers.All)]
    public ValueTask SetPathNameAsync(string pathname) => SetAttributeAsync("pathname", pathname);

    [BrowserCompatibilities(Browsers.All)]
    public ValueTask<string> GetPortAsync() => GetAttributeAsync<string>("port");

    [BrowserCompatibilities(Browsers.All)]
    public ValueTask SetPortAsync(string port) => SetAttributeAsync("port", port);

    [BrowserCompatibilities(Browsers.All)]
    public ValueTask<string> GetProtocolAsync() => GetAttributeAsync<string>("protocol");

    [BrowserCompatibilities(Browsers.All)]
    public ValueTask SetProtocolAsync(string protocol) => SetAttributeAsync("protocol", protocol);

    [BrowserCompatibilities(Browsers.All)]
    public ValueTask<string> GetSearchAsync() => GetAttributeAsync<string>("search");

    [BrowserCompatibilities(Browsers.All)]
    public ValueTask SetSearchAsync(string search) => SetAttributeAsync("search", search);

    [BrowserCompatibilities(Browsers.All)]
    public ValueTask AssignAsync(string url) => JSReference.InvokeVoidAsync("assign", url);

    [BrowserCompatibilities(Browsers.All)]
    public ValueTask ReloadAsync() => JSReference.InvokeVoidAsync("reload");

    [BrowserCompatibilities(Browsers.All)]
    public ValueTask ReplaceAsync(string url) => JSReference.InvokeVoidAsync("replace", url);

    [BrowserCompatibilities(Browsers.All)]
    public ValueTask<string> ToStringAsync() => JSReference.InvokeAsync<string>("toString");
}