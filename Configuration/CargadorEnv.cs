namespace LectorDte.API.Configuration;

public static class CargadorEnv
{
    public static string? Cargar()
    {
        var dir = new DirectoryInfo(AppContext.BaseDirectory);
        for(var i=0; i < 5 && dir is not null; i++)
        {
            var archivo = Path.Combine(dir.FullName, ".env");
            if(File.Exists(archivo))
            {
                DotNetEnv.Env.Load(archivo);
                return archivo;
            }
            dir = dir.Parent;
        }
        return null;
    }

}
