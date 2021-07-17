using System;

class Publications {
  private string post;
  private int like;
  private string[] coment;
  private int control;

  public Publications (string post) {
    this.post = post;
  }

  // set
  public void SetPost (string post) {
    this.post = post;
  }
  public void SetLike (bool like) {
    if (like == true) {
      this.like++;
    }
  }
  public void SetComent (string coment) {
    if (control == coment.Length) {
      Array.Resize(coment, 2 * coment.Length);
    }
    this.coment[control] = coment;
    control++;
  }
  public void SetHome (Home home) {
    this.home = home;
  }

  // get
  public string GetPost () {
    return post;
  }
  public int GetLike () {
    return like;
  }
  public string[] GetComent () {
    string[] r = new string[control];
    Array.Copy(coment, r, control);
    return r;
  }
}