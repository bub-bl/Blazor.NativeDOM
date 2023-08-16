using Microsoft.JSInterop;

namespace Blazor.NativeDOM;

/// <summary>
/// A common interface for all classes that wrap some JS object.
/// </summary>
public interface IJSWrapper
{
    /// <summary>
    /// An <see cref="IJSObjectReference"/> to the object that is being wrapped.
    /// </summary>
    IJSObjectReference JSReference { get; }

    /// <summary>
    /// The JSRuntime that is used to invoke indirect functions on the <see cref="JSReference"/>.
    /// </summary>
    IJSRuntime JSRuntime { get; }
}