namespace Blazor.NativeDOM.API;

[Flags]
public enum Browsers : ulong
{
    Chrome = 1 << 0,
    Edge = 1 << 1,
    Firefox = 1 << 2,
    Opera = 1 << 3,
    Safari = 1 << 4,
    ChromeAndroid = 1 << 5,
    FirefoxAndroid = 1 << 6,
    OperaAndroid = 1 << 7,
    SafariIOS = 1 << 8,
    SamsungInternet = 1 << 9,
    WebViewAndroid = 1 << 10,
    Deno = 1 << 11,
    Nodejs = 1 << 12,

    Androids = ChromeAndroid | FirefoxAndroid | OperaAndroid | WebViewAndroid | SamsungInternet,
    Safaris = Safari | SafariIOS,

    All = Chrome | Edge | Firefox | Opera | Safari | ChromeAndroid | FirefoxAndroid | OperaAndroid | SafariIOS |
          SamsungInternet | WebViewAndroid | Deno | Nodejs,
}