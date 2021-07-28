using System;

class NUsuario {
  private User us;
  
  public void SetUsuario (User u) {
    us = u;
  }
  public User GetUsuario () {
    return us;
  }
  public override string ToString() {
    return $"{us.ToString()}";
  } 
}