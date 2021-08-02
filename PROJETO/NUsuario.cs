using System;

class NUsuario {
  private Usuario us;
  private Publicacao[] publicacoes = new Publicacao[10];
  private int control = 0;
  
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
      curtir.Curtir();
    }
  }
  public Usuario GetUsuario () {
    return us;
  }

  public override string ToString() {
    return $"{us.ToString()}";
  } 
}