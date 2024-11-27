class InvokerEvento
{
    private IEventoCommand comando;

    public InvokerEvento(){
        Console.WriteLine("\n¿Qué tipo de evento desea crear?");
                    Console.WriteLine("1. Concierto");
                    Console.WriteLine("2. Feria");
                    Console.WriteLine("3. Muestra cultural");
                    Console.WriteLine("4. Fiesta de pueblo");
                    Console.WriteLine("5. Congreso");
                    Console.WriteLine("6. Palenque");
                    Console.Write("Seleccione una opción: ");

                    string tipoEvento = Console.ReadLine();

                    switch (tipoEvento)
                    {
                        case "1":
                            comando = new ConciertoCommand();
                            break;
                        case "2":
                            comando = new FeriaCommand();
                            break;
                        case "3":
                            comando = new MuestraCulturalCommand();
                            break;
                        case "4":
                            comando = new FiestaDePuebloCommand();
                            break;
                        case "5":
                            comando = new CongresoCommand();
                            break;
                        case "6":
                            comando = new PalenqueCommand();
                            break;
                        default:
                            Console.WriteLine("Tipo de evento inválido. Intente nuevamente.");
                            break;
                    }

                    setCommand(comando);
                    executeCommand();
    }
    public void setCommand(IEventoCommand command){
        comando = command;
    }

    public void executeCommand()
    {
        comando.execute();
    }
}

public interface IEventoCommand
{
    void execute();
}

public partial class Evento
{
    public Detalles detalles;

    public Evento(Detalles detalles)
    {
        this.detalles = detalles;
    }

    public int getCupo()
    {
        return detalles.Cupo;
    }

    public bool isVIP()
    {
        if (detalles.VIP == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void MostrarEvento()
    {
        Console.WriteLine("Evento: " + detalles.Nombre + " Tipo: " + detalles.Tipo + " Cupo: " + detalles.Cupo + " VIP: " + detalles.VIP);
    }
}
//Logica de la creacion de eventos en el receiver
class EventoReceiver
{
    public Detalles detalles;

    public EventoReceiver(Detalles detalles)
    {
        this.detalles = detalles;
        Evento evento = new Evento(detalles);
        EventoManager.AgregarEvento(evento);
    }

    public void crearConcierto()
    {
        detalles.Tipo = "Concierto";
        Console.WriteLine("Concierto creado: " + detalles.Nombre + " con un cupo de " + detalles.Cupo + " personas");
    }

    public void crearFeria()
    {
        detalles.Tipo = "Feria";
        Console.WriteLine("Feria creado: " + detalles.Nombre + " con un cupo de " + detalles.Cupo + " personas");
    }

    public void crearMuestraCultural()
    {
        detalles.Tipo = "Muestra Cultural";
        Console.WriteLine("Muestra Cultural creado: " + detalles.Nombre + " con un cupo de " + detalles.Cupo + " personas");
    }

    public void crearFiestaDePueblo()
    {
        detalles.Tipo = "Fiesta de Pueblo";
        Console.WriteLine("Fiesta de Pueblo creado: " + detalles.Nombre + " con un cupo de " + detalles.Cupo + " personas");
    }

    public void crearCongreso()
    {
        detalles.Tipo = "Congreso";
        Console.WriteLine("Congreso creado: " + detalles.Nombre + " con un cupo de " + detalles.Cupo + " personas");
    }

    public void crearPalenque()
    {
        detalles.Tipo = "Palenque";
        Console.WriteLine("Palenque creado: " + detalles.Nombre + " con un cupo de " + detalles.Cupo + " personas");
    }
}
//Creamos una clase Detalles para acceder mas facilmente a los detales de cada evento
public class Detalles
{
    public string Nombre { get; set; }
    public int Cupo { get; set; }
    public int VIP { get; set; }
    public string Tipo { get; set; }

    public Detalles()
    {
        while (string.IsNullOrEmpty(Nombre))
        {
            Console.WriteLine("Nombre del evento:");
            Nombre = Console.ReadLine();
        }
        while (Cupo <= 0)
        {
            Console.WriteLine("Cupo del evento:");
            if (int.TryParse(Console.ReadLine(), out int parsedCupo) && parsedCupo > 0)
            {
                Cupo = parsedCupo;
            }
            else
            {
                Console.WriteLine("Por favor, ingrese un número valido");
            }
        }
        while(true)
        {
            Console.WriteLine("¿El evento es VIP? (1 = Sí, 0 = No)");
            if (int.TryParse(Console.ReadLine(), out int parsedVIP) && (parsedVIP == 0 || parsedVIP == 1))
            {
                VIP = parsedVIP;
                break;
            }   
            else
            {
                Console.WriteLine("Por favor, ingrese un número valido");
            }
        }
    }
}
//Commands para los distintos eventos
public class ConciertoCommand : IEventoCommand
{
    private EventoReceiver _receiver;

    // Constructor para inicializar los detalles y el receiver
    public ConciertoCommand()
    {
        _receiver = new EventoReceiver(new Detalles());
    }
    public void execute()
    {
        _receiver.crearConcierto();
    }
}

public class FeriaCommand : IEventoCommand
{
    private EventoReceiver _receiver;
    
    //Constructor para inicializar los detalles y el receiver
    public FeriaCommand()
    {
        _receiver = new EventoReceiver(new Detalles());
    }

    public void execute()
    {
        _receiver.crearFeria();
    }
}

public class MuestraCulturalCommand : IEventoCommand
{
    private EventoReceiver _receiver;

    public MuestraCulturalCommand()
    {
        _receiver = new EventoReceiver(new Detalles());
    }

    public void execute()
    {
        _receiver.crearMuestraCultural();
    }
}

public class FiestaDePuebloCommand : IEventoCommand
{
    private EventoReceiver _receiver;

    public FiestaDePuebloCommand()
    {
        _receiver = new EventoReceiver(new Detalles());
    }

    public void execute()
    {
        _receiver.crearFiestaDePueblo();
    }
}

public class CongresoCommand : IEventoCommand
{
    private EventoReceiver _receiver;

    public CongresoCommand()
    {
        _receiver = new EventoReceiver(new Detalles());
    }

    public void execute()
    {
        _receiver.crearCongreso();
    }
}

public class PalenqueCommand : IEventoCommand
{
    private EventoReceiver _receiver;

    public PalenqueCommand()
    {
        _receiver = new EventoReceiver(new Detalles());
    }

    public void execute()
    {
        _receiver.crearPalenque();
    }
}

//Se agregó una clase para manejar los eventos creados
class EventoManager
{
    public static List<Evento> Eventos = new List<Evento>();

    public static void AgregarEvento(Evento evento)
    {
        Eventos.Add(evento);
    }

    public static void ImprimirEventos()
    {
        Console.WriteLine("\nLista de eventos creados:");
        if (Eventos.Count == 0)
        {
            Console.WriteLine("No se han creado eventos.");
        }
        else
        {
            foreach (var evento in Eventos)
            {
                evento.MostrarEvento();
            }
        }
    }
}
