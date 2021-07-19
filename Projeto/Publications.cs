using System;

class Publications {
  private static int control = 0;
  private string post;
  private int like;
  private string[] coment = new string [control+1];
  

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
  public void SetComent (string coment) {
    this.coment[control] = coment;
    control++;
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

  public override string ToString () {
    return $"{post}";
  }
}