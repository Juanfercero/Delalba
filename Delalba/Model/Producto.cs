namespace Delalba.Model
{
    public class ProductoEntity
    {
        public Guid ID { get; set; } = Guid.NewGuid();

        public string Nombre { get; set; } = string.Empty;

        public int Precio { get; set; } = 0;

        public byte[]? Foto { get; set; }

        public bool Activado { get; set; } = true;
    }
}
