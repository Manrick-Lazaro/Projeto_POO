using System;

class Profile {
  private User u;
  private string name;
  private string email;
  private string telephone;
  private string city;
  private DateTime date;
  private int followers;
  private static int follows;

  public Profile (User u) {
    this.u = u;
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
  public void SetDate (string date) {
    this.date = DateTime.Parse(date);
  }
  public void SetCity (string city) {
    this.city = city;
  }

  // Get Profile Data
  public string GetName () {
    return name;
  }
  public string GetEmail () {
    return email;
  }
  public string GetTelephone () {
    return telephone;
  }
  public DateTime GetDate () {
    return date;
  }
  public string GetCity () {
    return city;
  }
  public int GetFollows () {
    return follows;
  }
  

  public override string ToString () {
    return $"nome - {name}\nemail - {email}\nseguidores - {followers}\ntelefone - {telephone}\ncidade - {city}\ndata de aniversario - {date.ToString("d")}";
  }
}