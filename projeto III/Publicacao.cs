using System;
using System.Collections.Generic;

public class Publicacao {
  private List<Comentario> comentarios = new List<Comentario>();
  private List<Curtida> curtidas = new List<Curtida>();
  private int id;
  private int idUsuario;
  private int x;
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
  public List<Comentario> GetComentarios {
    get { return comentarios; }
  }
  public List<Curtida> Curtidas {
    get {return curtidas;}
  }
  
  // construtor
  public Publicacao (string postagem) {
    this.Postagem = postagem;
  }
  public Publicacao () { }

  // set
  public void EditarPostagem (string postagem) {
    this.Postagem = postagem;
  }
  public void Comentar (Comentario comentario) {
    comentarios.Add(comentario);
  }
  public void ExcluirComentario (Comentario c) {
    comentarios.Remove(c);
  }
  public void SetCurtida (Curtida c) {
    curtidas.Add(c);
  }

  public override string ToString () {
    Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - -");
    Console.WriteLine($"USUÁRIO: {usuarioEmail}");
    Console.WriteLine("______________________________________________________");
    Console.WriteLine($"PUBLICAÇÃO: {Postagem}");
    Console.WriteLine("______________________________________________________");
    Console.WriteLine($" Curtidas - {curtidas.Count}     Comentários - {comentarios.Count}     ID - {id}\n");
    Console.WriteLine("               -----comentários-----");
    foreach(Comentario c in comentarios){
      Console.WriteLine(c);
    }
    Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - -");
    return "\n";    
  }
}