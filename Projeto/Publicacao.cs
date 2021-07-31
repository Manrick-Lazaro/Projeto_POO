using System;

class Publications {
  private static int controleComent = 0;
  private string post;
  private int ID;
  private string[] comentarios = new string[10];
  private int curtidas = 0; 

  public Publications (string post, int id) {
    this.post = post;
    this.ID = id;
  }
  public Publications (string post) {
    this.post = post;
  }

  // set
  public void EditPost (string post) {
    this.post = post;
  }
  public void Comentar (string c) {
    if (controleComent == comentarios.Length - 1) {
      Array.Resize(ref comentarios, 2 * comentarios.Length);
    }
    comentarios [controleComent] = c;
    controleComent += 1;
  }
  public void Curtir (bool x) {
    if (x == true) {
      curtidas++;
    }
  }
  
  // get
  public string GetPost () {
    return post;
  }
  public string[] GetComentarios () {
    string[] x = new string[controleComent];
    Array.Copy(comentarios, x, controleComent);
    return x;
  }
  public string GetCurtidas () {
    return curtidas.ToString();
  }
  public int GetId() {
    return ID;
  }

  public override string ToString () {
    return $"{post}";
  }
}