using System;

class MainClass {
  public static void Main (string[] argc) {
    Profile user1 = new Profile ("manrick", 19735);
    Console.WriteLine(user1);
    
    // adiciona os dados do perfil
    Console.WriteLine("\n"); // separar 
    user1.SetEmail("manrick@gmail.com");
    user1.SetTelephone("123456789");
    user1.SetDate("12,18,2000");
    user1.SetCity("Alabasta");

    Console.WriteLine(user1);
  }
}