using System.Text.RegularExpressions;


Console.WriteLine("Hello, World!");

string atributos = "public string InscricaoParceiro { get; set; }public string IdProposta { get; set; }public string ProtocoloParceiro { get; set; }public bool Concorda { get; set; }";

string padraoGetSet = "{ get; set; }";
string padraoPublic = "public";

Regex rg = new Regex(padraoGetSet);




