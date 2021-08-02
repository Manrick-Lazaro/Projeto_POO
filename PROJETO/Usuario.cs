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

  private int publicacaoIndice (Publicacao p) {
    for (int i = 0; i < controlePublicacao; i++){
      if (posts[i] == p) 
        return i;
  }

  public void ExcluirPost (Publicacao p) {
    int i = publicacaoIndice(p);
    if (i == -1) return;
    for (int j = i; j<controlePublicacao-1; j++) {
      posts[j] = posts[j + 1];
    }
    controlePublicacao--;
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

  private int amigoIndice (User u) {
    for (int i = 0; i < controleAmigos; i++){
      if (amigos[i] == u) 
        return i;
  }

  public void ExcluirAmigo (User u) {
    int i = amigoIndice(u);
    if (i == -1) return;
    for (int j = i; j<controleAmigos-1; j++) {
      amigos[j] = amigos[j + 1];
    }
    controleAmigos--;
  }

  public string GetID () {
    return ID;
  }

  public override string ToString () {
    return $"user - {user}\nID - {ID}";
  }
}