using System;

class Profile {
  private string name;
  private int password;
  private string email;
  private string telephone;
  private string city;
  private DateTime date;
  private int followers;

  public Profile (string name, int id) {
    this.name = name;
    this.password = password;
  }

  // Set Profile Data
  public void SetName (string name) {
    this.name = name;
  }
  public void SetEmail (string email) {
    this.email = email;
  }
  public void SetTelephone (string telephone) {
    this.telephone = telephone;
  }
  public void SetDate (DateTime date) {
    this.date = date;
  }
  public void SetCity (string city) {
    this.city = city;
  }
  public void ResetPassword (int password) {
    this.password = password;
  }

  // Get Profile Data
  public string GetName (string name) {
    return name;
  }
  public string GetEmail (string email) {
    return email;
  }
  public string GetTelephone (string telephone) {
    return telephone;
  }
  public DateTime GetDate (DateTime date) {
    return date;
  }
  public string GetCity (string city) {
    return city;
  }

  public override string ToString () {
    return $"nome-{name}\nemail-{email}\nfollowers-{followers}\ntelephone-{telephone}";
  }
}