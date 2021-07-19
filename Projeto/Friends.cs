using System;

class Friends {
  private Profile friend;

  public Friends (Profile friend) {
    this.friend = friend;
  }

  public override string ToString () {
    return $"name - {friend}";
  }
}