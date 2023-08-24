using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace GenericBrowser
{
    public class Styler
    {
        public static readonly Regex RgbValuesFilter = new(
            @"rgb\s*\((\d{1,3})\s*,\s*(\d{1,3})\s*,\s*(\d{1,3})\)"
            , RegexOptions.IgnoreCase | RegexOptions.Singleline
            , TimeSpan.FromMilliseconds( 100 ) );

        /// Rgb_A modification
        public static readonly Regex RgbaValuesFilter = new(
            @"rgba\s*\((\d{1,3})\s*,\s*(\d{1,3})\s*,\s*(\d{1,3})\s*,\s*(\d{1,3})\)"
            , RegexOptions.IgnoreCase | RegexOptions.Singleline
            , TimeSpan.FromMilliseconds( 100 ) );

        public static string? SharpColorFrom( string cssColor ) 
            => ToSharpColorString( ToRgbBytes( cssColor ) );

        /// <summary>
        /// Convert color byte array to wpf color format like '#rrggbb'
        /// </summary>
        /// <param name="rgbBytes">Color -rgb parts array</param>
        /// <returns>NULL if can not convert</returns>
        public static string? ToSharpColorString( byte[]? rgbBytes )
        {
            if ( rgbBytes == null ) return null;

            var r = rgbBytes.Select( b => $"{b:X2}" );
            return "#" + string.Concat( r );
        }

        /// <summary>
        /// Convert 'rgb(r,g,b)' string to byte[3] array
        /// </summary>
        /// <param name="rgbString">Color value as string in 'rgb(r,g,b)' format</param>
        /// <returns>NULL if it can not parse</returns>
        public static byte[]? ToRgbBytes( string rgbString )
        {

            MatchCollection matches = 
                rgbString.Contains("rgba", StringComparison.InvariantCultureIgnoreCase)
                ? RgbaValuesFilter.Matches( rgbString )
                : RgbValuesFilter.Matches( rgbString );

            bool success =
                matches.Count > 0
                && matches[0].Success
                && (matches[0].Groups.Count == 4
                    || matches[0].Groups.Count == 5 );

            return success
                ? matches[0].Groups.Values
                    .Skip( 1 )
                    .Select( g => byte.Parse( g.Value ) )
                    .ToArray()
                : null;
        }
    }
}
