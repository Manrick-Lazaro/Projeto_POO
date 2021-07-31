using System;

class User {
  private string user;
  private string ID;
  private Publicacao[] posts = new Publicacao [10];
  private User[] Amigos = new User [10];
  private static int controlePublicacao = 0;
  private static int controleAmigos = 0;

  public User (string user, string ID) {
    this.user = user;
    this.ID = ID;
  }

  // SET
  public void NewPost (Publications p) {
    if (controlePublicacao == posts.Length - 1) {
      Array.Resize(ref posts, 2 * posts.Length);
    }
    posts [controlePublicacao] = p;
    controlePublicacao += 1;
  }

  public void AddFriends (User amigo) {
    if (controleAmigos == amigos.Length - 1) {
      Array.Resize(ref amigos, 2 * amigos.Length);
    }
    amigos[controleAmigos] = amigo;
    controleAmigos += 1;
  }
  
  // GET
  public Publications[] GetPublications () {
    Publications[] r = new Publications[controlPublications];
    Array.Copy(posts, r, controlPublications);
    return r;
  }

  public Friends[] GetFriends () {
    Friends[] r = new Friends[controlFriends];
    Array.Copy(friends, r, controlFriends);
    return r;
  } 

  public override string ToString () {
    return $"user - {user}\nID - {ID}";
  }
}