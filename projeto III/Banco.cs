using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Text;
using System.IO;

/*
  o objetivo dessa classe é armazenar todas as publicações 
  que forem feitas na plataforma.
*/

class Banco {
  private List<Publicacao> bancoPublicacoes = new List<Publicacao>();
  private List<Usuario> bancoUsuarios = new List<Usuario>();


  public void AbrirUsuarios () {
    Arquivo<List<Usuario>> usuario = new Arquivo<List<Usuario>>();
    bancoUsuarios = usuario.Abrir("./usuarios.xml");
  }
  public void SalvarUsuarios() {
    Arquivo<List<Usuario>> usuario = new Arquivo<List<Usuario>>();
    usuario.Salvar("./usuarios.xml", bancoUsuarios);
  }

  public void AbrirPublicacoes () {
    Arquivo<List<Publicacao>> publicacao = new Arquivo<List<Publicacao>>();
    bancoPublicacoes = publicacao.Abrir("./publicacoes.xml");
  }
  public void SalvarPublicacoes() {
    Arquivo<List<Publicacao>> publicacao = new Arquivo<List<Publicacao>>();
    publicacao.Salvar("./publicacoes.xml", bancoPublicacoes);
  }
// ---------------------------------------------------------------------- //
  public void setPub (Publicacao p) {
    // criando um ID para essa publicação
    int max = 0;
    for (int i = 0; i < bancoPublicacoes.Count; i++) {
      if (bancoPublicacoes[i].ID > max) { max = bancoPublicacoes[i].ID; }
    }
    p.ID = max + 1; 
    bancoPublicacoes.Add(p);
  }

  public List<Publicacao> ListarPublicacao () {
    return bancoPublicacoes;
  } 

  public Publicacao GetPub (int ID) {
    for (int i = 0; i < bancoPublicacoes.Count; i++)
      if (bancoPublicacoes[i].ID == ID) 
        return bancoPublicacoes[i];
    return null;
  }

  public void ExcluirPublicacao (Publicacao p) {
    if (p != null) { bancoPublicacoes.Remove(p); }
  }

  public Publicacao Listar (int ID) {
    for (int i = 0; i < bancoPublicacoes.Count; i++)
      if (bancoPublicacoes[i].ID == ID) 
        return bancoPublicacoes[i];
    return null;
  }

  public void AtualizarPublicacao (Publicacao p) {
    for (int i = 0; i < bancoPublicacoes.Count; i++){
      if (p.ID == bancoPublicacoes[i].ID) {
        bancoPublicacoes[i] = p;
        break;
      }
    }
  }

  public void Curtir (int id, string email) {
    Curtida c = new Curtida();
    
    Publicacao p = Listar(id); 
    c.Mail = email;
    
    List<Curtida> curt = p.Curtidas;

    int jaTem = 0;

    for (int i = 0; i < curt.Count; i++){
      if (email == curt[i].Mail) {
        jaTem=1;
        break;
      }
    }
    if (jaTem == 0){
      p.SetCurtida(c);
    } 
  }
// ---------------------------------------------------------------------- //
  public void NovoUsuario (Usuario u) {
    // criando um ID para esse usuario e adicionando-o no banco
    int max = 0;
    for (int i = 0; i < bancoUsuarios.Count; i++) {
      if (bancoUsuarios[i].ID > max) { max = bancoUsuarios[i].ID; }
    }
    u.ID = max + 1;
    bancoUsuarios.Add(u);
  }

  public List<Usuario> ListarUsuarios () {
    return bancoUsuarios;
  } 

  public Usuario GetUsuario (int ID) {
    for (int i = 0; i < bancoUsuarios.Count; i++)
      if (bancoUsuarios[i].ID == ID) 
        return bancoUsuarios[i];
    return null;
  }

  public Usuario GetUsuario (string email) {
    for (int i = 0; i < bancoUsuarios.Count; i++)
      if (bancoUsuarios[i].GetEmailUser == email) 
        return bancoUsuarios[i];
    return null;
  }

  public void Login(string email, string senha, ref NUsuario u1, ref NPerfil p1, ref Usuario usuarioLogin) {
    int x = 0;
    int i;
    for (i = 0; i < bancoUsuarios.Count; i++) {
      if (bancoUsuarios[i].GetEmailUser == email && bancoUsuarios[i].GetSenhaUser == senha) {
        x = 1;    
        break;
      }
    }

    if (x == 1) {
      Console.WriteLine("Login feito com sucesso\n\n");
      usuarioLogin = bancoUsuarios[i];
      u1.SetUsuario(usuarioLogin);
      p1.SetPerfil(usuarioLogin.PerfilU);
    }
    else{
      Console.WriteLine("Email ou senha incorreta!");
      Console.WriteLine("Tente novamente");
    }
  }
  
} 