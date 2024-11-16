namespace Delalba.Components.Entities
{
    public class ProductoEntity
    {
        public string Nombre = "";
        public int Precio = 0;

        public ProductoEntity()
        {

        }

        public ProductoEntity (string nombre, int precio)
        {
            Nombre = nombre;
            Precio = precio;
        }
    }
}
