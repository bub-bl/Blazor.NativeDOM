using System.Text.Json.Serialization;

namespace Blazor.NativeDOM.API;

public class Orientation
{
    private readonly string _orientationType;

    [JsonConstructor]
    public Orientation(string orientationType)
    {
        _orientationType = orientationType;
    }

    /// <summary>
    /// The "primary" portrait mode. If the natural orientation is a portrait mode (screen height is greater than width), this will be the same as the natural orientation, and correspond to an angle of 0 degrees. If the natural orientation is a landscape mode, then the user agent can choose either portrait orientation as the portrait-primary and portrait-secondary; one of those will be assigned the angle of 90 degrees and the other will have an angle of 270 degrees.
    /// </summary>
    public static readonly Orientation PortraitPrimary = new("portrait-primary");

    /// <summary>
    /// The secondary portrait orientation. If the natural orientation is a portrait mode, this will have an angle of 180 degrees (in other words, the device is upside down relative to its natural orientation). If the natural orientation is a landscape mode, this can be either orientation as selected by the user agent: whichever was not selected for portrait-primary.
    /// </summary>
    public static readonly Orientation PortraitSecondary = new("portrait-secondary");

    /// <summary>
    /// The "primary" landscape mode. If the natural orientation is a landscape mode (screen width is greater than height), this will be the same as the natural orientation, and correspond to an angle of 0 degrees. If the natural orientation is a portrait mode, then the user agent can choose either landscape orientation as the landscape-primary with an angle of either 90 or 270 degrees (landscape-secondary will be the other orientation and angle).
    /// </summary>
    public static readonly Orientation LandscapePrimary = new("landscape-primary");

    /// <summary>
    /// The secondary landscape mode. If the natural orientation is a landscape mode, this orientation is upside down relative to the natural orientation, and will have an angle of 180 degrees. If the natural orientation is a portrait mode, this can be either orientation as selected by the user agent: whichever was not selected for landscape-primary.
    /// </summary>
    public static readonly Orientation LandscapeSecondary = new("landscape-secondary");

    public static implicit operator string(Orientation orientationType) => orientationType._orientationType;
}