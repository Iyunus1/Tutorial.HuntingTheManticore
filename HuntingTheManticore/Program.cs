int player1 = askForRange("Player 1, how far away from the city do you want to place the manticore", 1, 100);
Console.Clear();
Console.WriteLine(player1);

int manticore = 10;
int city = 15;
int round = 1;

while (city > 0 && manticore > 0)
{
    Console.WriteLine("----------------------------------------------------------");
    Console.WriteLine($"STATUS: Round: {round} City: {city}/15 Manticore: {manticore}/10");
    int expectedDamage = cannonDamage(round); ;
    Console.WriteLine($"The cannon is expected to deal {expectedDamage} damage this round");
    Console.WriteLine($"The cannon is expected to deal {expectedDamage + 1} damage next round");
    int player2 = userNumPrompt("Enter the desired cannon range: ");

    displayAttackResult(player1, player2);

    if (player1 == player2)
        manticore -= expectedDamage;

    Console.WriteLine("----------------------------------------------------------");
    round++;
    city--;
}

if (manticore <= 0) colorText("The Manticore has been destroyed! The city of consolas has been saved!", ConsoleColor.Green);
else colorText("The city has been destroyed! The manticore wins!", ConsoleColor.Red);

void displayAttackResult(int player1, int player2)
{
    if (player1 == player2) Console.WriteLine("That round was a DIRECT HIT!");
    if (player1 > player2) Console.WriteLine("That round FELL SHORT of the target!");
    if (player1 < player2) Console.WriteLine("That round OVERSHOT the target !");
}

int askForRange(String text, int min, int max)
{
    while (true)
    {
        Console.WriteLine(text);
        int value = int.Parse(Console.ReadLine());

        if (value > min && value < max)
        {
            return value;

        }

    }
}

void colorText(String text,ConsoleColor color )
{
    Console.ForegroundColor = color;
    Console.WriteLine(text);
}

int userNumPrompt(String text)
{
    Console.Write(text);
    return Convert.ToInt32(Console.ReadLine());
    
}

int cannonDamage(int cannonRound)
{
    bool isMultiplyBy5 = cannonRound % 5 == 0;
    bool isMultiplyBy3 = cannonRound % 3 == 0;

    if (isMultiplyBy5 && isMultiplyBy3) return 10;
    if (isMultiplyBy5 || isMultiplyBy3) return 3;
    return 1;
 }
