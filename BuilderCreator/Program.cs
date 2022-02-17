using System.Text.RegularExpressions;


Console.WriteLine("Hello, World!");

List<string> tipos = new();
tipos.Add("string");
tipos.Add("string");

string padraoGetSet = "{ get; set; }";
string padraoPublic = "public";

Regex rg = new Regex(padraoGetSet);




