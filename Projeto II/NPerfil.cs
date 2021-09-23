using System;

class NPerfil {
  private Perfil perfil;

  public void SetPerfil (Perfil p) {
    perfil = p;
  }

  // set dados do perfil
  public void Nome (string value) { 
    perfil.Nome = value;
  }
  public void Email (string value) {
    perfil.Email = value;
  }
  public void Telefone (string value) {
    perfil.Telefone = value;
  } 
  public void Data (string value) {
    perfil.Data = Convert.ToDateTime(value);
  } 
  public void Cidade (string value) {
    perfil.Cidade = value;
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
  public DateTime GData () {
    return perfil.Data;
  } 
  public string GCidade () {
    return perfil.Cidade;
  }

  public override string ToString () {
    return $"{perfil.ToString()}";
  }
}