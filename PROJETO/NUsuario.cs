using System;

class NUsuario {
  private Usuario us;
  private Publicacao[] publicacoes = new Publicacao[10];
  private Usuario[] amigos = new Usuario[10];
  private int control = 0;
  private int controleAmigo = 0;
  
  public void SetUsuario (Usuario u) {
    us = u;
  }

  public void NovoPost (string a) {
    if (control == publicacoes.Length) {
      Array.Resize(ref publicacoes, 2 * publicacoes.Length);
    }
    Random rnd = new Random ();
    
    novoNumero:
    
    int IDAletorio = rnd.Next(0, 10000);
    
    for (int i = 0; i < control; i++) {
      if (IDAletorio == publicacoes[i].GetId()) {
        goto novoNumero;
      }
    }

    Publicacao postagem = new Publicacao(a, IDAletorio);

    publicacoes[control] = postagem;
    control++;
  }

  public Publicacao[] ListarPost () { 
    Publicacao[] postagens = new Publicacao [control];
    Array.Copy(publicacoes, postagens, control);
    return postagens;
  }

  public Publicacao Listar (int ID) {
    for (int i = 0; i < control; i++)
      if (publicacoes[i].GetId() == ID) 
        return publicacoes[i];
    return null;
  }

  public void AtualizarPost (Publicacao x) {
    Publicacao atualizacao = Listar(x.GetId());
    if (atualizacao == null) 
      return;
    atualizacao.EditPost(x.GetPost());
  }

  private int Indice (Publicacao pub) {
    for (int i = 0; i < control; i++){
      if (publicacoes[i] == pub) 
        return i;
    }
    return -1;
  }

  public void ExcluirPost (Publicacao p) {
    int i = Indice(p);
    if (i == -1) return;
    for (int j = i; j<control-1; j++) {
      publicacoes[j] = publicacoes[j + 1];
    }
    control--;
  }

  public void Comentar (int x, string y) {
    Publicacao coment = Listar(x);
    coment.Comentar(y);
  }

  public void Curtir (int id, int x) {
    Publicacao curtir = Listar(id);
    if (x == 1) {
      curtir.Curtir(true);
    }
  }
  public Usuario GetUsuario () {
    return us;
  }

  public void AddAmigo (string nome, int id) {
    if (controleAmigo == amigos.Length) {
      Array.Resize(ref amigos, 2 * amigos.Length);
    }
    
    Usuario a = new Usuario(nome, id);

    amigos[controleAmigo] = a;

    controleAmigo++;
  }

  public Usuario[] ListarAmigos () { 
    Usuario[] amigo = new Usuario [controleAmigo];
    Array.Copy(amigos, amigo, controleAmigo);
    return amigo;
  }

  public Usuario ListarAmigo (int ID) {
    for (int i = 0; i < controleAmigo; i++)
      if (amigos[i].GetID() == ID) 
        return amigos[i];
    return null;
  }

  private int IndiceAmigo (Usuario u) {
    for (int i = 0; i < controleAmigo; i++){
      if (amigos[i] == u) 
        return i;
    }
    return -1;
  }

  public void ExcluirAmigo (Usuario u) {
    int i = IndiceAmigo(u);
    if (i == -1) return;
    for (int j = i; j<controleAmigo-1; j++) {
      amigos[j] = amigos[j + 1];
    }
    controleAmigo--;
  }

  public override string ToString() {
    return $"{us.ToString()}";
  } 
}