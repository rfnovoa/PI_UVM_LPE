using PI;

internal class Program
{
    static List<Car> carInventory = new List<Car>();
    static int currentId = 1;
    private static void Main(string[] args)
    {
        Banner();
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("1. Agregar Auto");
            Console.WriteLine("2. Eliminar Auto");
            Console.WriteLine("3. Modificar Auto");
            Console.WriteLine("4. Buscar Auto");
            Console.WriteLine("5. Salir");
            Console.Write("Selecciona una opción: ");
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) { input = "0"; }
            int option = Convert.ToInt32(input);
            switch (option)
            {
                case 1:
                    AddCar();
                    break;
                case 2:
                    DeleteCar();
                    break;
                case 3:
                    UpdateCar();
                    break;
                case 4:
                    SearchCar();
                    break;
                case 5:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Opción inválida, intenta de nuevo.");
                    break;
            }
        }
    }
    static void AddCar()
    {
        var car = new Car();
        car.Id = currentId++;

        Console.Write("Marca: ");
        car.Make = Console.ReadLine();

        Console.Write("Modelo: ");
        car.Model = Console.ReadLine();

        Console.Write("Año: ");
        car.Year = Convert.ToInt32(Console.ReadLine());

        Console.Write("Número de Serie: ");
        car.VIN = Console.ReadLine();

        Console.Write("Kilometraje: ");
        car.Mileage = Convert.ToDouble(Console.ReadLine());

        Console.Write("Color: ");
        car.Color = Console.ReadLine();

        Console.Write("Placa: ");
        car.LicensePlate = Console.ReadLine();

        car.IsAvailable = true; // By default, the car is available
        car.DateAcquired = DateTime.Now;

        carInventory.Add(car);
        Console.WriteLine("El auto fue agregado con éxito");
    }

    static void DeleteCar()
    {
        Console.Write("ID del auto a eliminar: ");
        var input = Console.ReadLine();
        if (string.IsNullOrEmpty(input)) { input = "0"; }
        int id = Convert.ToInt32(input);
        var car = carInventory.FirstOrDefault(c => c.Id == id);
        if (car != null)
        {
            Console.WriteLine($"Marca: {car.Make}");

            Console.WriteLine($"Modelo: {car.Model}");

            Console.WriteLine($"Año: {car.Year}");

            Console.WriteLine($"Número de Serie: {car.VIN}");

            Console.WriteLine($"Kilometraje: {car.Mileage}");

            Console.WriteLine($"Color: {car.Color}");

            Console.WriteLine($"Placa: {car.LicensePlate}");
            Console.WriteLine();

            Console.Write("Deseas eliminar el automóvil? (S/N):");

            input = Console.ReadLine();
            input ??= "";
            switch (input.ToUpper())
            {
                case "S":
                    carInventory.Remove(car);
                    Console.WriteLine("Auto eliminado con éxito!");
                    break;
                case "N":
                    Console.WriteLine("Operación cancelada!");
                    break;
                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Auto no encontrado!");
        }
    }

    static void UpdateCar()
    {
        Console.Write("Escribe el ID del carro a modificar: ");
        int id = Convert.ToInt32(Console.ReadLine());
        var car = carInventory.FirstOrDefault(c => c.Id == id);

        if (car != null)
        {
            Console.Write("Escribe la nueva Marca  (o déjalo en blanco para mantener el valor actual): ");
            string make = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(make))
            {
                car.Make = make;
            }

            Console.Write("Escribe el nuevo Modelo (o déjalo en blanco para mantener el valor actual): ");
            string model = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(model))
            {
                car.Model = model;
            }

            Console.Write("Escribe el nuevo Año (o déjalo en blanco para mantener el valor actual): ");
            string year = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(year))
            {
                car.Year = Convert.ToInt32(year);
            }

            Console.Write("Escribe el nuevo # de Serie (o déjalo en blanco para mantener el valor actual): ");
            string vin = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(vin))
            {
                car.VIN = vin;
            }

            Console.Write("Escribe el nuevo Kilometraje (o déjalo en blanco para mantener el valor actual): ");
            string mileage = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(mileage))
            {
                var newMileage = Convert.ToDouble(mileage);
                if (newMileage <= car.Mileage)
                {
                    Console.Write("El nuevo kilometraje no puede ser menor que el anterior");
                } else
                {
                    car.Mileage = Convert.ToDouble(mileage);
                }
            }

            Console.Write("Escribe el nuevo Color (o déjalo en blanco para mantener el valor actual): ");
            string color = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(color))
            {
                car.Color = color;
            }

            Console.Write("Escribe la nueva Placa (o déjalo en blanco para mantener el valor actual): ");
            string licensePlate = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(licensePlate))
            {
                car.LicensePlate = licensePlate;
            }

            Console.Write("El auto está disponible escribe  (si/no o déjalo en blanco para mantener el valor actual): ");
            string isAvailable = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(isAvailable))
            {
                car.IsAvailable = isAvailable.Trim().ToLower() == "si";
            }

            Console.WriteLine("El auto se actualizó con éxito!");
        }
        else
        {
            Console.WriteLine("El auto no pudo ser encontrado!");
        }
    }


    static void SearchCar()
    {
        Console.Write("Criterio de búsqueda: ");
        var input = Console.ReadLine();
        List<Car> searchResults = new List<Car>();

        if (string.IsNullOrEmpty(input))
        {
            searchResults = carInventory;
        } else
        {
            string searchTerm = input.ToLower();

            searchResults = carInventory.Where(car =>
                car.Make.ToLower().Contains(searchTerm) ||
                car.Model.ToLower().Contains(searchTerm) ||
                car.VIN.ToLower().Contains(searchTerm) ||
                car.Color.ToLower().Contains(searchTerm) ||
                car.LicensePlate.ToLower().Contains(searchTerm) ||
                car.Year.ToString().Contains(searchTerm) ||
                car.Mileage.ToString().Contains(searchTerm)
            ).ToList();
        }        

        if (searchResults.Any())
        {
            Console.WriteLine($"{"ID",-5} {"Marca",-10} {"Modelo",-10} {"Año",-5} {"Serie",-20} {"Kilometraje",-10} {"Color",-10} {"Disponible",-10} {"Placa",-10} {"Adquirido",-15}");
            foreach (var car in searchResults)
            {
                Console.WriteLine($"{car.Id,-5} {car.Make,-10} {car.Model,-10} {car.Year,-5} {car.VIN,-20} {car.Mileage,-10} {car.Color,-10} {(car.IsAvailable ? "S":"N"),-10} {car.LicensePlate,-10} {car.DateAcquired.ToShortDateString(),-15}");
            }
        }
        else
        {
            Console.WriteLine("No se encontraron autos con el criterio de búsqueda.");
        }
    }

    static void Banner()
    {
        Console.Clear();
        Console.WriteLine("\r\n██████╗ ██████╗  ██████╗ ██╗   ██╗███████╗ ██████╗████████╗ ██████╗             \r\n██╔══██╗██╔══██╗██╔═══██╗╚██╗ ██╔╝██╔════╝██╔════╝╚══██╔══╝██╔═══██╗            \r\n██████╔╝██████╔╝██║   ██║ ╚████╔╝ █████╗  ██║        ██║   ██║   ██║            \r\n██╔═══╝ ██╔══██╗██║   ██║  ╚██╔╝  ██╔══╝  ██║        ██║   ██║   ██║            \r\n██║     ██║  ██║╚██████╔╝   ██║   ███████╗╚██████╗   ██║   ╚██████╔╝            \r\n╚═╝     ╚═╝  ╚═╝ ╚═════╝    ╚═╝   ╚══════╝ ╚═════╝   ╚═╝    ╚═════╝             \r\n                                                                                \r\n██╗███╗   ██╗████████╗███████╗ ██████╗ ██████╗  █████╗ ██████╗  ██████╗ ██████╗ \r\n██║████╗  ██║╚══██╔══╝██╔════╝██╔════╝ ██╔══██╗██╔══██╗██╔══██╗██╔═══██╗██╔══██╗\r\n██║██╔██╗ ██║   ██║   █████╗  ██║  ███╗██████╔╝███████║██║  ██║██║   ██║██████╔╝\r\n██║██║╚██╗██║   ██║   ██╔══╝  ██║   ██║██╔══██╗██╔══██║██║  ██║██║   ██║██╔══██╗\r\n██║██║ ╚████║   ██║   ███████╗╚██████╔╝██║  ██║██║  ██║██████╔╝╚██████╔╝██║  ██║\r\n╚═╝╚═╝  ╚═══╝   ╚═╝   ╚══════╝ ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚═════╝  ╚═════╝ ╚═╝  ╚═╝\r\n                                                                                \r\n");
        Console.WriteLine("Proyecto Integrador © 2023 by Roberto Novoa is licensed under CC BY-NC-SA 4.0.");
        Console.WriteLine("To view a copy of this license, visit http://creativecommons.org/licenses/by-nc-sa/4.0/");
        Console.WriteLine();
    }
}
