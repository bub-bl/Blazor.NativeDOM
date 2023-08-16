using Blazor.NativeDOM.Extensions;
using Blazor.NativeDOM.WebIDL;
using Microsoft.JSInterop;

namespace Blazor.NativeDOM.Events;

/// <inheritdoc/>
public class EventListenerInProcess<TInProcessEvent> : EventListenerInProcess<TInProcessEvent, TInProcessEvent> where TInProcessEvent : Event, IJSInProcessCreatable<TInProcessEvent, TInProcessEvent>
{
    /// <inheritdoc/>
    protected EventListenerInProcess(IJSRuntime jsRuntime, IJSInProcessObjectReference inProcessHelper, IJSInProcessObjectReference jsReference) : base(jsRuntime, inProcessHelper, jsReference)
    {
    }
}

/// <inheritdoc/>
public class EventListenerInProcess<TInProcessEvent, TEvent> : EventListener<TEvent> where TEvent : Event, IJSCreatable<TEvent> where TInProcessEvent : IJSInProcessCreatable<TInProcessEvent, TEvent>
{
    /// <summary>
    /// The synchronous callback.
    /// </summary>
    protected new Action<TInProcessEvent>? Callback;

    /// <summary>
    /// The asynchronous callback.
    /// </summary>
    protected new Func<TInProcessEvent, Task>? AsyncCallback;

    /// <summary>s
    /// An in-process helper.
    /// </summary>
    protected readonly IJSInProcessObjectReference InProcessHelper;

    /// <inheritdoc cref="IJSWrapper.JSReference" />
    public new IJSInProcessObjectReference JSReference { get; }

    /// <inheritdoc cref="EventListener{TEvent}.CreateAsync(IJSRuntime, Action{TEvent})"/>
    public static async Task<EventListenerInProcess<TInProcessEvent, TEvent>> CreateAsync(IJSRuntime jSRuntime, Action<TInProcessEvent> callback)
    {
        var helper = await jSRuntime.GetInProcessHelperAsync();
        var jSInstance = await helper.InvokeAsync<IJSInProcessObjectReference>("constructEventListener");
        EventListenerInProcess<TInProcessEvent, TEvent> eventListener = new(jSRuntime, helper, jSInstance)
        {
            Callback = callback
        };
        await helper.InvokeVoidAsync("registerInProcessEventHandlerAsync", DotNetObjectReference.Create(eventListener), jSInstance);
        return eventListener;
    }

    /// <inheritdoc cref="EventListener{TEvent}.CreateAsync(IJSRuntime, Func{TEvent, Task})"/>
    public static async Task<EventListenerInProcess<TInProcessEvent, TEvent>> CreateAsync(IJSRuntime jSRuntime, Func<TInProcessEvent, Task> callback)
    {
        var helper = await jSRuntime.GetInProcessHelperAsync();
        var jSInstance = await helper.InvokeAsync<IJSInProcessObjectReference>("constructEventListener");
        EventListenerInProcess<TInProcessEvent, TEvent> eventListener = new(jSRuntime, helper, jSInstance)
        {
            AsyncCallback = callback
        };
        await helper.InvokeVoidAsync("registerInProcessEventHandlerAsync", DotNetObjectReference.Create(eventListener), jSInstance);
        return eventListener;
    }

    /// <summary>
    /// Constructs a wrapper instance for a given JS Instance of a <see cref="EventTarget"/>.
    /// </summary>
    /// <param name="jsRuntime">An <see cref="IJSRuntime"/> instance.</param>
    /// <param name="inProcessHelper">An in-process helper instance.</param>
    /// <param name="jsReference">A JS reference to an existing <see cref="EventTarget"/>.</param>
    protected EventListenerInProcess(IJSRuntime jsRuntime, IJSInProcessObjectReference inProcessHelper, IJSInProcessObjectReference jsReference) : base(jsRuntime, jsReference)
    {
        InProcessHelper = inProcessHelper;
        JSReference = jsReference;
    }

    /// <inheritdoc/>
    [JSInvokable]
    public async Task HandleEventInProcessAsync(IJSInProcessObjectReference jsObjectReference)
    {
        if (Callback is not null)
            Callback.Invoke(await TInProcessEvent.CreateAsync(JSRuntime, jsObjectReference));
        else if (AsyncCallback is not null)
            await AsyncCallback.Invoke(await TInProcessEvent.CreateAsync(JSRuntime, jsObjectReference));
    }
}