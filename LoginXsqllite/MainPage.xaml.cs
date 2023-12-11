namespace LoginXsqllite;
using Models;
using Pages;

public partial class MainPage : ContentPage
{


    public MainPage()
    {
        InitializeComponent();
    }

    private void OnLoginButtonClicked(object sender, EventArgs e)
    {
        string inputUsuario = UsernameEntry.Text;
        string inputContraseña = PasswordEntry.Text;
        var Tipo = picker.SelectedItem?.ToString();

        using (var db = new AppDbContext())
        {
            var usuario = db.Usuarios.FirstOrDefault(u => u.NombreUsuario == inputUsuario && u.Contraseña == inputContraseña &&u.Type==Tipo);

            if (usuario != null)
            {
                if (Tipo == "Maestro")
                {
                    DisplayAlert("Exito", "Bienvenido: " + inputUsuario, "OK");
                    Navigation.PushAsync(new AgregarAlumno());

                }
                else if (Tipo == "Alumno")
                {
                    DisplayAlert("Exito", "Bienvenido: " + inputUsuario, "OK");
                    Navigation.PushAsync(new PagePAlumnos());
                }
                
            }
            else
            {
                DisplayAlert("Error", "Credenciales inválidas", "OK");
            }
        }
       

    }

   private void CrearClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Registro());
    }

    private void VerUsuarios_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new VerUsuarios());
    }
}

