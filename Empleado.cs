namespace RegistroEmpleados
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public decimal SalarioBase { get; set; }
        public int HorasExtra { get; set; }

        public decimal PagoTotal()
        {
            return SalarioBase + (HorasExtra * 50);
        }

        public override string ToString()
        {
            return $"{Id,-3} {Nombre,-20} Q {SalarioBase,10:N2} {HorasExtra,-6} Q {PagoTotal(),12:N2}";
        }
    }
}