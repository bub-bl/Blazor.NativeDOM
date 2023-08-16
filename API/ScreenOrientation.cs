using Blazor.NativeDOM.API.Attributes;
using Blazor.NativeDOM.Events;
using Blazor.NativeDOM.Extensions;
using Microsoft.JSInterop;

namespace Blazor.NativeDOM.API;

public class ScreenOrientation : EventTarget
{
    public ScreenOrientation(IJSRuntime jsRuntime, IJSObjectReference jsReference) : base(jsRuntime, jsReference)
    {
    }

    /// <summary>
    /// The onchange property of the ScreenOrientation interface is an event handler that processes change events for onchange event, fired when the orientation of the screen changes.
    /// </summary>
    public event Func<EventListener<Event>?> OnChange
    {
        add => Task.Run(async () => await AddEventListenerAsync("change", value.Invoke()));
        remove => Task.Run(async () => await RemoveEventListenerAsync("change", value.Invoke()));
    }

    /// <summary>
    /// Constructs a wrapper instance for a given JS Instance of a <see cref="ScreenOrientation"/>.
    /// </summary>
    /// <param name="jsRuntime">An <see cref="IJSRuntime"/> instance.</param>
    /// <param name="jsReference">A JS reference to an existing <see cref="ScreenOrientation"/>.</param>
    /// <returns>A wrapper instance for a <see cref="ScreenOrientation"/>.</returns>
    public new static Task<ScreenOrientation> CreateAsync(IJSRuntime jsRuntime,
        IJSObjectReference jsReference)
    {
        return Task.FromResult(new ScreenOrientation(jsRuntime, jsReference));
    }

    public new static async Task<ScreenOrientation> CreateAsync(IJSRuntime jsRuntime)
    {
        var helper = await jsRuntime.GetHelperAsync();
        var jsInstance = await helper.InvokeAsync<IJSObjectReference>("constructScreenOrientation");
        return new ScreenOrientation(jsRuntime, jsInstance);
    }

    /// <summary>
    /// Returns the document's current orientation angle.
    /// </summary>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask<float> GetAngleAsync() => GetAttributeAsync<float>("angle");

    /// <summary>
    /// Returns the document's current orientation type, one of "portrait-primary", "portrait-secondary", "landscape-primary", or "landscape-secondary".
    /// </summary>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public async ValueTask<Orientation> GetTypeAsync()
    {
        var type = await GetAttributeAsync<string>("type");
        return new Orientation(type);
    }

    /// <summary>
    /// Locks the orientation of the containing document to the specified orientation.
    /// </summary>
    /// <returns></returns>
    [PartiallySupported("Chrome, Edge, Firefox, Opera")]
    [BrowserCompatibilities(Browsers.All & ~Browsers.Safari & ~Browsers.SafariIOS & ~Browsers.FirefoxAndroid)]
    public ValueTask LockAsync(OrientationLock orientationLock) => JSReference.InvokeVoidAsync("lock");

    /// <summary>
    /// Unlocks the orientation of the containing document from its default orientation.
    /// </summary>
    /// <returns></returns>
    [PartiallySupported("Chrome, Edge, Firefox, Opera")]
    [BrowserCompatibilities(Browsers.All & ~Browsers.Safari & ~Browsers.SafariIOS)]
    public ValueTask UnlockAsync() => JSReference.InvokeVoidAsync("unlock");
}