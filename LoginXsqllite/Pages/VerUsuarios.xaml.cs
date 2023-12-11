namespace LoginXsqllite.Pages;
using Models;

public partial class VerUsuarios : ContentPage
{
	public VerUsuarios()
	{
		InitializeComponent();
        CargarUsuarios();
    }
    private void CargarUsuarios()
    {
        using (var db = new AppDbContext())
        {
            var listaAlumnos = db.Usuarios.ToList();
            alumnosListView.ItemsSource = listaAlumnos;
        }
    }
}