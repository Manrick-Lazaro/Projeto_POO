using System;

class Home {
  private Publications[] posts = new Publications [10];
  private Friends[] friends = new Friends [10];
  private static int controlPublications = 0;
  private static int controlFriends = 0;

  public void NewPost (Publications p) {
    if (controlPublications == posts.Length - 1) {
      Array.Resize(ref posts, 2 * posts.Length);
    }
    posts [controlPublications] = p;
    controlPublications += 1;
  }

  public void AddFriends (Friends friend) {
    if (controlFriends == friends.Length - 1) {
      Array.Resize(ref friends, 2 * friends.Length);
    }
    friends [controlFriends] = friend;
    controlFriends += 1;
    bool x = true;
    Profile.AddFriends(x);
  }

  public Publications[] GetPublications () {
    Publications[] r = new Publications[controlPublications];
    Array.Copy(posts, r, controlPublications);
    return r;
  }

  public Friends[] GetFriends () {
    Friends[] r = new Friends[controlFriends];
    Array.Copy(friends, r, controlFriends);
    return r;
  } 


}