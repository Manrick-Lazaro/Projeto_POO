using System;

class Perfil {
  private Usuario u;
  private string name;
  private string email;
  private string telephone;
  private string city;
  private DateTime date;
  private int amigos;

  public Perfil (Usuario u) {
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
  public void SetAmigo (bool x) {
    if (x == true) {
      amigos++;
    }
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
  public int GetAmigos () {
    return follows;
  }
  

  public override string ToString () {
    return $"nome - {name}\nemail - {email}\namigos - {amigos}\ntelefone - {telephone}\ncidade - {city}\ndata de aniversario - {date.ToString("d")}";
  }
}