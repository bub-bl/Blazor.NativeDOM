using Blazor.NativeDOM.API;
using Blazor.NativeDOM.Extensions;
using Blazor.NativeDOM.WebIDL;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blazor.NativeDOM.Events;

/// <inheritdoc />
public class EventTargetInProcess : EventTarget, IEventTargetInProcess
{
    /// <summary>
    /// An in-process helper.
    /// </summary>
    protected readonly IJSInProcessObjectReference InProcessHelper;

    /// <inheritdoc />
    public new IJSInProcessObjectReference JSReference { get; }

    /// <summary>
    /// Constructs a wrapper instance for a given JS Instance of a <see cref="EventTargetInProcess"/>.
    /// </summary>
    /// <param name="jsRuntime">An <see cref="IJSRuntime"/> instance.</param>
    /// <param name="jsReference">A JS reference to an existing <see cref="EventTargetInProcess"/>.</param>
    /// <returns>A wrapper instance for a <see cref="EventTargetInProcess"/>.</returns>
    public static async Task<EventTargetInProcess> CreateAsync(IJSRuntime jsRuntime,
        IJSInProcessObjectReference jsReference)
    {
        var helper = await jsRuntime.GetInProcessHelperAsync();
        return new EventTargetInProcess(jsRuntime, helper, jsReference);
    }

    /// <summary>
    /// Constructs a wrapper instance for a given a targetable <see cref="ElementReference"/>.
    /// </summary>
    /// <param name="jsRuntime">An <see cref="IJSRuntime"/> instance.</param>
    /// <param name="element">A <see cref="ElementReference"/> to some element that is targetable.</param>
    /// <returns>A wrapper instance for a <see cref="EventTarget"/>.</returns>
    public static new async Task<EventTargetInProcess> CreateAsync(IJSRuntime jsRuntime, ElementReference element)
    {
        var helper = await jsRuntime.GetInProcessHelperAsync();
        var jSReference = await helper.InvokeAsync<IJSInProcessObjectReference>("getJSReference", element);
        EventTargetInProcess eventTarget = new(jsRuntime, helper, jSReference);

        return eventTarget;
    }

    /// <summary>
    /// Constructs a wrapper instance using the standard constructor.
    /// </summary>
    /// <param name="jsRuntime">An <see cref="IJSRuntime"/> instance.</param>
    /// <returns>A wrapper instance for a <see cref="EventTarget"/>.</returns>
    public static new async Task<EventTargetInProcess> CreateAsync(IJSRuntime jsRuntime)
    {
        var helper = await jsRuntime.GetInProcessHelperAsync();
        var jSInstance = await helper.InvokeAsync<IJSInProcessObjectReference>("constructEventTarget");
        EventTargetInProcess eventTarget = new(jsRuntime, helper, jSInstance);

        return eventTarget;
    }

    /// <summary>
    /// Constructs a wrapper instance for a given JS Instance of a <see cref="EventTarget"/>.
    /// </summary>
    /// <param name="jsRuntime">An <see cref="IJSRuntime"/> instance.</param>
    /// <param name="inProcessHelper">An in-process helper instance.</param>
    /// <param name="jsReference">A JS reference to an existing <see cref="EventTarget"/>.</param>
    protected internal EventTargetInProcess(IJSRuntime jsRuntime, IJSInProcessObjectReference inProcessHelper,
        IJSInProcessObjectReference jsReference) : base(jsRuntime, jsReference)
    {
        InProcessHelper = inProcessHelper;
        JSReference = jsReference;
    }

    /// <inheritdoc/>
    public void AddEventListener<TInProcessEvent, TEvent>(string type,
        EventListenerInProcess<TInProcessEvent, TEvent>? callback, AddEventListenerOptions? options = null) where TEvent : Event, IJSCreatable<TEvent> where TInProcessEvent : IJSInProcessCreatable<TInProcessEvent, TEvent>
    {
        this.AddEventListener(InProcessHelper, type, callback, options);
    }

    /// <inheritdoc/>
    public void AddEventListener<TInProcessEvent, TEvent>(EventListenerInProcess<TInProcessEvent, TEvent>? callback,
        AddEventListenerOptions? options = null) where TEvent : Event, IJSCreatable<TEvent> where TInProcessEvent : IJSInProcessCreatable<TInProcessEvent, TEvent>
    {
        this.AddEventListener(InProcessHelper, callback, options);
    }

    /// <inheritdoc/>
    public void RemoveEventListener<TInProcessEvent, TEvent>(string type,
        EventListenerInProcess<TInProcessEvent, TEvent>? callback, EventListenerOptions? options = null)
        where TEvent : Event, IJSCreatable<TEvent>
        where TInProcessEvent : IJSInProcessCreatable<TInProcessEvent, TEvent>
    {
        this.RemoveEventListener(InProcessHelper, type, callback, options);
    }

    /// <inheritdoc/>
    public void RemoveEventListener<TInProcessEvent, TEvent>(EventListenerInProcess<TInProcessEvent, TEvent>? callback,
        EventListenerOptions? options = null)
        where TEvent : Event, IJSCreatable<TEvent>
        where TInProcessEvent : IJSInProcessCreatable<TInProcessEvent, TEvent>
    {
        this.RemoveEventListener(InProcessHelper, callback, options);
    }

    /// <inheritdoc/>
    public bool DispatchEvent(Event eventInstance)
    {
        return IEventTargetInProcessExtensions.DispatchEvent(this, eventInstance);
    }
}