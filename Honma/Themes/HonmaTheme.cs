using MudBlazor;

namespace Honma.Themes;

public static class HonmaTheme
{
    public static MudTheme Get => new MudTheme
    {
        Typography = new Typography
        {
            Default = new Default
            {
                FontFamily = [ "JetBrains Mono" ]
            }
        }
    };
}