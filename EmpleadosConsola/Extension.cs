using System;

namespace EmpleadosConsola
{
    // la clase debe ser estatica
    public static class Extension
    {
        // que me permita a una cadena sustituir las A mayusculas por A minusculas
        
       // el argumento de entrada es una referencia es decir THIS
       // todos los tipos String podran utilizar este metodo
        public static String Sustituye(this String original,String entrada, String salida)
        {
            var cad = original.Replace(entrada,salida);
            return cad;
        }
    }
}
