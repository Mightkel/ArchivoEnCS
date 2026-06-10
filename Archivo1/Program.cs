//Akmacenar 10 registros de estudiantes; nombre, carrera y promedio
Estudiante[] estudiante = new Estudiante[10];
int i = 0;

int menu()
{
    Console.WriteLine("1. Agregar");
    Console.WriteLine("2. Mostrar");
    Console.WriteLine("3. Guardar Archivo");
    Console.WriteLine("4. Eliminar");
    Console.WriteLine("0. Salir");
    Console.Write("Digita tu opción: ");
    return int.Parse(Console.ReadLine()!);
}

void pedirdatos()
{
    if (i < 10 )
    {
        Console.WriteLine($"Registro #{i + 1}");
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
    i++;
    }
    else
    {
        Console.WriteLine("No hay espacio para mas registros");
    }
}

void mostrardatos()
{
    for (int cont = 0; cont < 10; cont++)
    {
        Console.WriteLine($"Estudiante #: {cont + 1}");
        Console.WriteLine($"{estudiante[cont].nombre} | {estudiante[cont].carrera} | {estudiante[cont].promedio}");
    }
}

void guardararchivo()
{
    StreamWriter archivo = new StreamWriter("registro.csv");
    for (int cont = 0; cont < i; cont++)
    {
        archivo.WriteLine(estudiante[cont].nombre + ";" + estudiante[cont].carrera + ";" + estudiante[cont].promedio);
    }
    archivo.Close();
    Console.WriteLine("Registro guardado");
}

int buscarRegistro(string nombre)
{
    return Array.FindIndex(estudiante, est => est.nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
}

void eliminarRegistro(string nombre)
{
    int pos = buscarRegistro(nombre);

    if (pos == -1)
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("Estudiante no existe");
        Console.ResetColor();
        Console.ReadKey();
        return;
    }
    for(int i = pos; i< estudiante.Length-1 ; i++)
    {
        estudiante[i] = estudiante[i + 1];
    }
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.WriteLine("Registro eliminado");
    i--;
    Console.ReadKey();
    Console.ResetColor();
}

void leerarchivo()
{
    StreamReader archivo = new StreamReader("registro.csv");
    string linea;
    while((linea = archivo.ReadLine()!) != null && i < 10)
    {
        string[] dato = linea.Split(';');
        estudiante[i].nombre = dato[0];
        estudiante[i].carrera = dato[1];
        estudiante[i].promedio = double.Parse(dato[2]);
        i++;
    }
    archivo.Close();
}

void main()
{
    string nombre;
    int op;
    leerarchivo();
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
                Console.WriteLine("Que estudiante deseas eliminar? ");
                nombre = Console.ReadLine();
                eliminarRegistro(nombre);
                break;
            case 0:
                Console.WriteLine("Adios...");
                break;
            default:
                Console.WriteLine("Opcion invalida");  
                break;
        }
    }while (op != 0);
}

main();

struct Estudiante
{
    public string nombre;
    public string carrera;
    public double promedio;
}
