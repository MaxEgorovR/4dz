
var team = new Team();

team.AddWorker(new Worker(new Basement()));
team.AddWorker(new Worker(new Walls()));
team.AddWorker(new Worker(new Walls()));
team.AddWorker(new Worker(new Walls()));
team.AddWorker(new Worker(new Walls()));
team.AddWorker(new Worker(new Door()));
team.AddWorker(new Worker(new Window()));
team.AddWorker(new Worker(new Window()));
team.AddWorker(new Worker(new Window()));
team.AddWorker(new Worker(new Window()));
team.AddWorker(new Worker(new Roof()));

team.Work();

Console.WriteLine("Строительство дома завершено");


Console.WriteLine("+---------------------------------------+");
Console.WriteLine("|  |  Windows  |       |  Windows  |    |");
Console.WriteLine("|                                       |");
Console.WriteLine("|                                       |");
Console.WriteLine("|                                       |");
Console.WriteLine("|                                       |");
Console.WriteLine("|                                       |");
Console.WriteLine("|                                       |");
Console.WriteLine("|                                       |");
Console.WriteLine("|                                       |");
Console.WriteLine("|                                       |");
Console.WriteLine("|                                       |");
Console.WriteLine("| Windows  |   |  Door  |   |  Windows  |");
Console.WriteLine("+---------------------------------------+");

public class House : IPart
{
    public Basement Basement { get; set; }
    public Walls Walls { get; set; }
    public Door Door { get; set; }
    public Window Window { get; set; }
    public Roof Roof { get; set; }

    public void Build()
    {
        Basement.Build();
        Walls.Build();
        Door.Build();
        Window.Build();
        Roof.Build();
    }
}

public class Basement : IPart
{
    public void Build() { }
}

public class Walls : IPart
{
    public void Build() { }
}

public class Door : IPart
{
    public void Build() {  }
}

public class Window : IPart
{
    public void Build() { }
}

public class Roof : IPart
{
    public void Build() { }
}

public interface IPart
{
    void Build();
}

public interface IWorker
{
    void Work();
}
public class Team : IWorker
{
    private List<IWorker> workers;

    public Team()
    {
        workers = new List<IWorker>();
    }

    public void AddWorker(IWorker worker)
    {
        workers.Add(worker);
    }

    public void Work()
    {
        foreach (var worker in workers)
        {
            worker.Work();
        }
    }
}

public class Worker : IWorker, IPart
{
    private IPart part;

    public Worker(IPart part)
    {
        this.part = part;
    }

    public void Work()
    {
        part.Build();
    }

    public void Build()
    {
        Console.WriteLine("Строитель работает");
        part.Build();
    }
}
public class TeamLeader : IWorker, IPart
{
    private IPart part;

    public TeamLeader(IPart part)
    {
        this.part = part;
    }

    public void Work()
    {
        Console.WriteLine("Бригадир работает");
        part.Build();
        Report();
    }

    public void Build()
    {
        House house = new House();
        house.Build();
    }

    private void Report()
    {
        Console.WriteLine("Отчёт о строительстве");
    }
}