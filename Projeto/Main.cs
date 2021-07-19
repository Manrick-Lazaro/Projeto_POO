using System;

class MainClass {
  public static void Main (string[] argc) {
    // usuario 1
    User user1 = new User ("zezinho", "19735");
    Profile profile1 = new Profile (user1);
    
    Console.WriteLine(profile1);
    
    // adiciona os dados do perfil
    Console.WriteLine("\n"); // separar 
    profile1.SetEmail("zezinho@gmail.com");
    profile1.SetTelephone("123456789");
    profile1.SetDate("12,18,2000");
    profile1.SetCity("Alabasta");

    Console.WriteLine(profile1);
    
    Console.WriteLine("-------------------------------------------");
    
    // usuario 2
    User user2 = new User ("jaozinho","75198");
    Profile profile2 = new Profile (user2);
      
    Console.WriteLine(profile2);
    
    // adiciona os dados do perfil
    Console.WriteLine("\n"); // separar 
    profile2.SetEmail("jaozinho@gmail.com");
    profile2.SetTelephone("987654321");
    profile2.SetDate("01,09,1997");
    profile2.SetCity("Dressrosa");

    Console.WriteLine(profile2);
    Console.WriteLine("-------------------------------------------");
    
    // criar um post para o perfil 2
    Home homeProfile2 = new Home ();

    Publications pub1Profile2 = new Publications ("Hello world");
    homeProfile2.NewPost(pub1Profile2);

    Publications pub2Profile2 = new Publications ("this is my code");
    homeProfile2.NewPost(pub2Profile2);

    Publications[] a = homeProfile2.GetPublications ();
    foreach (Publications p in a) {Console.WriteLine(p);}
    Console.WriteLine("-------------------------------------------");
    // adicionar amigos ao perfil 2
    Friends amigo1 = new Friends (profile1);

    homeProfile2.AddFriends(amigo1);
    Console.WriteLine(profile2.GetFollows());
  }
}