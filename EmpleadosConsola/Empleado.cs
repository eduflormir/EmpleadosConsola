using System;

namespace EmpleadosConsola
{
    public class Empleado

    {
        private String _nombre;

        public string Nombre
        {
            get { return _nombre; }
            set
            {
                _nombre = value.Sustituye("a","A"); 
                
            }
        }
        public int Edad { get; set; }

        public Enumerados.Estudios Estudios { get; set; }

        private Enumerados.Puestos _puesto;

        public override string ToString()
        {
            return String.Format("Nombre: {0} Edad: {1} Puesto: {2} Estudios :{3} \n", Nombre,Edad, Puesto,Estudios);
        }

        public Enumerados.Puestos Puesto
        {
            get { return _puesto; }
            // si soy programador y quiero director
            set
            {
                
                if ((int)value > (int)Estudios && Estudios!=Enumerados.Estudios.Doctor)
                {
                    var msg = $"Debido a tu nivel de estudios {Estudios} no "
                              + $"permite optar al puesto de {value}";
                    throw new EstudiosIncorrectosException(msg);
                }

                _puesto = value;
            }

        }
        
    }
}

