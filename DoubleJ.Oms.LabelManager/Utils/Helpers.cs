using NLog;
using NLog.Config;
using NLog.Targets;
using NLog.Targets.Wrappers;

namespace DoubleJ.Oms.LabelManager.Utils
{
    public static class Helpers
    {
        public static string NullableToString<T>(this T? source) where T : struct
        {
            return source.HasValue ? source.ToString() : string.Empty;
        }

        public static void InstantiateRLogger()
        {
            var target = new RichTextBoxTarget
            {
                Name = "RichTextBox",
                Layout = "${longdate:useUTC=true} | ${level:uppercase=true} | ${logger} :: ${message}",
                ControlName = "textbox1",
                FormName = "Form1",
                AutoScroll = true,
                Height = 480,
                Width = 640,
                MaxLines = 10000,
                UseDefaultRowColoringRules = false
            };

            target.RowColoringRules.Add(new RichTextBoxRowColoringRule("level == LogLevel.Trace", "DarkGray", "Control"));
            target.RowColoringRules.Add(new RichTextBoxRowColoringRule("level == LogLevel.Debug", "Gray", "Control"));
            target.RowColoringRules.Add(new RichTextBoxRowColoringRule("level == LogLevel.Info", "ControlText", "Control"));
            target.RowColoringRules.Add(new RichTextBoxRowColoringRule("level == LogLevel.Warn", "DarkRed", "Control"));
            target.RowColoringRules.Add(new RichTextBoxRowColoringRule("level == LogLevel.Error", "White", "DarkRed"));
            target.RowColoringRules.Add(new RichTextBoxRowColoringRule("level == LogLevel.Fatal", "Yellow", "DarkRed"));

            var asyncWrapper = new AsyncTargetWrapper { Name = "AsyncRichTextBox", WrappedTarget = target };

            SimpleConfigurator.ConfigureForTargetLogging(asyncWrapper, LogLevel.Trace);
        }
    }
}
