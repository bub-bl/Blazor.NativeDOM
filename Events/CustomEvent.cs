using Blazor.NativeDOM.Extensions;
using Microsoft.JSInterop;

namespace Blazor.NativeDOM.Events;

/// <summary>
/// <see cref="Event"/>s using the <see cref="CustomEvent"/> interface can be used to carry custom data which is accessible using the <see cref="GetDetailAsync"/> method.
/// </summary>
/// <remarks><see href="https://dom.spec.whatwg.org/#customevent">See the API definition here</see></remarks>
public class CustomEvent : Event, WebIDL.IJSCreatable<CustomEvent>
{
    /// <summary>
    /// Constructs a wrapper instance for a given JS Instance of a <see cref="CustomEvent"/>.
    /// </summary>
    /// <param name="jsRuntime">An <see cref="IJSRuntime"/> instance.</param>
    /// <param name="jsReference">A JS reference to an existing <see cref="CustomEvent"/>.</param>
    /// <returns>A wrapper instance for a <see cref="CustomEvent"/>.</returns>
    public static new Task<CustomEvent> CreateAsync(IJSRuntime jsRuntime, IJSObjectReference jsReference)
    {
        CustomEvent eventInstance = new(jsRuntime, jsReference);
        return Task.FromResult(eventInstance);
    }

    /// <summary>
    /// Constructs a wrapper instance using the standard constructor.
    /// </summary>
    /// <param name="jsRuntime">An <see cref="IJSRuntime"/> instance.</param>
    /// <param name="type">The type of the new <see cref="Event"/>.</param>
    /// <param name="eventInitDict">Extra options for setting whether the event bubbles and is cancelable.</param>
    /// <returns>A wrapper instance for a <see cref="CustomEvent"/>.</returns>
    public static async Task<CustomEvent> CreateAsync(IJSRuntime jsRuntime, string type, CustomEventInit? eventInitDict = null)
    {
        IJSObjectReference helper = await jsRuntime.GetHelperAsync();
        IJSObjectReference jSInstance = await helper.InvokeAsync<IJSObjectReference>("constructCustomEvent", type, eventInitDict);
        CustomEvent eventInstance = new(jsRuntime, jSInstance);
        return eventInstance;
    }

    /// <summary>
    /// Constructs a wrapper instance for a given JS Instance of a <see cref="CustomEvent"/>.
    /// </summary>
    /// <param name="jSRuntime">An <see cref="IJSRuntime"/> instance.</param>
    /// <param name="jsReference">A JS reference to an existing <see cref="CustomEvent"/>.</param>
    protected CustomEvent(IJSRuntime jSRuntime, IJSObjectReference jsReference) : base(jSRuntime, jsReference)
    {
    }

    /// <summary>
    /// The details of the <see cref="CustomEvent"/>.
    /// </summary>
    /// <returns>Any custom data the event was created with. Typically used for synthetic events.</returns>
    public async Task<IJSObjectReference?> GetDetailAsync()
    {
        var helper = await HelperTask.Value;
        return await helper.InvokeAsync<IJSObjectReference?>("getAttribute", JSReference, "detail");
    }
}