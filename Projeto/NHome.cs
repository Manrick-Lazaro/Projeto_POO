using System;

class NHome {
  private static int id = 0;
  private int control = 0;
  private Home he;
  private Publications[] feed = new Publications [10];

  public void SetH (Home h) {
    he = h;
  }

  public void NovoPost (string a) {
    if (control == feed.Length) {
      Array.Resize(ref feed, 2 * feed.Length);
    }
    a = Console.ReadLine();
    id++;
    Publications z = new Publications(a,id);
    feed[control] = z;
    control++;
  }

  public Publications[] ListarPost () {
    Publications[] w = new Publications [control];
    Array.Copy(feed, w, control);
    return w;
  }

  public Publications Listar (int ID) {
    for (int i = 0; i < control; i++)
      if (feed[i].GetId() == id) return 
      feed[i];
    return null;
  }

  public void AtualizarPost (Publications p) {
    Publications x = Listar(p.GetId());
    if (x == null) return;
    x.EditPost(p.GetPost());
  }

  private int Indice (Publications pub) {
    for (int i = 0; i < control; i++){
      if (feed[i] == pub) 
        return i;
    }
    return -1;
  }

  public void ExcluirPost (Publications p) {
    int i = Indice(p);
    if (i == -1) return;
    for (int j = i; j<control; j++) {
      feed[j] = feed[j + 1];
    }
    control--;
  }
}