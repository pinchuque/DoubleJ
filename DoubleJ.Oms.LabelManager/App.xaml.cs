using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows;

using DoubleJ.Oms.Service.Services;

using NLog;


namespace DoubleJ.Oms.LabelManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private const int MaxLength = 4000;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private static bool _firstUnhandledException = true;

        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                var currentDomain = AppDomain.CurrentDomain;
                currentDomain.UnhandledException += OnUnhandledException;
                DIService.Wire(new ApplicationModule());
                base.OnStartup(e);
                var wnd = DIService.Resolve<LabelManagerWindow>();
                wnd.Show();
            }
            catch (Exception exc)
            {
                Logger.Error("Global catch; ", exc);
            }
        }

        private void OnUnhandledException(object sender, UnhandledExceptionEventArgs args)
        {
            if (!_firstUnhandledException)
            {
                Shutdown();
                return;
            }

            var dataBaseValidationException = args.ExceptionObject as DbEntityValidationException;
            if (dataBaseValidationException != null)
            {
                Logger.Error(string.Format("Unhandled Exception; \n {0} \n", dataBaseValidationException), dataBaseValidationException);

                var errors = string.Join(",", dataBaseValidationException.EntityValidationErrors.SelectMany(x => x.ValidationErrors).Select(x => x.PropertyName).ToArray());
                var message = string.Format("Fields: {0} \nStackTrace: {1}", errors, SafeRemove(dataBaseValidationException.StackTrace, MaxLength));
                var title = string.Format("{0}; Message: {1}", dataBaseValidationException.GetType(), dataBaseValidationException.Message);

                MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var exception = args.ExceptionObject as Exception;
                if (exception != null)
                {
                    Logger.Error(string.Format("Unhandled Exception; \n {0} \n", exception), exception);

                    var message = SafeRemove(exception.StackTrace, MaxLength);
                    var title = string.Format("{0}; Message: {1}", exception.GetType(), exception.Message);

                    MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            _firstUnhandledException = false;
        }

        private static string SafeRemove(string text, int startIndex)
        {
            return text.Length <= startIndex ? text : text.Remove(startIndex);
        }
    }
}