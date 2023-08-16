using Blazor.NativeDOM.API.Attributes;
using Blazor.NativeDOM.Events;
using Blazor.NativeDOM.Extensions;
using Blazor.NativeDOM.WebIDL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.JSInterop;

namespace Blazor.NativeDOM.API;

public class Screen : BaseJSWrapper
{
    public Screen(IJSRuntime jsRuntime, IJSObjectReference jsReference) : base(jsRuntime, jsReference)
    {
    }

    /// <summary>
    /// Constructs a wrapper instance for a given JS Instance of a <see cref="Screen"/>.
    /// </summary>
    /// <param name="jsRuntime">An <see cref="IJSRuntime"/> instance.</param>
    /// <param name="jsReference">A JS reference to an existing <see cref="Screen"/>.</param>
    /// <returns>A wrapper instance for a <see cref="Screen"/>.</returns>
    public static Task<Screen> CreateAsync(IJSRuntime jsRuntime, IJSObjectReference jsReference)
    {
        return Task.FromResult(new Screen(jsRuntime, jsReference));
    }

    public static async Task<Screen> CreateAsync(IJSRuntime jsRuntime)
    {
        var helper = await jsRuntime.GetHelperAsync();
        var jsInstance = await helper.InvokeAsync<IJSObjectReference>("constructScreen");
        return new Screen(jsRuntime, jsInstance);
    }

    /// <summary>
    /// Returns the height, in CSS pixels, of the space available for Web content on the screen.
    /// </summary>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask<float> GetAvailableHeightAsync() => GetAttributeAsync<float>("availHeight");

    /// <summary>
    /// Returns the amount of horizontal space (in pixels) available to the window.
    /// </summary>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask<float> GetAvailableWidthAsync() => GetAttributeAsync<float>("availWidth");

    /// <summary>
    /// Returns the color depth of the screen.
    /// </summary>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask<float> GetColorDepthAsync() => GetAttributeAsync<float>("colorDepth");

    /// <summary>
    /// Returns the height of the screen in pixels.
    /// </summary>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask<float> GetHeightAsync() => GetAttributeAsync<float>("height");

    /// <summary>
    /// Returns the width of the screen in CSS pixels.
    /// </summary>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask<float> GetWidthAsync() => GetAttributeAsync<float>("width");

    /// <summary>
    /// Returns the current orientation of the screen.
    /// </summary>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask<ScreenOrientation> GetOrientationAsync() =>
        GetAttributeFromRefAsync<ScreenOrientation>("orientation");

    /// <summary>
    /// Returns the bit depth of the screen.
    /// </summary>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask<float> GetPixelDepthAsync() => GetAttributeAsync<float>("pixelDepth");
}