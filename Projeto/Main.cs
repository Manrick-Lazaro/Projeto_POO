using System;

class MainClass {
  public static void Main (string[] argc) {
    // usuario 1
    Profile user1 = new Profile ("zezinho", 19735);
    Console.WriteLine(user1);
    
    // adiciona os dados do perfil
    Console.WriteLine("\n"); // separar 
    user1.SetEmail("zezinho@gmail.com");
    user1.SetTelephone("123456789");
    user1.SetDate("12,18,2000");
    user1.SetCity("Alabasta");

    Console.WriteLine(user1);
    Console.WriteLine("-------------------------------------------");
    // usuario 2
    Profile user2 = new Profile ("jaozinho", 75198);
      
    Console.WriteLine(user2);
    
    // adiciona os dados do perfil
    Console.WriteLine("\n"); // separar 
    user2.SetEmail("jaozinho@gmail.com");
    user2.SetTelephone("987654321");
    user2.SetDate("01,09,1997");
    user2.SetCity("Dressrosa");

    Console.WriteLine(user2);
    Console.WriteLine("-------------------------------------------");
    
    // criar um post para o user 2
    Home homeUser2 = new Home ();

    Publications pub1User2 = new Publications ("Hello world");
    homeUser2.NewPost(pub1User2);

    Publications pub2User2 = new Publications ("this is my code");
    homeUser2.NewPost(pub2User2);

    Publications[] a = homeUser2.GetPublications ();
    foreach (Publications p in a) {Console.WriteLine(p);}
  }
}