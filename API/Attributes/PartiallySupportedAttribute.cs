namespace Blazor.NativeDOM.API;

[AttributeUsage(AttributeTargets.All)]
public class PartiallySupportedAttribute : Attribute
{
    public string Reason { get; }

    public PartiallySupportedAttribute(string reason = "")
    {
        Reason = reason;
    }
}