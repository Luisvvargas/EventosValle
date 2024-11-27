//interface visitor
public interface EventoVisitor
{
    void VisitConcierto(Evento evento);
    void VisitFeria(Evento evento);
    void VisitMuestraCultural(Evento evento);
    void VisitFiestaDePueblo(Evento evento);
    void VisitCongreso(Evento evento);
    void VisitPalenque(Evento evento);
}

//visitor notificacion
public class NotificacionVisitor : EventoVisitor
{
    public void VisitConcierto(Evento evento)
    {
        Console.WriteLine($"Enviando notificación para el concierto: {evento.detalles.Nombre}");
    }
    public void VisitFeria(Evento evento)
    {
        Console.WriteLine($"Enviando notificación para la feria: {evento.detalles.Nombre}");
    }
    public void VisitMuestraCultural(Evento evento)
    {
        Console.WriteLine($"Enviando notificación para la muestra cultural: {evento.detalles.Nombre}");
    }
    public void VisitFiestaDePueblo(Evento evento)
    {
        Console.WriteLine($"Enviando notificación para la fiesta de pueblo: {evento.detalles.Nombre}");
    }
    public void VisitCongreso(Evento evento)
    {
        Console.WriteLine($"Enviando notificación para el congreso: {evento.detalles.Nombre}");
    }
    public void VisitPalenque(Evento evento)
    {
        Console.WriteLine($"Enviando notificación para el palenque: {evento.detalles.Nombre}");
    }
}

//visitor para registro de asistentes
public class RegistroVisitor : EventoVisitor
{
    private int asistentesAdicionales;
    public RegistroVisitor(int asistentesAdicionales)
    {
        this.asistentesAdicionales = asistentesAdicionales;
    }
    public void VisitConcierto(Evento evento)
    {
        evento.detalles.Cupo += asistentesAdicionales;
        Console.WriteLine($"Registro actualizado para el Concierto: {evento.detalles.Nombre}. Asistentes actuales: {evento.detalles.Cupo}");
    }
    public void VisitFeria(Evento evento)
    {
        evento.detalles.Cupo += asistentesAdicionales;
        Console.WriteLine($"Registro actualizado para la Feria: {evento.detalles.Nombre}. Asistentes actuales: {evento.detalles.Cupo}");
    }
    public void VisitMuestraCultural(Evento evento)
    {
        evento.detalles.Cupo += asistentesAdicionales;
        Console.WriteLine($"Registro actualizado para la Muestra Cultural: {evento.detalles.Nombre}. Asistentes actuales: {evento.detalles.Cupo}");
    }
    public void VisitFiestaDePueblo(Evento evento)
    {
        evento.detalles.Cupo += asistentesAdicionales;
        Console.WriteLine($"Registro actualizado para la Fiesta de Pueblo: {evento.detalles.Nombre}. Asistentes actuales: {evento.detalles.Cupo}");
    }
    public void VisitCongreso(Evento evento)
    {
        evento.detalles.Cupo += asistentesAdicionales;
        Console.WriteLine($"Registro actualizado para el Congreso: {evento.detalles.Nombre}. Asistentes actuales: {evento.detalles.Cupo}");
    }
    public void VisitPalenque(Evento evento)
    {
        evento.detalles.Cupo += asistentesAdicionales;
        Console.WriteLine($"Registro actualizado para el Palenque: {evento.detalles.Nombre}. Asistentes actuales: {evento.detalles.Cupo}");
    }
}

//visitor reporte
public class ReporteVisitor : EventoVisitor
{
    public void VisitConcierto(Evento evento)
    {
        Console.WriteLine($"Generando reporte para el concierto: {evento.detalles.Nombre}");
        Console.WriteLine($"Nombre: {evento.detalles.Nombre} / Cupo: {evento.detalles.Cupo} / VIP: {evento.detalles.Tipo}");
    }
    public void VisitFeria(Evento evento)
    {
        Console.WriteLine($"Generando reporte para la feria: {evento.detalles.Nombre}");
        Console.WriteLine($"Nombre: {evento.detalles.Nombre} / Cupo: {evento.detalles.Cupo} / VIP: {evento.detalles.Tipo}");
    }
    public void VisitMuestraCultural(Evento evento)
    {
        Console.WriteLine($"Generando reporte para la muestra cultural: {evento.detalles.Nombre}");
        Console.WriteLine($"Nombre: {evento.detalles.Nombre} / Cupo: {evento.detalles.Cupo} / VIP: {evento.detalles.Tipo}");
    }
    public void VisitFiestaDePueblo(Evento evento)
    {
        Console.WriteLine($"Generando reporte para la fiesta de pueblo: {evento.detalles.Nombre}");
        Console.WriteLine($"Nombre: {evento.detalles.Nombre} / Cupo: {evento.detalles.Cupo} / VIP: {evento.detalles.Tipo}");
    }
    public void VisitCongreso(Evento evento)
    {
        Console.WriteLine($"Generando reporte para el congreso: {evento.detalles.Nombre}");
        Console.WriteLine($"Nombre: {evento.detalles.Nombre} / Cupo: {evento.detalles.Cupo} / VIP: {evento.detalles.Tipo}");
    }
    public void VisitPalenque(Evento evento)
    {
        Console.WriteLine($"Generando reporte para el palenque: {evento.detalles.Nombre}");
        Console.WriteLine($"Nombre: {evento.detalles.Nombre} / Cupo: {evento.detalles.Cupo} / VIP: {evento.detalles.Tipo}");
    }
}

//extend clase evento con metodo accept
public partial class Evento
{
    public void Accept(EventoVisitor visitor)
    {
        switch (detalles.Tipo)
        {
            case "Concierto":
                visitor.VisitConcierto(this);
                break;
            case "Feria":
                visitor.VisitFeria(this);
                break;
            case "Muestra Cultural":
                visitor.VisitMuestraCultural(this);
                break;
            case "Fiesta de Pueblo":
                visitor.VisitFiestaDePueblo(this);
                break;
            case "Congreso":
                visitor.VisitCongreso(this);
                break;
            case "Palenque":
                visitor.VisitPalenque(this);
                break;
            default:
                Console.WriteLine("Tipo de evento no reconocido.");
                break;
        }
    }
}
