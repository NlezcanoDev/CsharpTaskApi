namespace TasksProject
{
    public static class AppSettings
    {
        public static Settings Settings { get; set; }

        public static void BindSettings(IConfiguration configuration)
        {
            Settings = new Settings();
            configuration.Bind("AppSettings", Settings);
            configuration.Bind("App", Settings);
        }
    }

    public class Settings
    {
        public string Env { get; set; }
        public string ConnectionString { get; set; }
        public string Version { get; set; }
        public string[] Cors { get; set; }
        public string IronOrcKey { get; set; }
        public Dictionary<string, string> Credenciales { get; set; }
        public Dictionary<string, string> Urls { get; set; }
    }
}
