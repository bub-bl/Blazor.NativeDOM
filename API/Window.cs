using Blazor.NativeDOM.API.Attributes;
using Blazor.NativeDOM.Extensions;
using Microsoft.JSInterop;

namespace Blazor.NativeDOM.API;

public class Window : BaseJSWrapper
{
    public Window(IJSRuntime jsRuntime, IJSObjectReference jsReference) : base(jsRuntime, jsReference)
    {
    }

    /// <summary>
    /// Constructs a wrapper instance for a given JS Instance of a <see cref="Window"/>.
    /// </summary>
    /// <param name="jsRuntime">An <see cref="IJSRuntime"/> instance.</param>
    /// <param name="jsReference">A JS reference to an existing <see cref="Window"/>.</param>
    /// <returns>A wrapper instance for a <see cref="Window"/>.</returns>
    internal static Task<Window> CreateAsync(IJSRuntime jsRuntime, IJSObjectReference jsReference)
    {
        return Task.FromResult(new Window(jsRuntime, jsReference));
    }

    internal static async Task<Window> CreateAsync(IJSRuntime jsRuntime)
    {
        var helper = await jsRuntime.GetHelperAsync();
        var jsInstance = await helper.InvokeAsync<IJSObjectReference>("constructWindow");
        return new Window(jsRuntime, jsInstance);
    }

    public ValueTask<bool> GetClosedAsync() => GetAttributeAsync<bool>("closed");

    /// <summary>
    /// Get the name of the window's browsing context.
    /// </summary>
    /// <returns>Return the window name.</returns>
    public ValueTask<string> GetNameAsync() => GetAttributeAsync<string>("name");

    /// <summary>
    /// Set the name of the window's browsing context.
    /// </summary>
    /// <param name="name">The name of the window.</param>
    public ValueTask SetNameAsync(string name) => SetAttributeAsync("name", name);

    public ValueTask<float> GetDevicePixelRatioAsync() => GetAttributeAsync<float>("devicePixelRatio");

    public ValueTask<float> GetInnerHeightAsync() => GetAttributeAsync<float>("innerHeight");

    public ValueTask<float> GetInnerWidthAsync() => GetAttributeAsync<float>("innerWidth");

    [BrowserCompatibilities(Browsers.All)]
    public ValueTask<int> GetLengthAsync() => GetAttributeAsync<int>("length");

    public ValueTask<Location> GetLocationAsync() => GetAttributeFromRefAsync<Location>("location");

    public ValueTask SetLocationAsync(string href) => SetAttributeAsync("location", href);

    [BrowserCompatibilities(Browsers.All)]
    public ValueTask<float> GetOuterHeightAsync() => GetAttributeAsync<float>("outerHeight");

    [BrowserCompatibilities(Browsers.All)]
    public ValueTask<float> GetOuterWidthAsync() => GetAttributeAsync<float>("outerWidth");

    /// <summary>
    /// Returns a reference to the screen object associated with the window.
    /// </summary>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask<Screen> GetScreenAsync() => GetAttributeFromRefAsync<Screen>("screen");

    /// <summary>
    /// Returns the horizontal distance, in CSS pixels, from the left border of the user's browser viewport to the left side of the screen.
    /// </summary>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask<float> GetScreenLeftAsync() => GetAttributeAsync<float>("screenLeft");

    /// <summary>
    /// Returns the vertical distance, in CSS pixels, from the top border of the user's browser viewport to the top side of the screen.
    /// </summary>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask<float> GetScreenTopAsync() => GetAttributeAsync<float>("screenTop");

    /// <summary>
    /// Returns the horizontal distance, in CSS pixels, of the left border of the user's browser viewport to the left side of the screen.
    /// </summary>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask<float> GetScreenXAsync() => GetAttributeAsync<float>("screenX");

    /// <summary>
    /// Returns the vertical distance, in CSS pixels, of the top border of the user's browser viewport to the top edge of the screen.
    /// </summary>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask<float> GetScreenYAsync() => GetAttributeAsync<float>("screenY");

    /// <summary>
    /// Returns the number of pixels that the document is currently scrolled horizontally.
    /// </summary>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All & ~Browsers.Safari & ~Browsers.SafariIOS)]
    public ValueTask<float> GetScrollXAsync() => GetAttributeAsync<float>("scrollX");

    /// <summary>
    /// Returns the number of pixels that the document is currently scrolled vertically.
    /// </summary>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All & ~Browsers.Safari & ~Browsers.SafariIOS)]
    public ValueTask<float> GetScrollYAsync() => GetAttributeAsync<float>("scrollY");

    /// <summary>
    /// Instructs the browser to display a dialog with an optional message, and to wait until the user dismisses the dialog.
    /// <br></br><br></br>
    /// Under some conditions — for example, when the user switches tabs — the browser may not actually display a dialog, or may not wait for the user to dismiss the dialog.
    /// </summary>
    /// <param name="message">A string you want to display in the alert dialog, or, alternatively, an object that is converted into a string and displayed.</param>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask AlertAsync(string? message) => JSReference.InvokeVoidAsync("alert", message);

    /// <summary>
    /// Shifts focus away from the window.
    /// </summary>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask BlurAsync() => JSReference.InvokeVoidAsync("blur");

    /// <summary>
    /// Cancels a callback previously scheduled
    /// </summary>
    /// <param name="handle">The ID value returned by <b>RequestIdleCallback()</b> when the callback was established.</param>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All & ~Browsers.Safari & ~Browsers.SafariIOS)]
    public ValueTask CancelIdleCallbackAsync(int handle) => JSReference.InvokeVoidAsync("cancelIdleCallback", handle);

    /// <summary>
    /// Closes the current window, or the window on which it was called.
    /// </summary>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask CloseAsync() => JSReference.InvokeVoidAsync("close");

    /// <summary>
    /// Instructs the browser to display a dialog with an optional message, and to wait until the user either confirms or cancels the dialog.
    /// <br></br><br></br>
    /// Under some conditions — for example, when the user switches tabs — the browser may not actually display a dialog, or may not wait for the user to confirm or cancel the dialog.
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask<bool> ConfirmAsync(string? message) => JSReference.InvokeAsync<bool>("confirm", message);

    /// <summary>
    /// Makes a request to bring the window to the front. It may fail due to user settings and the window isn't guaranteed to be frontmost before this method returns.
    /// </summary>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask FocusAsync() => JSReference.InvokeVoidAsync("focus");

    /// <summary>
    /// Moves the current window by a specified amount.
    /// </summary>
    /// <param name="x">is the amount of pixels to move the window horizontally. Positive values are to the right, while negative values are to the left.</param>
    /// <param name="y">is the amount of pixels to move the window vertically. Positive values are down, while negative values are up.</param>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask MoveByAsync(int x, int y) => JSReference.InvokeVoidAsync("moveBy", x, y);

    /// <summary>
    /// Moves the current window to the specified coordinates.
    /// </summary>
    /// <param name="x">is the horizontal coordinate to be moved to.</param>
    /// <param name="y">is the vertical coordinate to be moved to.</param>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask MoveToAsync(int x, int y) => JSReference.InvokeVoidAsync("moveTo", x, y);

    /// <summary>
    /// Opens the print dialog to print the current document.
    /// <br></br><br></br>
    /// If the document is still loading when this function is called, then the document will finish loading before opening the print dialog.
    /// <br></br><br></br>
    /// This method will block while the print dialog is open.
    /// </summary>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask PrintAsync() => JSReference.InvokeVoidAsync("print");

    /// <summary>
    /// Instructs the browser to display a dialog with an optional message prompting the user to input some text, and to wait until the user either submits the text or cancels the dialog.
    /// <br></br><br></br>
    /// Under some conditions — for example, when the user switches tabs — the browser may not actually display a dialog, or may not wait for the user to submit text or to cancel the dialog.
    /// </summary>
    /// <param name="message">A string of text to display to the user. Can be omitted if there is nothing to show in the prompt window.</param>
    /// <param name="default">A string containing the default value displayed in the text input field.</param>
    /// <returns>A string containing the text entered by the user, or <b>null</b>.</returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask<string?> PromptAsync(string? message, string? @default) =>
        JSReference.InvokeAsync<string?>("prompt", message, @default);

    /// <summary>
    /// Resizes the current window by a specified amount.
    /// </summary>
    /// <param name="x">is the number of pixels to grow the window horizontally.</param>
    /// <param name="y">is the number of pixels to grow the window vertically.</param>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask ResizeByAsync(int x, int y) => JSReference.InvokeVoidAsync("resizeBy", x, y);

    /// <summary>
    /// Dynamically resizes the window
    /// </summary>
    /// <param name="width">An integer representing the new outerWidth in pixels (including scroll bars, title bars, etc.).</param>
    /// <param name="height">An integer value representing the new outerHeight in pixels (including scroll bars, title bars, etc.).</param>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask ResizeToAsync(int width, int height) => JSReference.InvokeVoidAsync("resizeTo", width, height);

    /// <summary>
    /// Scrolls the window to a particular place in the document.
    /// </summary>
    /// <param name="options"></param>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask Scroll(ScrollToOptions? options = null) => JSReference.InvokeVoidAsync("scroll", options);

    /// <summary>
    /// Scrolls the window to a particular place in the document.
    /// </summary>
    /// <param name="x">is the pixel along the horizontal axis of the document that you want displayed in the upper left.</param>
    /// <param name="y">is the pixel along the vertical axis of the document that you want displayed in the upper left.</param>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask Scroll(int x, int y) => JSReference.InvokeVoidAsync("scroll", x, y);

    /// <summary>
    /// Scrolls the document in the window by the given amount.
    /// </summary>
    /// <param name="options"></param>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask ScrollBy(ScrollToOptions? options = null) => JSReference.InvokeVoidAsync("scrollBy", options);

    /// <summary>
    /// Scrolls the document in the window by the given amount.
    /// </summary>
    /// <param name="x">is the horizontal pixel value that you want to scroll by.</param>
    /// <param name="y">is the vertical pixel value that you want to scroll by.</param>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask ScrollBy(int x, int y) => JSReference.InvokeVoidAsync("scrollBy", x, y);

    /// <summary>
    /// Scrolls to a particular set of coordinates in the document.
    /// </summary>
    /// <param name="options"></param>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask ScrollTo(ScrollToOptions? options = null) => JSReference.InvokeVoidAsync("scrollTo", options);

    /// <summary>
    /// Scrolls to a particular set of coordinates in the document.
    /// </summary>
    /// <param name="x">is the pixel along the horizontal axis of the document that you want displayed in the upper left.</param>
    /// <param name="y">is the pixel along the vertical axis of the document that you want displayed in the upper left.</param>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask ScrollTo(int x, int y) => JSReference.InvokeVoidAsync("scrollTo", x, y);

    /// <summary>
    /// Stops further resource loading in the current browsing context, equivalent to the stop button in the browser.
    /// <br></br><br></br>
    /// Because of how scripts are executed, this method cannot interrupt its parent document's loading, but it will stop its images, new windows, and other still-loading objects.
    /// </summary>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask Stop() => JSReference.InvokeVoidAsync("stop");
}