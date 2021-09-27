using System;
using System.Collections.Generic;

public class Usuario : IComparable<Usuario>{
  private string emailUsuario;
  private string senha;
  private int id;
  private Perfil perfil;
  private List<Publicacao> postagensUsuario = new List<Publicacao>();
  private List<Mensagem> mensagens = new List<Mensagem>();
  private List<Usuario> amigos = new List<Usuario>();  

  // contrutor
  public Usuario (string user, string senha) {
    this.emailUsuario = user;
    this.senha = senha;
  }
  public Usuario () {}
// --------------------------------------------------------------- //
  public string GetEmailUser {
    get { return emailUsuario; }
    set { emailUsuario = value; }
  }
  public string GetSenhaUser {
    get { return senha; }
    set { senha = value; }
  }
  public int ID { 
    get { return id; } 
    set { id = value; }
  }
  public Perfil PerfilU {
    get { return perfil; }
    set { perfil = value; }
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
  public List<Usuario> GetFriends {
    get {return amigos;}
  }
  public List<Mensagem> GetMenagens {
    get {return mensagens;}
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
  public int CompareTo (Usuario obj) {
    return this.emailUsuario.CompareTo(obj.emailUsuario);
  }
  public void Mensagem (Mensagem m) {
    mensagens.Add(m);
  }
   public override string ToString () {
    return $"{id} - {emailUsuario}";
  }
}