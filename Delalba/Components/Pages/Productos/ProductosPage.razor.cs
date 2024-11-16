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
            ProductoModificando = new ProductoEntity();
            modal.Open();
        }

        private void Guardar()
        {
            if (ProductoModificando.Nombre == "" || ProductoModificando.Precio == 0)
            {
                MensajeError = "Faltaron datos por ingresar!";
            }
            else
            {
                if (!EstamosModificando)
                {
                    ProductosList.Add(ProductoModificando);
                }
                else
                {
                    EstamosModificando = false;
                }

                ProductoModificando = null;
                MensajeError = "";
                modal.Close();
            }

        }
        private void Modificar(ProductoEntity productoModificar)
        {
            EstamosModificando = true;
            ProductoModificando = productoModificar;

            modal.Open();
            //Nombre = productoModificar.Nombre;
            //Precio = productoModificar.Precio;
        }

        //private void GuardarCambios()
        //{
        //    if (Nombre == "" || Precio == 0)
        //    {
        //        MensajeError = "Faltaron datos por ingresar!";
        //    }
        //    else
        //    {
        //        ProductoModificando.Nombre = Nombre;
        //        ProductoModificando.Precio = Precio;

        //        Nombre = "";
        //        Precio = 0;

        //        EstamosModificando = false;
        //        ProductoModificando = null;
        //    }
        //}

        private void Eliminar(ProductoEntity productoEliminar)
        {
            ProductosList.Remove(productoEliminar);
        }
    }
}
