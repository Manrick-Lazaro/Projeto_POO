using System;

class Publications {
  private string post;
  private int like;
  private string[] coment;

  public Publications (string post) {
    this.post = post;
  }

  public void SetPost (string post) {
    this.post = post;
  }
}