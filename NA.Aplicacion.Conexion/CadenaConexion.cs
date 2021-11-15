namespace NA.Aplicacion.Conexion
{
    public class CadenaConexion
    {
        public static string Servidor = @"DESKTOP-ALCQ1RH";

        public static string BaseDatos = "Nutri";

        public static string Usuario = "";

        public static string Password = "";

        public static string ObtenerConexionWin => $"Data Source={Servidor};" +
                                            $"Initial Catalog={BaseDatos}; " +
                                            $"Integrated Security=True";
    }
}
