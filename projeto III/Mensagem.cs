using System;
using System.Collections.Generic;

public class Mensagem {
  public string Conteudo { get; set; }
  public string Email { get; set; }
  public int ID { get; set; }

  public override string ToString () {
    Console.WriteLine("------------------------------------------------------");
    Console.WriteLine($"{Email}           ID - {ID}");
    Console.WriteLine("______________________________________________________");
    Console.WriteLine($"{Conteudo}");
    Console.WriteLine("______________________________________________________");
    Console.WriteLine("------------------------------------------------------");
    return "\n\n"; 
  }
}
