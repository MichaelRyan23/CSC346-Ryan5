// driver file

bool exit = false;
PS5 ps5 = new PS5();
Switch nintendoSwitch = new Switch();

while (!exit) {
    WriteLine("\nWelcome to the Game Store!\n");
    WriteLine("Select a game system:");
    WriteLine("1. PS5");
    WriteLine("2. Switch");
    WriteLine("3. Exit");

    Write("\nEnter your choice (1-3): ");
    if (int.TryParse(Console.ReadLine(), out int choice)) {
        switch (choice) {
            case 1:
                ps5.Start();
                break;
            case 2:
                nintendoSwitch.Start();
                break;
            case 3:
                exit = true;
                WriteLine("\nThank you for using the Game Store. Goodbye!");
                break;
            default:
                WriteLine("\nInvalid choice. Please try again.");
                break;
        }
    }
    else {
        WriteLine("\nInvalid input. Please enter a valid choice.");
    }
}