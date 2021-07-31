using System;

class NPerfil {
  private Perfil pr;

  public void SetPerfil (Profile p) {
    pr = p;
  }

  public void Nome () {
    pr.SetName(Console.ReadLine());
  }
  public void EMail () {
    pr.SetName(Console.ReadLine());
  }
  public void Tel () {
    pr.SetName(Console.ReadLine());
  }
  public void Data () {
    pr.SetName(Console.ReadLine());
  }
  public void Cidade () {
    pr.SetName(Console.ReadLine());
  }

  public override string ToString () {
    return $"{pr.ToString()}";
  }
}