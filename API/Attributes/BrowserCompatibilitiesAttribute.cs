namespace Blazor.NativeDOM.API.Attributes;

[AttributeUsage(AttributeTargets.All)]
public class BrowserCompatibilitiesAttribute : Attribute
{
    public Browsers Support { get; }

    public BrowserCompatibilitiesAttribute(Browsers support)
    {
        Support = support;
    }
}