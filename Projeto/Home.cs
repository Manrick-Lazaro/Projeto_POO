using System;

class Home {
  private Publications[] post = new Publications[10];
  private int control;


  public void SetNewPost (Publications post) {
    if (control == post.Length) {
      Array.Resize(post, 2 * post.Length);
    }
    this.post[control] = post;
    control++;
  }

  public Publications[] GetPublications () {
    Publications[] r = new Publications[control];
    Array.Copy(post, r, control);
    return r;
  }

}