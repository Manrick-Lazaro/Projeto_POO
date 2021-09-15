using System;

class NPerfil {
  private Perfil pr;

  public void SetPerfil (Perfil p) {
    pr = p;
  }

  public void Nome () {
    pr.SetName(Console.ReadLine());
  }
  public void EMail () {
    pr.SetEmail(Console.ReadLine());
  }
  public void Tel () {
    pr.SetTelephone(Console.ReadLine());
  }
  public void Data () {
    pr.SetDate(Console.ReadLine());
  }
  public void Cidade () {
    pr.SetCity(Console.ReadLine());
  }
  public void amigo (bool x) {
    pr.SetAmigo(x);
  }
  public void amigoEX (bool x) {
    pr.SetEXAmigo(x);
  }

  public override string ToString () {
    return $"{pr.ToString()}";
  }
}