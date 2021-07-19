using System;

class Friends {
  private string name;

  public Friends (string name) {
    this.name = name;
  }

  public override string ToString () {
    return $"name - {name}";
  }
}