using System; 
using System.Collections.Generic; 

class Program
{
    static void Main()
    {
        Console.Write("Ingrese la cantidad de proveedores: "); // Pide al usuario la cantidad de proveedores
        int cantidadProveedores = Convert.ToInt32(Console.ReadLine()); // Lee la cantidad de proveedores

        List<string> proveedores = new List<string>(); // Crea una lista para almacenar nombres de proveedores
        for (int i = 0; i < cantidadProveedores; i++) // Ciclo para ingresar nombres de proveedores
        {
            Console.Write($"Ingrese el nombre del proveedor {i + 1}: "); // Pide al usuario el nombre del proveedor
            string nombreProveedor = Console.ReadLine(); // Lee el nombre del proveedor
            proveedores.Add(nombreProveedor); // Agrega el nombre del proveedor a la lista
        }

        Dictionary<string, List<decimal>> facturasPorProveedor = new Dictionary<string, List<decimal>>(); // Crea un diccionario para almacenar facturas por proveedor
        foreach (var proveedor in proveedores) // Ciclo para ingresar las facturas de cada proveedor
        {
            Console.Write($"Ingrese la cantidad de facturas para {proveedor}: "); // Pide al usuario la cantidad de facturas
            int cantidadFacturas = Convert.ToInt32(Console.ReadLine()); // Lee la cantidad de facturas

            List<decimal> facturas = new List<decimal>(); // Crea una lista para almacenar montos de facturas
            for (int i = 0; i < cantidadFacturas; i++) // Ciclo para ingresar montos de facturas
            {
                Console.Write($"Ingrese el monto de la factura {i + 1} para {proveedor}: "); // Pide al usuario el monto de la factura
                decimal montoFactura = Convert.ToDecimal(Console.ReadLine()); // Lee el monto de la factura
                facturas.Add(montoFactura); // Agrega el monto de la factura a la lista
            }
            facturasPorProveedor.Add(proveedor, facturas); // Agrega las facturas del proveedor al diccionario
        }

        // Proceso de verificación y actualización de montos pendientes
        foreach (var proveedor in facturasPorProveedor) // Recorre el diccionario de facturas por proveedor
        {
            Console.WriteLine($"Facturas pendientes para {proveedor.Key}:"); // Muestra el nombre del proveedor
            int contador = 1;
            foreach (var monto in proveedor.Value) // Recorre las facturas del proveedor
            {
                Console.WriteLine($"Factura {contador}: Monto {monto}"); // Muestra cada factura y su monto
                contador++;
            }

            Console.Write($"¿Desea actualizar algún monto para {proveedor.Key}? (Sí/No): "); // Pregunta si se desea actualizar un monto
            string respuesta = Console.ReadLine(); // Lee la respuesta del usuario

            if (respuesta.ToLower() == "si" || respuesta.ToLower() == "sí") // Verifica si la respuesta es "si"
            {
                Console.Write("Ingrese el número de la factura que desea actualizar: "); // Pide el número de la factura a actualizar
                int numeroFactura = Convert.ToInt32(Console.ReadLine()) - 1; // Lee el número de la factura

                if (numeroFactura >= 0 && numeroFactura < proveedor.Value.Count) // Verifica si el número de factura es válido
                {
                    Console.Write("Ingrese el nuevo monto: "); // Pide el nuevo monto
                    decimal nuevoMonto = Convert.ToDecimal(Console.ReadLine()); // Lee el nuevo monto
                    proveedor.Value[numeroFactura] = nuevoMonto; // Actualiza el monto de la factura
                }
                else
                {
                    Console.WriteLine("Número de factura inválido."); // Muestra un mensaje si el número de factura es inválido
                }
            }
            Console.WriteLine($"Facturas pendientes para {proveedor.Key}:"); // Muestra el nombre del proveedor
            contador = 1; // Reinicializa el índice para las listas de proveedores.
            foreach (var monto in proveedor.Value) // Recorre las facturas del proveedor
            {
                Console.WriteLine($"Factura {contador}: Monto {monto}"); // Muestra cada factura y su monto
                contador++;
            }
        }



        Console.WriteLine("Proceso de cuentas por pagar finalizado."); 
    }
}
