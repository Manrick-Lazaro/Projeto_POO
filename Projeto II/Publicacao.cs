using System;
using System.Collections.Generic;

public class Publicacao {
  private List<Comentario> comentarios = new List<Comentario>();
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
  public void Curtir () {
      curtidas++;
  }
  // get
  public List<Comentario> GetComentarios () {
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
    return "\n\n";    
  }
}