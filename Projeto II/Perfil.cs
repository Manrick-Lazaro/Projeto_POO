using System;

class Perfil { 
  
  public string Nome { get; set; }
  public string Email { get; set; }
  public string Telefone { get; set; }
  public string Cidade { get; set; }
  public DateTime Data { get; set; }

  public override string ToString () {
    return $"nome - {Nome}\nemail - {Email}\ntelefone - {Telefone}\ncidade - {Cidade}\ndata de aniversario - {Data.ToString("d")}";
  }
}