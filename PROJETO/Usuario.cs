using System;

class Usuario {
  private string user;
  private string ID;
  private Publicacao[] posts = new Publicacao[10];
  private Usuario[] amigos = new Usuario [10];
  private static int controlePublicacao = 0;
  private static int controleAmigos = 0;

  public Usuario (string user, string ID) {
    this.user = user;
    this.ID = ID;
  }

  public void NewPost (Publicacao p) {
    if (controlePublicacao == posts.Length - 1) {
      Array.Resize(ref posts, 2 * posts.Length);
    }
    posts [controlePublicacao] = p;
    controlePublicacao += 1;
  }

  public Publicacao[] GetPublications () {
    Publicacao[] r = new Publicacao[controlePublicacao];
    Array.Copy(posts, r, controlePublicacao);
    return r;
  }

  public void AddFriends (Usuario amigo) {
    if (controleAmigos == amigos.Length - 1) {
      Array.Resize(ref amigos, 2 * amigos.Length);
    }
    amigos[controleAmigos] = amigo;
    controleAmigos += 1;
  }

  public Usuario[] GetFriends () {
    Usuario[] r = new Usuario[controleAmigos];
    Array.Copy(amigos, r, controleAmigos);
    return r;
  } 

  public string GetID () {
    return ID;
  }

  public Publicacao Listar (int ID) {
    for (int i = 0; i < controlePublicacao; i++)
      if (posts[i].GetId() == ID) 
        return posts[i];
    return null;
  }

  public void Curtir (int id, int x) {
    Publicacao curtir = Listar(id);
    if (x == 1) {
      curtir.Curtir(true);
    }
  }

  public void Comentar (int x, string y) {
    Publicacao coment = Listar(x);
    coment.Comentar(y);
  }

  public override string ToString () {
    return $"user - {user}\nID - {ID}";
  }
}