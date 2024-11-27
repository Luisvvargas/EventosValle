using static Solicitud;

class Program
{
    public static void AplicarVisitor(EventoVisitor visitor)
    {
        if (EventoManager.Eventos.Count == 0)
        {
            Console.WriteLine("No hay eventos creados para aplicar el Visitor.");
            return;
        }

        Console.WriteLine($"\nAplicando...");
        foreach (var evento in EventoManager.Eventos)
        {
            evento.Accept(visitor); //aplicar visitor en cada evento
        }
    }

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n¿Qué quiere hacer?");
            Console.WriteLine("1. Crear un evento");
            Console.WriteLine("2. Agregar asistente");
            Console.WriteLine("3. Ver lista de eventos");
            Console.WriteLine("4. Notificaciones");
            Console.WriteLine("5. Reportes");
            Console.WriteLine("6. Actualizar cupo");
            Console.WriteLine("7. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    InvokerEvento invoker = new InvokerEvento();
                    break;
                case "2":
                    Console.WriteLine("Crear un asistente y validar solicitud.");
                    Solicitud solicitud = new Solicitud
                    {
                        CupoDisponible = EventoManager.Eventos.Count > 0 ? EventoManager.Eventos[0].getCupo() - EventoManager.Eventos[0].detalles.Cupo : 0
                    };

                    //chain of responsability
                    var edadHandler = new EdadHandler();
                    var vipHandler = new VIPHandler();
                    var cupoHandler = new CupoHandler();

                    edadHandler.SetNextHandler(vipHandler);
                    vipHandler.SetNextHandler(cupoHandler);

                    edadHandler.Handle(solicitud);
                    break;
                case "3":
                    EventoManager.ImprimirEventos();
                    break;
                case "4":
                    AplicarVisitor(new NotificacionVisitor());
                    break;
                case "5":
                    AplicarVisitor(new ReporteVisitor());
                    break;
                case "6":
                    Console.WriteLine("\nSeleccione el evento al que desea agregar asistentes:");
                    for (int i = 0; i < EventoManager.Eventos.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {EventoManager.Eventos[i].detalles.Nombre} ({EventoManager.Eventos[i].detalles.Tipo})");
                    }
                    int eventoSeleccionado;
                    while (true)
                    {
                        Console.Write("Ingrese el número del evento: ");
                        if (int.TryParse(Console.ReadLine(), out eventoSeleccionado) &&
                            eventoSeleccionado > 0 &&
                            eventoSeleccionado <= EventoManager.Eventos.Count)
                        {
                            break;
                        }
                        Console.WriteLine("Selección inválida. Intente nuevamente.");
                    }
                    Console.Write("Asistentes adicionales: ");
                    int asistentesAdicionales;
                    while (!int.TryParse(Console.ReadLine(), out asistentesAdicionales) || asistentesAdicionales <= 0)
                    {
                        Console.WriteLine("Cantidad inválida. Intente nuevamente.");
                    }
                    // Aplicar el RegistroVisitor con la cantidad de asistentes adicionales
                    var registroVisitor = new RegistroVisitor(asistentesAdicionales);
                    EventoManager.Eventos[eventoSeleccionado - 1].Accept(registroVisitor);
                    break;
                case "7":
                    Console.WriteLine("Saliendo del programa...");
                    return;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
    }
}