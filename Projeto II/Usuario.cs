using System;
using System.Collections.Generic;

class Usuario : IComparable<Usuario>{
  private string emailUsuario;
  private string senha;
  private int id;
  private Perfil perfil;
  private List<Publicacao> postagensUsuario = new List<Publicacao>();
  private List<Mensagem> Mensagens = new List<Mensagem>();
  private List<Usuario> amigos = new List<Usuario>();  

  public int ID { 
    get { return id; } 
    set { id = value; }
  }

  public Usuario (string user, string senha) {
    this.emailUsuario = user;
    this.senha = senha;
  }
  public Usuario () {}
// --------------------------------------------------------------- //
  public string GetEmailUser () {
    return emailUsuario;
  }
  public string GetSenhaUser () {
    return senha;
  }
  public Perfil GetPerfil () {
    return perfil;
  }
  public List<Publicacao> GetPublicacao () {
    return postagensUsuario;
  }
  public Publicacao Listar (int ID) {
    for (int i = 0; i < postagensUsuario.Count; i++)
      if (postagensUsuario[i].ID == ID) 
        return postagensUsuario[i];
    return null;
  }
  public List<Usuario> GetFriends () {
    return amigos;
  }
// --------------------------------------------------------------- //
  public void NovaPostagem (Publicacao p) {
    postagensUsuario.Add(p);
  }
  public void AtualizarPostagem (Publicacao p) {
    Publicacao atualizacao = Listar(p.ID);
    if (atualizacao == null) 
      return;
    atualizacao.EditarPostagem(p.Postagem);
  }
  public void ExcluirPostagem (Publicacao p) {
    if (p != null) { postagensUsuario.Remove(p); }
  }
  public void AddFriends (Usuario u) {
    amigos.Add(u);
  }
  public void AdicionarPerfil (Perfil p) {
    perfil = p;
  }
  public int CompareTo (Usuario obj) {
    return this.emailUsuario.CompareTo(obj.emailUsuario);
  }
  public override string ToString () {
    return $"{id} - {emailUsuario}";
  }
}