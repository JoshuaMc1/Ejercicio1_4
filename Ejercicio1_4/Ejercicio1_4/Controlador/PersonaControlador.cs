using Ejercicio1_4.Modelo;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_4.Controlador
{
    public class PersonaControlador
    {
        readonly SQLiteAsyncConnection _conexion;

        public PersonaControlador(String dbPath)
        {
            _conexion = new SQLiteAsyncConnection(dbPath);
            _conexion.CreateTableAsync<Persona>().Wait();
        }

        public Task<List<Persona>> getPersonas()
        {
            return _conexion.Table<Persona>().ToListAsync();
        }

        public Task<int> guardarPersona(Persona persona)
        {
            if (persona.Id != 0)
            {
                return _conexion.UpdateAsync(persona);
            }
            else
            {
                return _conexion.InsertAsync(persona);
            }
        }

        public Task<Persona> obtenerPersona(int id)
        {
            return _conexion.Table<Persona>()
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
        }

        public Task<int> borrarPersona(Persona persona)
        {
            return _conexion.DeleteAsync(persona);
        }
    }
}
