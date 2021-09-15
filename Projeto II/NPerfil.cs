using System;

class NPerfil {
  private Perfil perfil;

  public void SetPerfil (Perfil p) {
    perfil = p;
  }

  // set dados do perfil
  public void Nome () { 
    perfil.Nome(Console.ReadLine());
  }
  public void Email () {
    perfil.Email(Console.ReadLine());
  }
  public void Telefone () {
    perfil.Telefone(Console.ReadLine());
  } 
  public void Data () {
    perfil.Data((DateTime)Console.ReadLine());
  } 
  public void Cidade () {
    perfil.Cidade(Console.ReadLine());
  }

  // get dados do perfil
  public string GNome () { 
    return perfil.Nome;
  }
  public string GEmail () {
    return perfil.Email;
  }
  public string GTelefone () {
    return perfil.Telefone;
  } 
  public string GData () {
    return perfil.Data;
  } 
  public string GCidade () {
    return perfil.Cidade;
  }

  public override string ToString () {
    return $"{pefil.ToString()}";
  }
}