using System;

class Publications {
  private static int control = 0;
  private string post;

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

  public override string ToString () {
    return $"{post}";
  }
}