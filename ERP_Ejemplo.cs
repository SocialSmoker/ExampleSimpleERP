using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Write("Ingrese la cantidad de proveedores: ");
        int cantidadProveedores = Convert.ToInt32(Console.ReadLine());

        List<string> proveedores = new List<string>();
        for (int i = 0; i < cantidadProveedores; i++)
        {
            Console.Write($"Ingrese el nombre del proveedor {i + 1}: ");
            string nombreProveedor = Console.ReadLine();
            proveedores.Add(nombreProveedor);
        }

        Dictionary<string, List<decimal>> facturasPorProveedor = new Dictionary<string, List<decimal>>();
        foreach (var proveedor in proveedores)
        {
            Console.Write($"Ingrese la cantidad de facturas para {proveedor}: ");
            int cantidadFacturas = Convert.ToInt32(Console.ReadLine());

            List<decimal> facturas = new List<decimal>();
            for (int i = 0; i < cantidadFacturas; i++)
            {
                Console.Write($"Ingrese el monto de la factura {i + 1} para {proveedor}: ");
                decimal montoFactura = Convert.ToDecimal(Console.ReadLine());
                facturas.Add(montoFactura);
            }
            facturasPorProveedor.Add(proveedor, facturas);
        }

        // Proceso de verificación y actualización de montos pendientes
        foreach (var proveedor in facturasPorProveedor)
        {
            Console.WriteLine($"Facturas pendientes para {proveedor.Key}:");
            int contador = 1;
            foreach (var monto in proveedor.Value)
            {
                Console.WriteLine($"Factura {contador}: Monto {monto}");
                contador++;
            }

            Console.Write($"¿Desea actualizar algún monto para {proveedor.Key}? (Sí/No): ");
            string respuesta = Console.ReadLine();

            if (respuesta.ToLower() == "si" || respuesta.ToLower() == "sí")
            {
                Console.Write("Ingrese el número de la factura que desea actualizar: ");
                int numeroFactura = Convert.ToInt32(Console.ReadLine()) - 1;

                if (numeroFactura >= 0 && numeroFactura < proveedor.Value.Count)
                {
                    Console.Write("Ingrese el nuevo monto: ");
                    decimal nuevoMonto = Convert.ToDecimal(Console.ReadLine());
                    proveedor.Value[numeroFactura] = nuevoMonto;
                }
                else
                {
                    Console.WriteLine("Número de factura inválido.");
                }
            }
        }

        Console.WriteLine("Proceso de cuentas por pagar finalizado.");
    }
}
