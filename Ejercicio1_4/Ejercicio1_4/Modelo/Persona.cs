using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio1_4.Modelo
{
    public class Persona
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public String nombre { get; set; }
        public String descripcion { get; set; }
        public String foto { get; set; }
    }
}
