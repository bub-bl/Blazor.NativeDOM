namespace Blazor.NativeDOM.API;

public class ScrollOptions
{
    /// <summary>
    /// Determines whether scrolling is instant or animates smoothly. This option is a string which must take one of the following values:
    /// </summary>
    public ScrollBehavior? Behavior { get; init; }
}