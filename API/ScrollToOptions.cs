namespace Blazor.NativeDOM.API;

public class ScrollToOptions : ScrollOptions
{
    /// <summary>
    /// Specifies the number of pixels along the X axis to scroll the window or element.
    /// </summary>
    public float? Left { get; init; }

    /// <summary>
    /// Specifies the number of pixels along the Y axis to scroll the window or element.
    /// </summary>
    public float? Top { get; init; }
}