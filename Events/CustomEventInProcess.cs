using Blazor.NativeDOM.Extensions;
using Blazor.NativeDOM.WebIDL;
using Microsoft.JSInterop;

namespace Blazor.NativeDOM.Events;

/// <summary>
/// <see cref="Event"/>s using the <see cref="CustomEvent"/> interface can be used to carry custom data which is accessible from <see cref="Detail"/>.
/// </summary>
/// <remarks><see href="https://dom.spec.whatwg.org/#customevent">See the API definition here</see></remarks>
public class CustomEventInProcess : CustomEvent, IJSInProcessCreatable<CustomEventInProcess, CustomEvent>
{
    /// <summary>
    /// An in-process helper.
    /// </summary>
    protected readonly IJSInProcessObjectReference _inProcessHelper;

    /// <inheritdoc/>
    public new IJSInProcessObjectReference JSReference { get; }

    /// <inheritdoc/>
    public static async Task<CustomEventInProcess> CreateAsync(IJSRuntime jsRuntime, IJSInProcessObjectReference jsReference)
    {
        var helper = await jsRuntime.GetInProcessHelperAsync();
        return new CustomEventInProcess(jsRuntime, helper, jsReference);
    }

    /// <inheritdoc/>
    protected CustomEventInProcess(IJSRuntime jSRuntime, IJSInProcessObjectReference inProcessHelper, IJSInProcessObjectReference jSReference) : base(jSRuntime, jSReference)
    {
        _inProcessHelper = inProcessHelper;
        JSReference = jSReference;
    }

    /// <summary>
    /// The details of the <see cref="CustomEvent"/>.
    /// </summary>
    public IJSObjectReference Detail => _inProcessHelper.Invoke<IJSObjectReference>("getAttribute", JSReference, "detail");
}