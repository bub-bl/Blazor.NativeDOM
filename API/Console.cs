using Blazor.NativeDOM.API.Attributes;
using Blazor.NativeDOM.Extensions;
using Microsoft.JSInterop;

namespace Blazor.NativeDOM.API;

public class Console : BaseJSWrapper
{
    public Console(IJSRuntime jsRuntime, IJSObjectReference jsReference) : base(jsRuntime, jsReference)
    {
    }

    /// <summary>
    /// Constructs a wrapper instance for a given JS Instance of a <see cref="Console"/>.
    /// </summary>
    /// <param name="jsRuntime">An <see cref="IJSRuntime"/> instance.</param>
    /// <param name="jsReference">A JS reference to an existing <see cref="Console"/>.</param>
    /// <returns>A wrapper instance for a <see cref="Console"/>.</returns>
    public static Task<Console> CreateAsync(IJSRuntime jsRuntime, IJSObjectReference jsReference)
    {
        return Task.FromResult(new Console(jsRuntime, jsReference));
    }

    public static async Task<Console> CreateAsync(IJSRuntime jsRuntime)
    {
        var helper = await jsRuntime.GetHelperAsync();
        var jsInstance = await helper.InvokeAsync<IJSObjectReference>("constructConsole");
        return new Console(jsRuntime, jsInstance);
    }

    /// <summary>
    /// Writes an error message to the console if the assertion is false. If the assertion is true, nothing happens.
    /// </summary>
    /// <param name="condition">Any boolean expression. If the assertion is false, the message is written to the console.</param>
    /// <param name="args"></param>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask Assert(bool? condition, params object[] args) =>
        JSReference.InvokeVoidAsync("assert", condition, args.ToArray());

    /// <summary>
    /// Clears the console if the console allows it.
    /// </summary>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask Clear() => JSReference.InvokeVoidAsync("clear");

    /// <summary>
    /// Logs the number of times that this particular call to count() has been called.
    /// </summary>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask Count(string? label) => JSReference.InvokeVoidAsync("count", label);

    /// <summary>
    /// Resets counter.
    /// </summary>
    /// <param name="label">Resets the count for that label to 0.</param>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask CountReset(string? label) => JSReference.InvokeVoidAsync("countReset", label);

    /// <summary>
    /// Outputs a debug message to the Web console.
    /// </summary>
    /// <param name="message">A JavaScript string containing zero or more substitution strings.</param>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask Debug(string? message) => JSReference.InvokeVoidAsync("debug", message);

    /// <summary>
    /// Outputs a debug message to the Web console.
    /// </summary>
    /// <param name="message">A JavaScript string containing zero or more substitution strings.</param>
    /// <param name="args">JavaScript objects with which to replace substitution strings within msg. This gives you additional control over the format of the output.</param>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask Debug(string? message, params object[] args) => JSReference.InvokeVoidAsync("debug", message, args.ToArray());
    
    /// <summary>
    /// Outputs a debug message to the Web console.
    /// </summary>
    /// <param name="args">A list of JavaScript objects to output. The string representations of each of these objects are appended together in the order listed and output.</param>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask Debug(params object[] args) => JSReference.InvokeVoidAsync("debug", args.ToArray());

    /// <summary>
    /// Displays an interactive list of the properties of the specified JavaScript object. The output is presented as a hierarchical listing with disclosure triangles that let you see the contents of child objects.
    /// </summary>
    /// <param name="item"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask Dir(object? item, object? options) => JSReference.InvokeVoidAsync("dir", item, options);

    /// <summary>
    /// Displays an interactive tree of the descendant elements of the specified XML/HTML element. If it is not possible to display as an element the JavaScript Object view is shown instead. The output is presented as a hierarchical listing of expandable nodes that let you see the contents of child nodes.
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask Dirxml(params object[] args) => JSReference.InvokeVoidAsync("dirxml", args.ToArray());

    /// <summary>
    /// Outputs a error message to the Web console.
    /// </summary>
    /// <param name="message">A JavaScript string containing zero or more substitution strings.</param>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask Error(string? message) => JSReference.InvokeVoidAsync("error", message);

    /// <summary>
    /// Outputs a error message to the Web console.
    /// </summary>
    /// <param name="message">A JavaScript string containing zero or more substitution strings.</param>
    /// <param name="args">JavaScript objects with which to replace substitution strings within msg. This gives you additional control over the format of the output.</param>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask Error(string? message, params object[] args) => JSReference.InvokeVoidAsync("error", message, args.ToArray());
    
    /// <summary>
    /// Outputs a error message to the Web console.
    /// </summary>
    /// <param name="args">A list of JavaScript objects to output. The string representations of each of these objects are appended together in the order listed and output.</param>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask Error(params object[] args) => JSReference.InvokeVoidAsync("error", args.ToArray());

    /// <summary>
    /// Creates a new inline group in the Web console log.
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask Group(params object[] args) => JSReference.InvokeVoidAsync("group", args.ToArray());

    /// <summary>
    /// Creates a new inline group in the Web Console.
    /// <br/><br/>
    /// Call <b>GroupEnd()</b> to back out to the parent group.
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask GroupCollapsed(params object[] args) =>
        JSReference.InvokeVoidAsync("groupCollapsed", args.ToArray());

    /// <summary>
    /// Exits the current inline group in the Web console.
    /// </summary>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask GroupEnd() => JSReference.InvokeVoidAsync("groupEnd");

    /// <summary>
    /// Outputs a info message to the Web console.
    /// </summary>
    /// <param name="message">A JavaScript string containing zero or more substitution strings.</param>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask Info(string? message) => JSReference.InvokeVoidAsync("info", message);

    /// <summary>
    /// Outputs a info message to the Web console.
    /// </summary>
    /// <param name="message">A JavaScript string containing zero or more substitution strings.</param>
    /// <param name="args">JavaScript objects with which to replace substitution strings within msg. This gives you additional control over the format of the output.</param>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask Info(string? message, params object[] args) => JSReference.InvokeVoidAsync("info", message, args.ToArray());
    
    /// <summary>
    /// Outputs a info message to the Web console.
    /// </summary>
    /// <param name="args">A list of JavaScript objects to output. The string representations of each of these objects are appended together in the order listed and output.</param>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask Info(params object[] args) => JSReference.InvokeVoidAsync("info", args.ToArray());

    /// <summary>
    /// Outputs a log message to the Web console.
    /// </summary>
    /// <param name="message">A JavaScript string containing zero or more substitution strings.</param>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask Log(string? message) => JSReference.InvokeVoidAsync("log", message);

    /// <summary>
    /// Outputs a log message to the Web console.
    /// </summary>
    /// <param name="message">A JavaScript string containing zero or more substitution strings.</param>
    /// <param name="args">JavaScript objects with which to replace substitution strings within msg. This gives you additional control over the format of the output.</param>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask Log(string? message, params object[] args) => JSReference.InvokeVoidAsync("log", message, args.ToArray());
    
    /// <summary>
    /// Outputs a log message to the Web console.
    /// </summary>
    /// <param name="args">A list of JavaScript objects to output. The string representations of each of these objects are appended together in the order listed and output.</param>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask Log(params object[] args) => JSReference.InvokeVoidAsync("log", args.ToArray());

    /// <summary>
    /// Displays tabular data as a table.
    ///     /// <br/>
    /// This function takes one mandatory argument data, which must be an array or an object, and one additional optional parameter columns.
    /// </summary>
    /// <param name="data">The data to display. This must be either an array or an object.</param>
    /// <param name="columns">An array containing the names of columns to include in the output.</param>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask Table(object? data, object[]? columns) => JSReference.InvokeVoidAsync("table", data, columns);

    /// <summary>
    /// Displays tabular data as a table.
    /// <br/>
    /// This function takes one mandatory argument data, which must be an array or an object, and one additional optional parameter columns.
    /// </summary>
    /// <param name="data">The data to display. This must be either an array or an object.</param>
    /// <param name="columns">An array containing the names of columns to include in the output.</param>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask Table(object[]? data, object[]? columns) => JSReference.InvokeVoidAsync("table", data, columns);

    /// <summary>
    /// Starts a timer you can use to track how long an operation takes. You give each timer a unique name, and may have up to 10,000 timers running on a given page. When you call <b>TimeEnd()</b> with the same name, the browser will output the time, in milliseconds, that elapsed since the timer was started.
    /// </summary>
    /// <param name="label">A string representing the name to give the new timer. This will identify the timer; use the same name when calling <b>TimeEnd()</b> to stop the timer and get the time output to the console. If omitted, the label "default" is used.</param>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask Time(string? label) => JSReference.InvokeVoidAsync("time", label);

    /// <summary>
    /// Stops a timer that was previously started by calling <b>Time()</b>.
    /// </summary>
    /// <param name="label">A string representing the name of the timer to stop. Once stopped, the elapsed time is automatically displayed in the Web console along with an indicator that the time has ended. If omitted, the label "default" is used.</param>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask TimeEnd(string? label) => JSReference.InvokeVoidAsync("timeEnd", label);

    /// <summary>
    /// Logs the current value of a timer that was previously started by calling <b>Time()</b>.
    /// </summary>
    /// <param name="label">The name of the timer to log to the console. If this is omitted the label "default" is used.</param>
    /// <param name="args">Additional values to be logged to the console after the timer output.</param>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask TimeLog(string? label, params object[] args) =>
        JSReference.InvokeVoidAsync("timeLog", label, args.ToArray());

    /// <summary>
    /// Logs the current value of a timer that was previously started by calling <b>Time()</b>.
    /// </summary>
    /// <param name="label">Additional values to be logged to the console after the timer output.</param>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask TimeStamp(string? label) => JSReference.InvokeVoidAsync("timeStamp", label);
    
    /// <summary>
    /// Outputs a stack trace to the Web console.
    /// </summary>
    /// <param name="args">Zero or more objects to be output to console along with the trace. These are assembled and formatted the same way they would be if passed to the <b>Log()</b> method.</param>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask Trace(params object[] args) => JSReference.InvokeVoidAsync("trace", args.ToArray());

    /// <summary>
    /// Outputs a warning message to the Web console.
    /// </summary>
    /// <param name="message">A JavaScript string containing zero or more substitution strings.</param>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask Warn(string? message) => JSReference.InvokeVoidAsync("warn", message);

    /// <summary>
    /// Outputs a warning message to the Web console.
    /// </summary>
    /// <param name="message">A JavaScript string containing zero or more substitution strings.</param>
    /// <param name="args">JavaScript objects with which to replace substitution strings within msg. This gives you additional control over the format of the output.</param>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask Warn(string? message, params object[] args) => JSReference.InvokeVoidAsync("warn", message, args.ToArray());
    
    /// <summary>
    /// Outputs a warning message to the Web console.
    /// </summary>
    /// <param name="args">A list of JavaScript objects to output. The string representations of each of these objects are appended together in the order listed and output.</param>
    /// <returns></returns>
    [BrowserCompatibilities(Browsers.All)]
    public ValueTask Warn(params object[] args) => JSReference.InvokeVoidAsync("warn", args.ToArray());
}