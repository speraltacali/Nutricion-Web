namespace NA.Aplicacion.Conexion
{
    public class CadenaConexion
    {
        public static string Servidor = @"DESKTOP-NK0OJF1";

        public static string BaseDatos = "NutriApps";

        public static string Usuario = "";

        public static string Password = "";

        public static string ObtenerConexionWin => $"Data Source={Servidor};" +
                                            $"Initial Catalog={BaseDatos}; " +
                                            $"Integrated Security=True";
    }
}
