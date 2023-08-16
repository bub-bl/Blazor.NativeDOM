using Blazor.NativeDOM.Events;
using Blazor.NativeDOM.Extensions;
using Blazor.NativeDOM.WebIDL;
using Microsoft.JSInterop;

namespace Blazor.NativeDOM.Abort;

/// <summary>
/// Though promises do not have a built-in aborting mechanism, many APIs using them require abort semantics.
/// <see cref="AbortController"/> is meant to support these requirements by providing an <see cref="AbortAsync(IJSObjectReference?)"/> method that toggles the state of a corresponding <see cref="AbortSignal{TAbortEvent}"/> object.
/// The API which wishes to support aborting can accept an <see cref="AbortSignal{TAbortEvent}"/> object, and use its state to determine how to proceed.
/// </summary>
/// <remarks><see href="https://dom.spec.whatwg.org/#abortcontroller">See the API definition here</see></remarks>
internal class AbortController : BaseJSWrapper
{
    /// <summary>
    /// Constructs a wrapper instance for a given JS Instance of a <see cref="AbortController"/>.
    /// </summary>
    /// <param name="jsRuntime">An <see cref="IJSRuntime"/> instance.</param>
    /// <param name="jsReference">A JS reference to an existing <see cref="AbortController"/>.</param>
    /// <returns>A wrapper instance for a <see cref="AbortController"/>.</returns>
    public static Task<AbortController> CreateAsync(IJSRuntime jsRuntime, IJSObjectReference jsReference)
    {
        return Task.FromResult(new AbortController(jsRuntime, jsReference));
    }

    /// <summary>
    /// Constructs a wrapper instance using the standard constructor.
    /// </summary>
    /// <param name="jsRuntime">An <see cref="IJSRuntime"/> instance.</param>
    /// <returns>A wrapper instance for a <see cref="AbortController"/>.</returns>
    public static async Task<AbortController> CreateAsync(IJSRuntime jsRuntime)
    {
        var helper = await jsRuntime.GetHelperAsync();
        var jsInstance = await helper.InvokeAsync<IJSObjectReference>("constructAbortController");
        var abortController = new AbortController(jsRuntime, jsInstance);
        return abortController;
    }

    public AbortController(IJSRuntime jsRuntime, IJSObjectReference jsReference) : base(jsRuntime, jsReference)
    {
    }

    public async Task<TAbortEvent> GetSignalAsync<TAbortEvent>() where TAbortEvent : Event, IJSCreatable<TAbortEvent>
    {
        var helper = await HelperTask.Value;
        var jsInstance = await helper.InvokeAsync<IJSObjectReference>("getAttribute", JSReference, "signal");
        return await TAbortEvent.CreateAsync(JSRuntime, jsInstance);
    }

    public async Task AbortAsync(string? reason = null)
    {
        await JSReference.InvokeVoidAsync("abort", reason);
    }

    public async Task AbortAsync(IJSObjectReference? reason = null)
    {
        await JSReference.InvokeVoidAsync("abort", reason);
    }
}