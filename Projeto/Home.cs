using System;

class Home {
  private Publications[] posts = new Publications [10];
  private static int control = 0;

  public void NewPost (Publications p) {
    if (control == posts.Length - 1) {
      Array.Resize(ref posts, 2 * posts.Length);
    }
    posts [control] = p;
    control += 1;
  }

  public Publications[] GetPublications () {
    Publications[] r = new Publications[control];
    Array.Copy(posts, r, control);
    return r;
  }
}