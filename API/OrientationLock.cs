using System.Text.Json.Serialization;

namespace Blazor.NativeDOM.API;

public struct OrientationLock
{
    private readonly string _orientationLockType;

    [JsonConstructor]
    internal OrientationLock(string orientationType)
    {
        _orientationLockType = orientationType;
    }

    /// <summary>
    /// Any of portrait-primary, portrait-secondary, landscape-primary or landscape-secondary.
    /// </summary>
    public static readonly OrientationLock Any = new("any");

    /// <summary>
    /// The natural orientation of the screen from the underlying operating system: either portrait-primary or landscape-primary.
    /// </summary>
    public static readonly OrientationLock Natural = new("natural");

    /// <summary>
    /// An orientation where screen width is greater than the screen height. Depending on the platform convention, this may be landscape-primary, landscape-secondary, or both.
    /// </summary>
    public static readonly OrientationLock Landscape = new("landscape");

    /// <summary>
    /// An orientation where screen height is greater than the screen width. Depending on the platform convention, this may be portrait-primary, portrait-secondary, or both.
    /// </summary>
    public static readonly OrientationLock Portrait = new("portrait");

    /// <summary>
    /// The "primary" portrait mode. If the natural orientation is a portrait mode (screen height is greater than width), this will be the same as the natural orientation, and correspond to an angle of 0 degrees. If the natural orientation is a landscape mode, then the user agent can choose either portrait orientation as the portrait-primary and portrait-secondary; one of those will be assigned the angle of 90 degrees and the other will have an angle of 270 degrees.
    /// </summary>
    public static readonly OrientationLock PortraitPrimary = new("portrait-primary");

    /// <summary>
    /// The secondary portrait orientation. If the natural orientation is a portrait mode, this will have an angle of 180 degrees (in other words, the device is upside down relative to its natural orientation). If the natural orientation is a landscape mode, this can be either orientation as selected by the user agent: whichever was not selected for portrait-primary.
    /// </summary>
    public static readonly OrientationLock PortraitSecondary = new("portrait-secondary");

    /// <summary>
    /// The "primary" landscape mode. If the natural orientation is a landscape mode (screen width is greater than height), this will be the same as the natural orientation, and correspond to an angle of 0 degrees. If the natural orientation is a portrait mode, then the user agent can choose either landscape orientation as the landscape-primary with an angle of either 90 or 270 degrees (landscape-secondary will be the other orientation and angle).
    /// </summary>
    public static readonly OrientationLock LandscapePrimary = new("landscape-primary");

    /// <summary>
    /// The secondary landscape mode. If the natural orientation is a landscape mode, this orientation is upside down relative to the natural orientation, and will have an angle of 180 degrees. If the natural orientation is a portrait mode, this can be either orientation as selected by the user agent: whichever was not selected for landscape-primary.
    /// </summary>
    public static readonly OrientationLock LandscapeSecondary = new("landscape-secondary");

    public static implicit operator string(OrientationLock orientationType) => orientationType._orientationLockType;
}