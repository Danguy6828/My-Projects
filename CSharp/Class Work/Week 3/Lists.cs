List<string> students = new List<string>() {
    "Name" ,
    "Nami" ,
    "Naem"
};

students.Add("Nae");
students.Add("Mae");

string statement = String.Join("','", students);
Console.WriteLine($"['{statement}']");