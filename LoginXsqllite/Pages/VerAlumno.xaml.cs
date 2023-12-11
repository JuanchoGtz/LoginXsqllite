namespace LoginXsqllite.Pages;
using System.Text.RegularExpressions;
using Models;

public partial class VerAlumno : ContentPage
{
    public VerAlumno()
    {
        InitializeComponent();
        CargarAlumnos();

    }
  
    private void CargarAlumnos()
    {
        using (var db = new AppDbContext())
        {
            var listaAlumnos = db.Alumnos.ToList();
            alumnosCollectionView.ItemsSource = listaAlumnos;
        }
    }

    private void Modificar_Clicked(object sender, EventArgs e)
    {
        if (int.TryParse(Id.Text, out int idUsuarioModificar))
        {
            if (idUsuarioModificar >= 0)
            {
                var Grupo = picker.SelectedItem?.ToString();

                if (!string.IsNullOrEmpty(Grupo) )
                {
                    Actions actions = new Actions();
                    actions.ModificarGrupo(idUsuarioModificar, Grupo);
                    DisplayAlert("Actualizacion exitosa", "Alumno: " + Id.Text + "Cambiado a: " + Grupo, "OK");
                }
                else
                {
                    DisplayAlert("Error", "El campo Grupo debe contener solo letras y caracteres especiales.", "OK");
                }
            }
            else
            {
                DisplayAlert("Error", "El Id debe ser un número positivo.", "OK");
            }
        }
        else
        {
            DisplayAlert("Error", "El Id debe ser un número válido.", "OK");
        }
        

    }

    private void Eliminar_Clicked(object sender, EventArgs e)
    {
        if (int.TryParse(Id.Text, out int idUsuarioModificar))
        {
            if (idUsuarioModificar >= 0)
            {
                int idEliminar = Convert.ToInt32(Id.Text);
                Actions actions = new Actions();
                actions.EliminarUsuarioPorId(idEliminar);
                DisplayAlert("Eliminacion exitosa", "Alumno eliminado correctamente", "OK");
            }else{DisplayAlert("Error", "El Id debe ser un número positivo.", "OK");}
        } else{DisplayAlert("Error", "El Id debe ser un número válido.", "OK");}
        }
}
