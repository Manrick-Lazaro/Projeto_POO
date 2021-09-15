using System;
using System.Collections.Generic;

class NUsuario {
  private Usuario usuario;
  private List<Publicacao> publicacoes = new List<Publicacao>();
  private List<Mensagem> Mensagens = new List<Mensagem>();
  private List<Usuario> amigos = new List<Usuario>();
  
  public void SetUsuario (Usuario u) {
    usuario = u;
  }

  public void NovoPost (string a) {
    
    Random rnd = new Random ();
    
    novoNumero:
    
    int IDAletorio = rnd.Next(0, 10000);
    
    for (int i = 0; i < control; i++) {
      if (IDAletorio == publicacoes[i].GetId()) {
        goto novoNumero;
      }
    }

    Publicacao postagem = new Publicacao(a, IDAletorio);

    publicacoes[control] = postagem;
    control++;
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

  public void AtualizarPostagem (Publicacao x) {
    Publicacao atualizacao = Listar(x.ID);
    if (atualizacao == null) 
      return;
    atualizacao.EditarPostagem(x.Postagem);
  }

  public void ExcluirPostagem (Publicacao p) {
    if (p != null) { publicacoes.Remove(p); }
  }
  
  public Usuario GetUsuario () {
    return usuario;
  }

  public void AddAmigo (string nome, int id) {
    Usuario a = new Usuario(nome, id);
    amigos.Add(a);
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

  public int IDUsuario () {
    return usuario.ID;
  }
  
  public override string ToString() {
    return $"{usuario.ToString()}";
  } 
}