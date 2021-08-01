using System;

class NUsuario {
  private Usuario us;
  private Publicacao[] publicacoes = new Publicacao[10];
  private int control = 0;
  
  public void SetUsuario (Usuario u) {
    us = u;
  }

  public void NovoPost (string a, int id) {
    if (control == publicacoes.Length) {
      Array.Resize(ref publicacoes, 2 * publicacoes.Length);
    }
    Publicacao postagem = new Publicacao(a, id);
    publicacoes[control] = postagem;
    control++;
  }

  public Publicacao[] ListarPost () { 
    Publicacao[] postagem = new Publicacao [control];
    Array.Copy(publicacoes, postagem, control);
    return postagem;
  }

  public Publicacao Listar (int ID) {
    for (int i = 0; i < control; i++)
      if (publicacoes[i].GetId() == ID) return 
      publicacoes[i];
    return null;
  }

  public void AtualizarPost (Publicacao x) {
    Publicacao atualizacao = Listar(x.GetId());
    if (atualizacao == null) 
      return;
    atualizacao.EditPost(atualizacao.GetPost());
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
    for (int j = i; j<control; j++) {
      publicacoes[j] = publicacoes[j + 1];
    }
    control--;
  }

  public Usuario GetUsuario () {
    return us;
  }

  public override string ToString() {
    return $"{us.ToString()}";
  } 
}