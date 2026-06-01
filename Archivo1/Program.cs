//Akmacenar 10 registros de estudiantes; nombre, carrera y promedio
Estudiante[] estudiante = new Estudiante[10];

int menu()
{
    Console.WriteLine("1. Agregar");
    Console.WriteLine("2. Mostrar");
    Console.WriteLine("3. Guardar Archivo");
    Console.WriteLine("4. Salir");
    Console.Write("Digita tu opción: ");
    return int.Parse(Console.ReadLine()!);
}

void pedirdatos()
{
    for (int i = 0; i < 10; i++)
    {
        Console.Write("Ingrese el nombre del estudiante: ");
        try
        {
            estudiante[i].nombre = Console.ReadLine()!;
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            i--;
        }
        
        Console.Write("Ingrese la carrera del estudiante: ");
        try
        {
            estudiante[i].carrera = Console.ReadLine()!;
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            i--;
        }
        
        Console.Write("Ingrese el promedio del estudiante: ");
        try
        {
            estudiante[i].promedio = double.Parse(Console.ReadLine()!);
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            i--;
        }
        
    }
}

void mostrardatos()
{
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine($"{estudiante[i].nombre} | {estudiante[i].carrera} | {estudiante[i].promedio}");
    }
}

void guardararchivo()
{
    StreamWriter archivo = new StreamWriter("registro.txt");
    for (int i = 0; i < 10; i++)
    {
        archivo.WriteLine(estudiante[i].nombre + ";" + estudiante[i].carrera + ";" + estudiante[i].promedio);
    }
    archivo.Close();
    Console.WriteLine("Registro guardado");
}

void main()
{
    int op;
    do
    {
        op = menu();
        switch (op)
        {
            case 1:
                pedirdatos();
                break;
            case 2:
                mostrardatos();
                break;
            case 3:
                guardararchivo();
                break;
            case 4:
                Console.WriteLine("Adios...");
                break;
            default:
                Console.WriteLine("Opcion invalida");  
                break;
        }
    }while (op != 4);
}

main();

struct Estudiante
{
    public string nombre;
    public string carrera;
    public double promedio;
}
