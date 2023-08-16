using System.Text.Json.Serialization;
using Blazor.NativeDOM.Abort;
using Blazor.NativeDOM.Extensions;
using Microsoft.JSInterop;

namespace Blazor.NativeDOM.API;

public class Node : BaseJSWrapper
{
    public const ushort ElementNode = 1;
    public const ushort AttributeNode = 2;
    public const ushort TextNode = 3;
    public const ushort CDATASectionNode = 4;
    [LegacyFeature] public const ushort EntityReferenceNode = 5;
    [LegacyFeature] public const ushort EntityNode = 6;
    public const ushort ProcessingInstructionNode = 7;
    public const ushort CommentNode = 8;
    public const ushort DocumentNode = 9;
    public const ushort DocumentTypeNode = 10;
    public const ushort DocumentFragmentNode = 11;
    [LegacyFeature] public const ushort NotationNode = 12;

    protected internal Node(IJSRuntime jsRuntime, IJSObjectReference jsReference) : base(jsRuntime, jsReference)
    {
    }

    /// <summary>
    /// Constructs a wrapper instance for a given JS Instance of a <see cref="Node"/>.
    /// </summary>
    /// <param name="jsRuntime">An <see cref="IJSRuntime"/> instance.</param>
    /// <param name="jsReference">A JS reference to an existing <see cref="Node"/>.</param>
    /// <returns>A wrapper instance for a <see cref="Node"/>.</returns>
    public static Task<Node> CreateAsync(IJSRuntime jsRuntime, IJSObjectReference jsReference)
    {
        return Task.FromResult(new Node(jsRuntime, jsReference));
    }
    
    /// <summary>
    /// Constructs a wrapper instance using the standard constructor.
    /// </summary>
    /// <param name="jsRuntime">An <see cref="IJSRuntime"/> instance.</param>
    /// <returns>A wrapper instance for a <see cref="AbortController"/>.</returns>
    public static async Task<Node> CreateAsync(IJSRuntime jsRuntime)
    {
        var helper = await jsRuntime.GetHelperAsync();
        var jsInstance = await helper.InvokeAsync<IJSObjectReference>("constructNode");
        var node = new Node(jsRuntime, jsInstance);
        return node;
    }
    
    public async Task<string> GetBaseUriAsync()
    {
        var helper = await HelperTask.Value;
        return await helper.InvokeAsync<string>("getAttribute", JSReference, "baseURI");
    }
    
    public ValueTask<Node> CloneNodeAsync(bool deep = false)
    {
        return JSReference.InvokeAsync<Node>("cloneNode", deep);
    }
}

public enum NodeType : ushort
{
    [JsonPropertyName("ELEMENT_NODE")] ElementNode = 1,
    [JsonPropertyName("ATTRIBUTE_NODE")] AttributeNode = 2,
    [JsonPropertyName("TEXT_NODE")] TextNode = 3,

    [JsonPropertyName("CDATA_SECTION_NODE")]
    CDATASectionNode = 4,

    [JsonPropertyName("PROCESSING_INSTRUCTION_NODE")]
    ProcessingInstructionNode = 7,
    [JsonPropertyName("COMMENT_NODE")] CommentNode = 8,
    [JsonPropertyName("DOCUMENT_NODE")] DocumentNode = 9,

    [JsonPropertyName("DOCUMENT_TYPE_NODE")]
    DocumentTypeNode = 10,

    [JsonPropertyName("DOCUMENT_FRAGMENT_NODE")]
    DocumentFragmentNode = 11,
}

public class RootNodeOptions
{
    [JsonPropertyName("composed")] public bool Composed { get; }
}