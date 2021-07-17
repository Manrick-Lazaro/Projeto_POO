using System;

class Home {
  private static int control = 0;
  private Publications[] posts = new Publications [control+1];


  public void NewPost (Publications p) {
    posts[control] = p;
    control++;
  }

  public Publications[] GetPublications () {
    Publications[] r = new Publications[control];
    Array.Copy(posts, r, control);
    return r;
  }
}