namespace Blazor.NativeDOM.API;

public struct ScrollBehavior
{
    private readonly string _behavior;

    private ScrollBehavior(string behavior)
    {
        _behavior = behavior;
    }

    /// <summary>
    /// <b>Auto</b> scroll behavior is determined by the computed value of
    /// </summary>
    public static ScrollBehavior Auto => new("auto");

    /// <summary>
    /// <b>Instance</b> scrolling should happen instantly in a single jump
    /// </summary>
    public static ScrollBehavior Instant => new("instant");

    /// <summary>
    /// <b>Smooth</b> scrolling should animate smoothly
    /// </summary>
    public static ScrollBehavior Smooth => new("smooth");

    public static implicit operator string(ScrollBehavior behavior) => behavior._behavior;
}