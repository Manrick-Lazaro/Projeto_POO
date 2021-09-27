using System;
using System.Collections.Generic;

public class Publicacao {
  private List<Comentario> comentarios = new List<Comentario>();
  private int curtidas;
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
  public List<Comentario> GetComentarios {
    get { return comentarios; }
  }
  public int Curtidas {
    get { return curtidas; }
    set { curtidas = curtidas + value; }
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