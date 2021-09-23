using System;
using System.Collections.Generic;

class Publicacao {
  private List<string> comentarios = new List<string>();
  private int curtidas = 0;
  private int id;
  private int idUsuario;
  private string usuarioEmail;

  public int ID { 
    get { return id; } 
    set { id = value; } 
  }
  
  public int IDUsuario { 
    get { return id; } 
    set { idUsuario = value; } 
  }
  public string UsuarioEmail {
    get { return usuarioEmail; }
    set { usuarioEmail = value; }
  }
  
  public string Postagem { get; set; }
  
  // construtor
  public Publicacao (string postagem) {
    this.Postagem = postagem;
  }

  // set
  public void EditarPostagem (string postagem) {
    this.Postagem = postagem;
  }
  public void Comentar (string comentario) {
    comentarios.Add(comentario);
  }
  public void Curtir () {
      curtidas++;
  }
  
  // get
  public List<string> GetComentarios () {
    return comentarios;
  }
  public string GetCurtidas () {
    return curtidas.ToString();
  }

  public override string ToString () {
    Console.WriteLine("------------------------------------------------------");
    Console.WriteLine($"{usuarioEmail}");
    Console.WriteLine("______________________________________________________");
    Console.WriteLine($"{Postagem}");
    Console.WriteLine("______________________________________________________");
    Console.WriteLine($" Curtidas - {curtidas}     Comentarios - {comentarios.Count}     ID - {id}");
    Console.WriteLine("------------------------------------------------------");
    Console.WriteLine($"\n\n");
    return "\n\n";    
  }
}