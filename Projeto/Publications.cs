using System;

class Publications {
  private static int control = 0;
  private string post;
  private int like;

  public Publications (string post) {
    this.post = post;
  }

  // set
  public void EditPost (string post) {
    this.post = post;
  }
  public void SetLike (bool like) {
    if (like == true) {
      this.like++;
    }
  }
  
  // get
  public string GetPost () {
    return post;
  }
  public int GetLike () {
    return like;
  }

  public override string ToString () {
    return $"{post}";
  }
}