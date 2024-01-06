// See https://aka.ms/new-console-template for more information
using System.Globalization;

class Program
{
    public static List<Task> taskizin = new List<Task>();

    public static int i;

    static void Main()
    {
        Console.WriteLine("Organizador de tarefa");
        while (true)
        {
            Console.WriteLine("Escolha uma opcao:");
            Console.WriteLine("1. Adicionar tarefa");
            Console.WriteLine("2. Ver tarefas");
            Console.WriteLine("3. Riscar a tarefa");
            Console.WriteLine("4. Deletar a tarefa");
            Console.WriteLine("5. Sai");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddiTask();
                    break;
                case "2":
                    VerTasks();
                    break;
                case "3":
                    RiscarTask();
                    break;
                case "4":
                    DeletarTask();
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Nao tem. Tente novamente.");
                    break;
            }
        }
    }

    static void AddiTask()
    {
        Console.Write("Digite a tarefa: ");
        string title = Console.ReadLine();

        Console.Write("Digite a descrição da tarefa: ");
        string description = Console.ReadLine();

        Task newTask = new Task(title, description);
        taskizin.Add(newTask);

        Console.WriteLine("Tarefa adicionada com sucesso!");
    }
    
    static void RiscarTask()
    {
        Console.WriteLine("Escolha qual tarefa riscar:");

        for (int i = 0; i < taskizin.Count; i++)
        {
            string taskRepresentation = taskizin[i].IsCompleto
            ? $"\u0336{taskizin[i].Title} - {taskizin[i].Description}\u0336 [Riscado]"
            : $"{taskizin[i].Title} - {taskizin[i].Description} [Pendente]";

            Console.WriteLine($"{i + 1}. {taskRepresentation}");
        }

        if (taskizin.Count == 0)
        {
            Console.WriteLine("Nenhuma tarefa para riscar");
        }

        Console.Write("Digite o numero da tarefa a ser riscada: ");
        if (int.TryParse(Console.ReadLine(), out int esIndex) && esIndex >= 1 && esIndex <= taskizin.Count)
        {
            taskizin[esIndex - 1].IsCompleto = !taskizin[esIndex - 1].IsCompleto;
            Console.WriteLine("Tarefa marcada como concluida!");
        }
        else
        {
            Console.WriteLine("Numero invalido. Tente novamente.");
        }
    }

    static void DeletarTask()
    { 
        Console.WriteLine("Escolha qual tarefa deletar: ");
    
        for (i = 0; i < taskizin.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {taskizin[i].Title} - {taskizin[i].Description}");
        }

        if (taskizin.Count == 0)
        {
            Console.WriteLine("Nenhuma tarefa para deletar");
            return;
        }

        Console.Write("Digite o numero da tarefa a ser deletada: ");
        if (int.TryParse(Console.ReadLine(), out int choiceIndex) && choiceIndex >= 1 && choiceIndex <= taskizin.Count)
        {
            taskizin.RemoveAt(choiceIndex - 1);
            Console.WriteLine("Tarefa deletada com sucesso!");
        }
        else
        {
           Console.WriteLine("Numero invalido. Tente novamente.");
        }     
    }
    static void VerTasks()
    {
        if (taskizin.Count == 0)
        {
            Console.WriteLine("Nenhuma tarefa cadastrada.");
            return;
        }

        Console.WriteLine("Lista de Tarefas: ");

        for (int i = 0; i < taskizin.Count; i++)
        {
            string taskRepresentation = taskizin[i].IsCompleto
            ? $"\u0336{taskizin[i].Title} - {taskizin[i].Description}\u0336 [Riscado]"
            : $"{taskizin[i].Title} - {taskizin[i].Description} [Pendente]";

            Console.WriteLine($"{i + 1}. {taskRepresentation}");
        }
    }
}

class Task
{
    public string Title { get; set; }
    public string Description { get; set; }

    public bool IsCompleto { get; set; }

    public Task(string ti, string dc)
    {
        Title = ti;
        Description = dc;
    }
}
