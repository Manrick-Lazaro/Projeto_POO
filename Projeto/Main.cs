using System;

class MainClass {
  public static void Main (string[] argc) {
    Profile user1 = new Profile ("manrick", 19735);
    Console.WriteLine(user1);
    
    user1.SetTelephone("998307796");
    Console.WriteLine(user1);
  }
}