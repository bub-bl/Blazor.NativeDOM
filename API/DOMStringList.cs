using Blazor.NativeDOM.API.Attributes;
using Blazor.NativeDOM.Extensions;
using Microsoft.JSInterop;

namespace Blazor.NativeDOM.API;

public class DOMStringList : BaseJSWrapper
{
    public DOMStringList(IJSRuntime jsRuntime, IJSObjectReference jsReference) : base(jsRuntime, jsReference)
    {
    }
    
    /// <summary>
    /// Constructs a wrapper instance for a given JS Instance of a <see cref="DOMStringList"/>.
    /// </summary>
    /// <param name="jsRuntime">An <see cref="IJSRuntime"/> instance.</param>
    /// <param name="jsReference">A JS reference to an existing <see cref="DOMStringList"/>.</param>
    /// <returns>A wrapper instance for a <see cref="DOMStringList"/>.</returns>
    public static Task<DOMStringList> CreateAsync(IJSRuntime jsRuntime, IJSObjectReference jsReference)
    {
        return Task.FromResult(new DOMStringList(jsRuntime, jsReference));
    }

    public static async Task<DOMStringList> CreateAsync(IJSRuntime jsRuntime)
    {
        var helper = await jsRuntime.GetHelperAsync();
        var jsInstance = await helper.InvokeAsync<IJSObjectReference>("constructDOMStringList");
        return new DOMStringList(jsRuntime, jsInstance);
    }
    
    /// <summary>
    /// Indicates the number of strings in the DOMStringList.
    /// </summary>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask<int> GetLengthAsync() => GetAttributeAsync<int>("length");

    /// <summary>
    /// Returns a boolean indicating whether the given string is in the list.
    /// </summary>
    /// <param name="value">A string you want to check for the existence of in the list.</param>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask<bool> ContainsAsync(string value) => JSReference.InvokeAsync<bool>("contains", value);

    /// <summary>
    /// Returns a string from a DOMStringList by index.
    /// </summary>
    /// <param name="index">The index of the string to get. The index is zero-based.</param>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask<string?> GetItemAsync(int index) => JSReference.InvokeAsync<string?>("item", index);
}