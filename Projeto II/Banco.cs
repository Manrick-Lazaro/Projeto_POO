using System;
using System.Collections.Generic;

/*
  o objetivo dessa classe é armazenar todas as publicações 
  que forem feitas na plataforma.
*/

class Banco {
  private List<Publicacao> bancoPublicacoes = new List<Publicacao>();
  private List<Usuario> bancoUsuarios = new List<Usuario>();

  public void setPub (Publicacao p) {
    bancoPublicacoes.Add(p);
  }

  public List<Publicacao> ListarPublicacao () {
    return bancoPublicacoes;
  } 

  public Publicacao GetPub (int ID) {
    for (int i = 0; i < bancoPublicacoes.Count; i++)
      if (bancoPublicacoes[i].ID == ID) 
        return postagensUsuario[i];
    return null;
  }

  public void NovoUsuario (Usuario u) {
    bancoSsuarios.Add(u);
  }

  public List<Usuario> ListarUsuarios () {
    return bancoUsarios;
  } 

  public Usuario GetUsuario (int ID) {
    for (int i = 0; i < bancoUsuarios.Count; i++)
      if (bancoUsuarios[i].ID == ID) 
        return usuarios[i];
    return null;
  }
} 