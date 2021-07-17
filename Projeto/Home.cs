using System;

class Home {
  private Publications[] posts = new Publications [10];
  private int control;

  public void NewPost (Publications p) {
    if (control == posts.Length) {
      Array.Resize(posts, 2 * posts.Length);
    }
    posts[control] = p;
    control++;
  }

  public Publications[] GetPublications () {
    Publications[] r = new Publications[control];
    Array.Copy(post, r, control);
    return r;
  }
}