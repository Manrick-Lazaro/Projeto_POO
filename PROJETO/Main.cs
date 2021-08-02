using System;

class MainClass {
  private static NUsuario u1 = new NUsuario();
  private static NPerfil p1 = new NPerfil();

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
    Console.WriteLine("0 - Finalizar programa");
    Console.Write("Escolha uma opcao: ");
    int opcaoMenu = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return opcaoMenu;
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
          case 2: p1.EMail(); break;
          case 3: p1.Tel(); break;
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

  public static void CriarConta () {
    Console.WriteLine("-------------CRIANDO UMA NOVA CONTA-------------");
    Console.Write("Nome de usuario: ");
    string nome = Console.ReadLine();
    Console.Write("Seu ID: ");
    string ID = Console.ReadLine();

    Usuario usr = new Usuario(nome, ID);
    Perfil perfil1 = new Perfil (usr);

    u1.SetUsuario(usr);
    p1.SetPerfil(perfil1);
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
    
    u1.NovoPost(postagem);
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
}