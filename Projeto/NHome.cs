using System;

class NHome {
  private static string a = "";
  private int control = 0;
  private Home he;
  private Publications[] feed = new Publications [10];
  

  public void SetH (Home h) {
    he = h;
  }

  public void NovoPost () {
    if (control == feed.Length) {
      Array.Resize(ref feed, 2 * feed.Length);
    }
    a = Console.ReadLine();
    Publications z = new Publications(a);
    feed[control] = z;
    control++;
  } 

  public Publications[] ListarPost () {
    Publications[] w = new Publications [control];
    Array.Copy(feed, w, control);
    return w;
  }
}