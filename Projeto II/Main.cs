using System;
using System.Collections.Generic;

class MainClass {
  private static NUsuario u1 = new NUsuario();
  private static NPerfil p1 = new NPerfil();
  private static Banco b1 = new Banco();

  public static void Main (string[] argc) {
    int opcao = 0;
    
    do {
      try {
        opcao = Menu();
        switch (opcao) {
          case 1: CriarConta(); break;
          case 2: DadosConta(); break;
          case 3: PerfilEditar(); break;
          case 4: PerfilAcessar(); break;
          case 5: FeedListar(); break;
          case 6: NovoPost(); break;
          case 7: EditarP(); break;
          case 8: ExcluirP(); break;
          case 9: ComentarP(); break;
          case 10: CurtirP(); break;
          case 11: AddAmigos(); break;
          case 12: ExcluirA(); break;
        }
      }
      catch (Exception erro) {
        Console.WriteLine(erro.Message);
        opcao = 100;
      }
    } while (opcao != 0);

    Console.WriteLine("Programa encerrado");
  }

  public static int Menu () {
    Console.WriteLine("-------------MENU DE ESCOLHAS-------------");
    Console.WriteLine();
    Console.WriteLine("1 - Criar uma conta");
    Console.WriteLine("2 - Acessar dados da conta");
    Console.WriteLine("3 - Editar perfil");
    Console.WriteLine("4 - Acessar dados do perfil");
    Console.WriteLine("5 - Visualizar postagens");
    Console.WriteLine("6 - Criar uma postagem");
    Console.WriteLine("7 - Editar uma postagem");
    Console.WriteLine("8 - Excluir uma postagem");
    Console.WriteLine("9 - Comentar uma postagem");
    Console.WriteLine("10 - Curtir uma postagem");
    Console.WriteLine("11 - Adicionar amigo");
    Console.WriteLine("12 - Excluir amigo");
    Console.WriteLine("0 - Finalizar programa");
    Console.Write("Escolha uma opcao: ");
    int opcaoMenu = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return opcaoMenu;
  }

  public static void CriarConta () {
    Console.WriteLine("-------------CRIANDO UMA NOVA CONTA-------------");

    // pegando as informações da nova conta do usuario
    Console.Write("Nome de usuario: ");
    string nome = Console.ReadLine();
    Console.Write("Senha: ");
    string senha = (Console.ReadLine());

    // criando um usuario
    Usuario usr = new Usuario(nome, senha);
    Perfil perfil1 = new Perfil();

    // criando um ID para esse usuario e adicionando-o no banco
    int max = 0;
    List<Usuario> lista = new List<Usuario>();
    lista = b1.ListarUsuarios();
    for (int i = 0; i < lista.Count; i++) {
      if (lista[i].ID > max) { max = lista[i].ID; }
    }
    usr.ID = max + 1;  
    
    b1.NovoUsuario(usr);
    u1.SetUsuario(usr); // usuario ja inicia com um nome, uma senha e um ID.
    p1.SetPerfil(perfil1);
  }

  public static void PerfilEditar () {    
    Console.WriteLine("-------------EDITANDO PERFIL-------------");
    Console.WriteLine();
    Console.WriteLine("1 - Nome");
    Console.WriteLine("2 - E-mail");
    Console.WriteLine("3 - Telefone");
    Console.WriteLine("4 - Data de nascimento");
    Console.WriteLine("5 - Cidade");
    Console.Write("Editar: ");
    int editarPerfil = int.Parse(Console.ReadLine());
    
    try {
        switch (editarPerfil) {
          case 1: p1.Nome(); break;
          case 2: p1.Email(); break;
          case 3: p1.Telefone(); break;
          case 4: p1.Data(); break;
          case 5: p1.Cidade(); break;
        }
      }
      catch (Exception erro) {
        Console.WriteLine(erro.Message);
        editarPerfil = 100;
      }
    
    Console.WriteLine();
  }

  public static void PerfilAcessar () {
    Console.WriteLine("-------------ACESSANDO PERFIL-------------");
    Console.WriteLine(p1);
  }
  
  public static void DadosConta () {
    Console.WriteLine(u1);
  }

  public static void FeedListar () {
    Console.WriteLine("-------------MOSTRANDO POSTAGENS-------------");
    Console.WriteLine();
    Publicacao[] pub  = u1.ListarPost() ;
    foreach (Publicacao p in pub)
      Console.WriteLine(p);
  }

  public static void NovoPost () {
    Console.WriteLine("-------------CRIANDO UMA NOVA POSTAGEM-------------");
    Console.Write("Digite: ");
    string postagem = Console.ReadLine();
    int idDaPostagem;
    
    // instanciando um objeto da clase publicação
    Publicacao p = new Publicacao(postagem);

    // criando um ID para essa publicação
    int max = 0;
    List<Publicacao> lista = new List<Publicacao>();
    lista = b1.ListarPublicacao();
    for (int i = 0; i < lista.Count; i++) {
      if (lista[i].ID > max) { max = lista[i].ID; }
    }

    // adicionando dados da publicação
    p.ID = max + 1;
    p.UsuarioEmail = p1.GEmail();
    p.IDUsuario = u1.IDUsuario();

    b1.setPub(p);
  }

  public static void EditarP () {
    Console.WriteLine("-------------ATUALIZANDO POSTAGEM-------------");
    Console.Write("Edit: ");
    string x = Console.ReadLine();
    Console.Write("ID: ");
    int y = int.Parse(Console.ReadLine());
    Publicacao z = new Publicacao (x,y);
    u1.AtualizarPost(z);
  }

  public static void ExcluirP () {
    Console.WriteLine("-------------EXCLUINDO POSTAGEM-------------");
    Console.Write("informe o ID: ");
    int y = int.Parse(Console.ReadLine());
    Publicacao x = u1.Listar(y);
    u1.ExcluirPost(x);
  }

  public static void ComentarP () {
    Console.WriteLine("-------------COMENTANDO-------------");
    Console.WriteLine();
    Console.Write("Digite o id da postagem: ");
    int id = int.Parse(Console.ReadLine());
    Console.WriteLine();
    Console.Write("Comente: ");
    string comentario = Console.ReadLine();

    u1.Comentar(id, comentario);
  }

  public static void CurtirP () {
    Console.WriteLine("-------------CURTINDO UMA POSTAGEM-------------");
    Console.Write("Digite uma ID:");
    int x = int.Parse(Console.ReadLine());
    Console.WriteLine("Voçe quer curtir essa publicação?");
    Console.WriteLine("1 - SIM");
    Console.WriteLine("2 - NÃO");
    int y = int.Parse(Console.ReadLine());

    u1.Curtir(x, y);
  }

  public static void AddAmigos () {
    Console.WriteLine("-------------ADICIONANDO UM AMIGO-------------");
    Console.Write("Digite um nome: ");
    string nome = Console.ReadLine();
    Console.Write("Digite uma ID: ");
    int id = int.Parse(Console.ReadLine());

    u1.AddAmigo(nome, id);
    p1.amigo(true);
  }

  public static void ExcluirA () {
    Console.WriteLine("-------------EXCLUINDO AMIGO-------------");
    Console.Write("informe o ID: ");
    int ID_User_Del = int.Parse(Console.ReadLine());
    Usuario user_del = u1.ListarAmigo(ID_User_Del);
    u1.ExcluirAmigo(user_del);
    p1.amigoEX(true);
  }
}