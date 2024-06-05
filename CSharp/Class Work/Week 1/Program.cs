// See https://aka.ms/new-console-template for more information
Console.WriteLine("What is your favorite fruit?");
string answer = Console.ReadLine();
string result = answer.ToLower();
if ((result == "oranges") || (result == "orange"))  {
    Console.WriteLine("There are oranges in available in the cafeteria!");
} else {
    Console.WriteLine($"Your favorite fruit is {result}? That is unfortunate!");
}

