using Blazor.NativeDOM.Extensions;
using Blazor.NativeDOM.WebIDL;
using Microsoft.JSInterop;

namespace Blazor.NativeDOM.Events;

/// <summary>
/// An <see cref="EventListener{TEvent}" /> can be used to observe a specific <see cref="Event"/>.
/// </summary>
/// <remarks><see href="https://dom.spec.whatwg.org/#callbackdef-eventlistener">See the API definition here</see></remarks>
public class EventListener<TEvent> : BaseJSWrapper where TEvent : Event, IJSCreatable<TEvent>
{
    /// <summary>
    /// The synchronous callback.
    /// </summary>
    protected Action<TEvent>? Callback;
    /// <summary>
    /// The asynchronous callback.
    /// </summary>
    protected Func<TEvent, Task>? AsyncCallback;

    /// <summary>
    /// Constructs a wrapper instance using the standard constructor.
    /// </summary>
    /// <param name="jsRuntime">An <see cref="IJSRuntime"/> instance.</param>
    /// <param name="callback">The action that will be invoked once the event happen.</param>
    /// <returns>A wrapper instance for a <see cref="EventListener{TEvent}"/>.</returns>
    public static async Task<EventListener<TEvent>> CreateAsync(IJSRuntime jsRuntime, Action<TEvent> callback)
    {
        var helper = await jsRuntime.GetHelperAsync();
        var jSInstance = await helper.InvokeAsync<IJSObjectReference>("constructEventListener");
        EventListener<TEvent> eventListener = new(jsRuntime, jSInstance)
        {
            Callback = callback
        };
        await helper.InvokeVoidAsync("registerEventHandlerAsync", DotNetObjectReference.Create(eventListener), jSInstance);
        return eventListener;
    }

    /// <summary>
    /// Constructs a wrapper instance using the standard constructor.
    /// </summary>
    /// <param name="jsRuntime">An <see cref="IJSRuntime"/> instance.</param>
    /// <param name="callback">The async action that will be invoked once the event happen.</param>
    /// <returns>A wrapper instance for a <see cref="EventListener{TEvent}"/>.</returns>
    public static async Task<EventListener<TEvent>> CreateAsync(IJSRuntime jsRuntime, Func<TEvent, Task> callback)
    {
        var helper = await jsRuntime.GetHelperAsync();
        var jSInstance = await helper.InvokeAsync<IJSObjectReference>("constructEventListener");
        EventListener<TEvent> eventListener = new(jsRuntime, jSInstance)
        {
            AsyncCallback = callback
        };
        await helper.InvokeVoidAsync("registerEventHandlerAsync", DotNetObjectReference.Create(eventListener), jSInstance);
        return eventListener;
    }

    /// <summary>
    /// Constructs a wrapper instance for a given JS Instance of a <see cref="EventListener{TEvent}"/>.
    /// </summary>
    /// <param name="jsRuntime">An <see cref="IJSRuntime"/> instance.</param>
    /// <param name="jsReference">A JS reference to an existing <see cref="EventListener{TEvent}"/>.</param>
    protected EventListener(IJSRuntime jsRuntime, IJSObjectReference jsReference) : base(jsRuntime, jsReference) { }

    /// <summary>
    /// The method that will be invoked from JS when the event happens which will invoke the action that this <see cref="EventListener{TEvent}"/> was constructed from.
    /// </summary>
    /// <param name="jsObjectReference">A JS reference to the event.</param>
    [JSInvokable]
    public async Task HandleEventAsync(IJSObjectReference jsObjectReference)
    {
        if (Callback is not null)
            Callback.Invoke(await TEvent.CreateAsync(JSRuntime, jsObjectReference));
        else if (AsyncCallback is not null)
            await AsyncCallback.Invoke(await TEvent.CreateAsync(JSRuntime, jsObjectReference));
    }
}