using Delalba.Components.Entities;

namespace Delalba.Components.Pages.Productos
{
    public partial class ProductosPage
    {
        private string MensajeError = "";
        private bool EstamosModificando = false;
        private ProductoEntity? PeliculasModificando;

        private int Precio = 0;
        private string Nombre = "";

        private List<ProductoEntity> ProductosList = new();

        //private PeliculaModal modal = default!;

        //private void NuevaPelicula()
        //{
        //    modal.Open();
        //}

        private void Agregar()
        {
            if (Nombre == "" || Precio == 0)
            {
                MensajeError = "Faltaron datos por ingresar!";
            }
            else
            {
                ProductosList.Add(new ProductoEntity(Nombre, Precio));
                Nombre = "";
                Precio = 0;

                MensajeError = "";
            }

        }
    }
}
