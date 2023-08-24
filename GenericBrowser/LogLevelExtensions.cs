namespace GenericBrowser
{
    /* NLog related
    public static class NLogLevelExtensions
    {
        public static readonly IReadOnlyDictionary<LogLevel, LogSeverity> NLogToLogSeverity =
            new Dictionary<LogLevel, LogSeverity>() {
            { LogLevel.Off, LogSeverity.Disable },
            { LogLevel.Fatal, LogSeverity.Fatal },
            { LogLevel.Error, LogSeverity.Error },
            { LogLevel.Warn,  LogSeverity.Warning },
            { LogLevel.Info,  LogSeverity.Info },
            { LogLevel.Debug, LogSeverity.Verbose },
            { LogLevel.Trace, LogSeverity.Verbose }
        };

        public static LogSeverity ToLogSeverity( this LogLevel level )
            => NLogToLogSeverity.TryGetValue( level, out LogSeverity severity )
            ? severity
            : LogSeverity.Default;
    }
     */

    /* Serilog related
    public static class SerilogLevelExtensions
    {
        public static readonly IReadOnlyDictionary<LogEventLevel, LogSeverity> SerilogToLogSeverity =
            new Dictionary<LogEventLevel, LogSeverity>() {
            { LogEventLevel.Fatal,       LogSeverity.Fatal },
            { LogEventLevel.Error,       LogSeverity.Error },
            { LogEventLevel.Warning,     LogSeverity.Warning },
            { LogEventLevel.Information, LogSeverity.Info },
            { LogEventLevel.Debug,       LogSeverity.Verbose },
            { LogEventLevel.Verbose,     LogSeverity.Verbose }
        };

        public static LogSeverity ToLogSeverity( this LogEventLevel level )
            => SerilogToLogSeverity.TryGetValue( level, out LogSeverity severity )
            ? severity
            : LogSeverity.Default;
    }
     */
}
