// Clase para representar la solicitud
public class Solicitud
{
    public int Edad { get; set; }
    public bool EsVIP { get; set; }
    public int CupoDisponible { get; set; }

    public Solicitud()
    {
        while (true)
        {
            Console.WriteLine("Ingrese la edad del asistente: ");
            if (int.TryParse(Console.ReadLine(), out int edad))
            {
                Edad = edad;
                break;
            }
            else
            {
                Console.WriteLine("Edad inválida. Intente de nuevo.");
            }
        }
        while (true)
        {
            Console.WriteLine("El asistente es VIP? (s/n): ");
            string esVIP = Console.ReadLine();
            if (esVIP == "s")
            {
                EsVIP = true;
                break;
            }
            else if (esVIP == "n")
            {
                EsVIP = false;
                break;
            }
            else
            {
                Console.WriteLine("Respuesta inválida.");
            }

    }
}
public abstract class SolicitudHandler
{
    protected SolicitudHandler NextHandler;

    public void SetNextHandler(SolicitudHandler handler)
    {
        NextHandler = handler;
    }

    public abstract void Handle(Solicitud solicitud);
}

public class EdadHandler : SolicitudHandler
{
    public override void Handle(Solicitud solicitud)
    {
        if (solicitud.Edad < 18)
        {
            Console.WriteLine("Solicitud rechazada: el asistente es menor de edad.");
            return;
        }

        NextHandler?.Handle(solicitud);
    }
}

public class VIPHandler : SolicitudHandler
{
    public override void Handle(Solicitud solicitud)
    {
        if (!solicitud.EsVIP)
        {
            Console.WriteLine("Solicitud rechazada: el asistente no tiene membresía VIP.");
            return;
        }

        NextHandler?.Handle(solicitud);
    }
}

public class CupoHandler : SolicitudHandler
{
    public override void Handle(Solicitud solicitud)
    {
        if (solicitud.CupoDisponible <= 0)
        {
            Console.WriteLine("Solicitud rechazada: no hay cupo disponible.");
            return;
        }

        NextHandler?.Handle(solicitud);
    }
}
}

