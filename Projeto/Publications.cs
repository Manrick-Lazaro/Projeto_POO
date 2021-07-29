using System;

class Publications {
  private static int control = 0;
  private string post;
  private int ID;

  public Publications (string post, int id) {
    this.post = post;
    this.ID = id;
  }
  public Publications (string post) {
    this.post = post;
  }

  // set
  public void EditPost (string post) {
    this.post = post;
  }
  
  // get
  public string GetPost () {
    return post;
  }
  public int GetId() {
    return ID;
  }

  public override string ToString () {
    return $"{post}";
  }
}