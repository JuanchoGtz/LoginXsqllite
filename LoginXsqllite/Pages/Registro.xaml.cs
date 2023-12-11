namespace LoginXsqllite.Pages;
using Models;
using System.Xml.Linq;

public partial class Registro : ContentPage
{
	public Registro()
	{
		InitializeComponent();

	}

    private void Button_Clicked(object sender, EventArgs e)
    {
        string usuario = NuevoUsuarioEntry.Text;
        string contra = NuevaContraseñaEntry.Text;
        var Tipo = picker.SelectedItem?.ToString();

        if (!string.IsNullOrEmpty(usuario) && !string.IsNullOrEmpty(contra) && !string.IsNullOrEmpty(Tipo))
        {
            using (var db = new AppDbContext())
            {
                db.Database.EnsureCreated();
                var nuevoUsuario = new Usuario { NombreUsuario = usuario, Contraseña = contra, Type = Tipo };
                db.Usuarios.Add(nuevoUsuario);
                db.SaveChanges();
            }

            DisplayAlert("Registro exitoso", "Usuario registrado correctamente", "OK");

        }
        else
        {
            
            DisplayAlert("Error", "Todos los campos son obligatorios", "OK");
        }
       
    }
}