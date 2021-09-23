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
    // criando um ID para essa publicação
    int max = 0;
    for (int i = 0; i < bancoPublicacoes.Count; i++) {
      if (bancoPublicacoes[i].ID > max) { max = bancoPublicacoes[i].ID; }
    }
    p.ID = max + 1; 
    bancoPublicacoes.Add(p);
  }

  public List<Publicacao> ListarPublicacao () {
    return bancoPublicacoes;
  } 

  public Publicacao GetPub (int ID) {
    for (int i = 0; i < bancoPublicacoes.Count; i++)
      if (bancoPublicacoes[i].ID == ID) 
        return bancoPublicacoes[i];
    return null;
  }

  public void ExcluirPublicacao (Publicacao p) {
    if (p != null) { bancoPublicacoes.Remove(p); }
  }

  public Publicacao Listar (int ID) {
    for (int i = 0; i < bancoPublicacoes.Count; i++)
      if (bancoPublicacoes[i].ID == ID) 
        return bancoPublicacoes[i];
    return null;
  }

  public void Curtir (int p) {
    Publicacao c = Listar(p);
    c.Curtir();
  }

// ---------------------------------------------------------------------- //

  public void NovoUsuario (Usuario u) {
    // criando um ID para esse usuario e adicionando-o no banco
    int max = 0;
    for (int i = 0; i < bancoUsuarios.Count; i++) {
      if (bancoUsuarios[i].ID > max) { max = bancoUsuarios[i].ID; }
    }
    u.ID = max + 1;
    bancoUsuarios.Add(u);
  }

  public List<Usuario> ListarUsuarios () {
    return bancoUsuarios;
  } 

  public Usuario GetUsuario (int ID) {
    for (int i = 0; i < bancoUsuarios.Count; i++)
      if (bancoUsuarios[i].ID == ID) 
        return bancoUsuarios[i];
    return null;
  }
} 