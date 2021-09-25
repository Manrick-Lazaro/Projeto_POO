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
    StreamReader usu = new StreamReader("./usuario.xml", Encoding.Default);
    XmlSerializer xml = new XmlSerializer (typeof(List<Usuario>));
    bancoUsuarios = (List<Usuario>)xml.Deserialize(usu);
    usu.Close();
  }
  public void SalvarUsuarios() {
      StreamWriter x  = new StreamWriter ("./usuario.xml", false, Encoding.Default);
      XmlSerializer xml = new XmlSerializer(typeof(List<Usuario>));
      xml.Serialize(x, bancoUsuarios);
      x.Close();
  }

  public void AbrirPublicacoes () {
    StreamReader pub = new StreamReader("./publicacoes.xml", Encoding.Default);
    XmlSerializer xml = new XmlSerializer (typeof(List<Publicacao>));
    bancoPublicacoes = (List<Publicacao>)xml.Deserialize(pub);
    pub.Close();
  }
  public void SalvarPublicacoes() {
      StreamWriter y  = new StreamWriter ("./publicacoes.xml", false, Encoding.Default);
      XmlSerializer xml = new XmlSerializer(typeof(List<Publicacao>));
      xml.Serialize(y, bancoPublicacoes);
      y.Close();
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

  public void Curtir (int p) {
    Publicacao c = Listar(p);
    c.Curtir();
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