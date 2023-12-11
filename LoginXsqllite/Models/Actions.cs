using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginXsqllite.Models
{
    internal class Actions
    {
        public void ModificarGrupo(int AlumnoId, string nuevoGrupo)
        {
            using (var db = new AppDbContext())
            {
                // Buscar el usuario por Id
                var usuarioAModificar = db.Alumnos.FirstOrDefault(a => a.Id == AlumnoId);

                if (usuarioAModificar != null)
                {
                    usuarioAModificar.Grupo = nuevoGrupo;
                    db.SaveChanges();
                }
            }
        }
        public void EliminarUsuarioPorId(int alumnoId)
        {
            using (var db = new AppDbContext())
            {
                // Buscar el usuario por Id
                var usuarioAEliminar = db.Alumnos.FirstOrDefault(u => u.Id == alumnoId);

                if (usuarioAEliminar != null)
                {
                    db.Alumnos.Remove(usuarioAEliminar);
                    db.SaveChanges();
                }
            }
        }

    }
}
