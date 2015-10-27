using System;

namespace EmpleadosConsola
{
    public class EstudiosIncorrectosException:ApplicationException
    {
        public EstudiosIncorrectosException(string msg) : base(msg)
        {
            Console.WriteLine("No cumple con los requisitos: {0} ", msg);
        }
     }
}
