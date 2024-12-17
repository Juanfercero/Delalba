//using Delalba.Components.Entities;
using Delalba.Model;
using Microsoft.AspNetCore.Components;
using Delalba.Data;

namespace Delalba.Components.Pages.Productos
{
    public partial class ProductosPage
    {
        [Inject]
        private ApplicationDbContext context {  get; set; }

        private string MensajeError = "";
        private bool EstamosModificando = false;

        private ProductoEntity? ProductoModificando;

        private int Precio = 0;
        private string Nombre = "";

        public List<ProductoEntity> ProductosList;

        private SegundoProductoModal modal = default!;

        public string filtroNombreProducto = "";

        protected override void OnInitialized()
        {
            base.OnInitialized();
            GetData();
        }

        private void GetData()
        {
            ProductosList = context.Productos.ToList();
            ProductosList = ProductosList.OrderBy(p => p.Nombre).ToList();
        }

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
                    context.Productos.Add(ProductoModificando);
                    var actu = context.SaveChanges();

                    GetData();
                }
                else
                {
                    context.Entry(ProductoModificando).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                    GetData();
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
            context.Productos.Remove(productoEliminar);
            context.SaveChanges();
            GetData();
        }

        private void Desactivar(ProductoEntity productoDesactivar)
        {
            ProductoModificando = productoDesactivar;
            ProductoModificando.Activado = false;
            context.Entry(ProductoModificando).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            GetData();
        }

        private void Activar(ProductoEntity productoActivar)
        {
            productoActivar.Activado = true;
            context.SaveChanges();
            GetData();
        }

        private void BuscarProducto()
        {
            GetData();

            ProductosList.Select(c => new ProductoEntity()
            {
                Nombre = c.Nombre,
                Precio = c.Precio,
            }).ToList();

            if (filtroNombreProducto != "")
            {
                filtroNombreProducto = filtroNombreProducto.Substring(0, 1).ToUpper() + filtroNombreProducto.Substring(1).ToLower();
                ProductosList = ProductosList.Where(c => c.Nombre.Contains(filtroNombreProducto)).ToList();
            }

            //if (filtroNombreProducto != "")
            //{
            //    ProductosList = ProductosList.Where(c => c.Nombre == filtroNombreProducto).ToList();
            //}

            context.SaveChanges();
        }
    }
}
