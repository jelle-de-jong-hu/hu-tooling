namespace WinFormsApp1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // https://stackoverflow.com/questions/995195/how-can-i-make-a-net-windows-forms-application-that-only-runs-in-the-system-tra
            // see https://aka.ms/applicationconfiguration.Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new SendKeysContext());
        }
    }
}