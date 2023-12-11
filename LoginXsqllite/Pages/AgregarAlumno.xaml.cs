namespace LoginXsqllite.Pages;
using System.Text.RegularExpressions;
using Models;

public partial class AgregarAlumno : ContentPage
{
    public AgregarAlumno()
    {
        InitializeComponent();

    }
    private void OnAgregarAlumnoClicked(object sender, EventArgs e)
    {
        string Name = Nombre.Text;
        string ApPaterno = ApPat.Text;
        string ApMaterno = ApPat.Text;
        var Tipo = picker.SelectedItem?.ToString();
        DateTime selectedDate = datePicker.Date; // Obtiene la fecha seleccionada del DatePicker
        string Fecha = selectedDate.ToString("dd/MM/yyyy");

        if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(ApPaterno) && !string.IsNullOrEmpty(ApMaterno))
        {
            if (Regex.IsMatch(Name, @"^[a-zA-Z·ÈÌÛ˙¡…Õ”⁄Ò—¸‹\s]+$") &&
                Regex.IsMatch(ApPaterno, @"^[a-zA-Z·ÈÌÛ˙¡…Õ”⁄Ò—¸‹\s]+$") &&
                Regex.IsMatch(ApMaterno, @"^[a-zA-Z·ÈÌÛ˙¡…Õ”⁄Ò—¸‹\s]+$"))
            {
                var nuevoAlumno = new Alumno
                {
                    Nombre = Name,
                    ApPaterno = ApPaterno,
                    ApMaterno = ApMaterno,
                    Grupo = Tipo,
                    FechaNac = Fecha
                };

                using (var db = new AppDbContext())
                {
                    db.Alumnos.Add(nuevoAlumno);
                    db.SaveChanges();
                }
                DisplayAlert("Registro exitoso", "Alumno registrado correctamente", "OK");
            }
            else
            {
                DisplayAlert("Error", "Los campos deben contener solo letras y caracteres especiales.", "OK");
            }
        }
        else
        {
            DisplayAlert("Error", "Todos los campos son obligatorios", "OK");
        }

        
    }
    private void VerAlumnosClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new VerAlumno());
    }
}