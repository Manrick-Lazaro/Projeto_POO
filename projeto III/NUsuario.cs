using System;
using System.Collections.Generic;

public class NUsuario {
  private Usuario usuario;
  private List<Publicacao> publicacoes = new List<Publicacao>();
  private List<Usuario> amigos = new List<Usuario>();
  private Publicacao p = new Publicacao();
  
  public void SetUsuario (Usuario u) {
    usuario = u;
  }

  public int IDUsuario () {
    return usuario.ID;
  }

  public Usuario GetUsuario () {
    return usuario;
  }

  public string GetEmail () {
    return usuario.GetEmailUser;
  }

  public List<Mensagem> MensagensRecebidas {
    get {return usuario.GetMenagens;}
  }

// ------------------------------------------------------ //

  public void NovoPost (Publicacao p) {
    publicacoes.Add(p);
  }

  public List<Publicacao> ListarPostagens () { 
    return publicacoes;
  }

  public Publicacao Listar (int ID) {
    for (int i = 0; i < publicacoes.Count; i++)
      if (publicacoes[i].ID == ID) 
        return publicacoes[i];
    return null;
  }

  public void AtualizarPostagem (string n, int a) {
    Publicacao atualizacao = Listar(a);
    if (atualizacao == null) 
      return;
    atualizacao.EditarPostagem(n);
  }

  public void ExcluirPostagem (Publicacao p) {
    if (p != null) { publicacoes.Remove(p); }
  }

  public void RetirarLike () {

  }
  
  public void Comentar () {

  }

  public void ExcluirComentario () {

  }

  public void EditarComentario () {

  }


// ------------------------------------------------------ //
  public void AddAmigo (int id) {
    Banco b = new Banco ();
    Usuario u = new Usuario ();
    u = b.GetUsuario(id);
    amigos.Add(u);
  }

  public List<Usuario> ListarAmigos () { 
    return amigos;
  }

  public Usuario GetAmigo (int ID) {
    for (int i = 0; i < amigos.Count; i++)
      if (amigos[i].ID == ID) 
        return amigos[i];
    return null;
  }

  public void ExcluirAmigo (Usuario u) {
    amigos.Remove(u);
  }
  
  public override string ToString() {
    return $"{usuario.ToString()}";
  } 
}