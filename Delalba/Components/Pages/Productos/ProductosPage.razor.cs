using Delalba.Components.Entities;

namespace Delalba.Components.Pages.Productos
{
    public partial class ProductosPage
    {
        private string MensajeError = "";
        private bool EstamosModificando = false;
        private ProductoEntity? ProductoModificando;

        private int Precio = 0;
        private string Nombre = "";

        private List<ProductoEntity> ProductosList = new();

        private ProductoModal modal = default!;

        private void NuevoProducto()
        {
            modal.Open();
        }

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
        private void Modificar(ProductoEntity productoModificar)
        {
            EstamosModificando = true;
            ProductoModificando = productoModificar;

            Nombre = productoModificar.Nombre;
            Precio = productoModificar.Precio;
        }

        private void GuardarCambios()
        {
            if (Nombre == "" || Precio == 0)
            {
                MensajeError = "Faltaron datos por ingresar!";
            }
            else
            {
                ProductoModificando.Nombre = Nombre;
                ProductoModificando.Precio = Precio;

                Nombre = "";
                Precio = 0;

                EstamosModificando = false;
                ProductoModificando = null;
            }
        }

        private void Eliminar(ProductoEntity productoEliminar)
        {
            ProductosList.Remove(productoEliminar);
        }
    }
}
