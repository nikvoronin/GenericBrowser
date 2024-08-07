using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace GenericBrowser;

public static class Styler
{
    public static string? SharpColorFrom( string cssColor ) =>
        ToSharpColorString( ToRgbBytes( cssColor ) );

    /// <summary>
    /// Convert color byte array to wpf color format like '#rrggbb'
    /// </summary>
    /// <param name="rgbBytes">Color -rgb parts array</param>
    /// <returns><see langword="null"/> if can not convert</returns>
    public static string? ToSharpColorString( byte[]? rgbBytes )
    {
        if (rgbBytes == null) return null;

        var r = rgbBytes.Select( b => $"{b:X2}" );
        return "#" + string.Concat( r );
    }

    /// <summary>
    /// Convert 'rgb(r,g,b)' string to byte[3] array
    /// </summary>
    /// <param name="rgbString">Color value as string in 'rgb(r,g,b)' format</param>
    /// <returns><see langword="null"/> if it can not parse</returns>
    public static byte[]? ToRgbBytes( string rgbString )
    {

        MatchCollection matches =
            rgbString.Contains( "rgba", StringComparison.InvariantCultureIgnoreCase )
            ? _rgbaValuesFilter.Matches( rgbString )
            : _rgbValuesFilter.Matches( rgbString );

        bool success =
            matches.Count > 0
            && matches[0].Success
            && (matches[0].Groups.Count == 4
                || matches[0].Groups.Count == 5);

        return
            success
            ? matches[0].Groups.Values
                .Skip( 1 )
                .Select( g => byte.Parse( g.Value ) )
                .ToArray()
            : null;
    }

    private static readonly Regex _rgbValuesFilter = new(
        @"rgb\s*\((\d{1,3})\s*,\s*(\d{1,3})\s*,\s*(\d{1,3})\)",
        RegexOptions.IgnoreCase | RegexOptions.Singleline,
        TimeSpan.FromMilliseconds( 100 ) );

    /// <summary>
    /// Rgb_A modification
    /// </summary>
    private static readonly Regex _rgbaValuesFilter = new(
        @"rgba\s*\((\d{1,3})\s*,\s*(\d{1,3})\s*,\s*(\d{1,3})\s*,\s*(\d{1,3})\)",
        RegexOptions.IgnoreCase | RegexOptions.Singleline,
        TimeSpan.FromMilliseconds( 100 ) );
}
