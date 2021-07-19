using System;

class User {
  private string user;
  private string ID;

  public User (string user, string ID) {
    this.user = user;
    this.ID = ID;
  }

  public override string ToString () {
    return $"user - {user}\nID - {ID}";
  }
}