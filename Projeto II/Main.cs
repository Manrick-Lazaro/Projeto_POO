using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;


class MainClass {
  private static NUsuario u1 = new NUsuario();
  private static NPerfil p1 = new NPerfil();
  private static Banco b1 = new Banco();
  private static Usuario usuarioLogin = null;

  public static void Main (string[] argc) {
    Thread.CurrentThread.CurrentCulture = new CultureInfo ("pt-BR");
    int opcao = 0;
    
    do {
      try {
        if (usuarioLogin == null) {
          opcao = MenuUsuarioNaoLogado();  
          switch (opcao) {  
            case 1: CriarConta(); break;
            case 2: Login(); break;
          } 
        }
        if (usuarioLogin != null) {
          opcao = MenuUsuarioLogado();
          switch (opcao) {
            case 2: DadosConta(); break;
            case 3: PerfilEditar(); break;
            case 4: PerfilAcessar(); break;
            case 5: PaginaInicial(); break;
            case 6: NovoPost(); break;
            case 7: EditarP(); break;
            case 8: ExcluirP(); break;
            case 9: ComentarP(); break;
            case 10: CurtirP(); break;
            case 11: AddAmigos(); break;
            case 12: ExcluirA(); break;
            case 50: Sair(); break;
          }
        }
      }
      catch (Exception erro) {
        Console.WriteLine(erro.Message);
        opcao = 100;
      }
    } while (opcao != 0);

    Console.WriteLine("Programa encerrado");
  }

  public static int MenuUsuarioLogado () {
    Console.WriteLine("-------------MENU-------------");
    Console.WriteLine();
    Console.WriteLine("2  - Conta");
    Console.WriteLine("3  - Editar perfil");
    Console.WriteLine("4  - Perfil");
    Console.WriteLine("5  - Página inicial");
    Console.WriteLine("6  - Criar uma publicação");
    Console.WriteLine("7  - Editar publicação");
    Console.WriteLine("8  - Excluir uma publicação");
    Console.WriteLine("9  - Comentar uma publicação");
    Console.WriteLine("10 - Curtir uma publicação");
    Console.WriteLine("11 - Adicionar amigo");
    Console.WriteLine("12 - Excluir amigo");
    Console.WriteLine("50 - Sair");
    Console.WriteLine("0  - Finalizar programa");
    Console.Write("Escolha uma opcao: ");
    int opcaoMenu = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return opcaoMenu;
  }

  public static int MenuUsuarioNaoLogado () {
    Console.WriteLine("-------------MENU-------------");
    Console.WriteLine();
    Console.WriteLine("1 - Criar uma conta");
    Console.WriteLine("2 - Entrar");
    Console.WriteLine("0 - Finalizar programa");
    Console.Write("Escolha uma opcao: ");
    int opcaoMenu = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return opcaoMenu;
  }
// -------------------------------------------------------------- //
  public static void CriarConta () {
    Console.WriteLine("-------------CRIANDO UMA NOVA CONTA-------------");

    // pegando as informações da nova conta do usuario
    Console.Write("E-mail de usuario: ");
    string email = Console.ReadLine();
    Console.Write("Senha: ");
    string senha = (Console.ReadLine());

    
    Usuario usr = new Usuario(email, senha); // criando um usuario
    Perfil perfil1 = new Perfil(); // criando um perfil para o usuario
    b1.NovoUsuario(usr); // adiciona usuario criado no banco
    
    u1.SetUsuario(usr); 
    p1.SetPerfil(perfil1);
    p1.Email(email); // adiciona o email de usuario ao perfil
    usr.AdicionarPerfil(perfil1); // adiciona perfil ao usuario
  }
  public static void Login () {
    Console.Write("E-mail: ");
    string emailLogin = Console.ReadLine();
    Console.Write("Senha: ");
    string senhaLogin = Console.ReadLine();

    int x = 0;

    List<Usuario> listaDeVerificação = b1.ListarUsuarios();

    for (int i = 0; i < listaDeVerificação.Count; i++) {
      if (listaDeVerificação[i].GetEmailUser() == emailLogin && listaDeVerificação[i].GetSenhaUser() == senhaLogin) {
        x = 1;    
        break;
      }
    }

    if (x == 1) {
      Console.WriteLine("Login feito com sucesso\n\n");
      usuarioLogin = listaDeVerificação[i];
      u1.SetUsuario(usuarioLogin);
    }
    else{
      Console.WriteLine("Email ou senha incorreta!");
      Console.WriteLine("Tente novamente");
    }
  }

// -------------------------------------------------------------- //

  public static void PerfilEditar () {    
    Console.WriteLine("-------------EDITANDO PERFIL-------------");
    Console.WriteLine();
    Console.WriteLine("1 - Nome");
    Console.WriteLine("2 - E-mail");
    Console.WriteLine("3 - Telefone");
    Console.WriteLine("4 - Data de nascimento (dd/mm/aaaa)");
    Console.WriteLine("5 - Cidade");
    Console.Write("Escolha uma opcao: ");
    int editarPerfil = int.Parse(Console.ReadLine());
    
    Console.Write("Edit: ");
    string edit = Console.ReadLine();
     
    try {
        switch (editarPerfil) {
          case 1: p1.Nome(edit); break;
          case 2: p1.Email(edit); break;
          case 3: p1.Telefone(edit); break;
          case 4: p1.Data(edit); break;
          case 5: p1.Cidade(edit); break;
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
    Console.WriteLine("-------------ACESSANDO DADOS DO USUARIO-------------");
    Console.WriteLine(u1);
  }

  public static void PaginaInicial () {
    Console.WriteLine("-------------PÁGINA INICIAL-------------");
    Console.WriteLine();
    List<Publicacao> pub = new List<Publicacao>();    
    pub = b1.ListarPublicacao();
    foreach (Publicacao p in pub)
      Console.WriteLine(p);
  }

  public static void NovoPost () {
    Console.WriteLine("-------------CRIANDO UMA NOVA PUBLICAÇÃO-------------");
    Console.Write("Digite: ");
    string postagem = Console.ReadLine();
    
    // instanciando um objeto da clase publicação
    Publicacao p = new Publicacao(postagem);
    
    // adicionando dados da publicação
    p.UsuarioEmail = p1.GEmail();    
    p.IDUsuario = u1.IDUsuario();
    
    b1.setPub(p);
    u1.NovoPost(p);
  }

  public static void EditarP () {
    Console.WriteLine("-------------ATUALIZANDO PUBLICAÇÃO-------------");
    
    Console.Write("Edit: ");
    string x = Console.ReadLine();
    Console.Write("id: ");
    int y = int.Parse(Console.ReadLine());
    
    u1.AtualizarPostagem(x, y);
  }

  public static void ExcluirP () {
    Console.WriteLine("-------------EXCLUINDO PUBLICAÇÃO-------------");
    Console.Write("informe o ID: ");
    int y = int.Parse(Console.ReadLine());
    Publicacao x = u1.Listar(y);
    u1.ExcluirPostagem(x);
    b1.ExcluirPublicacao(x);
  }

  public static void ComentarP () {
    Console.WriteLine("-------------COMENTANDO-------------");
    Console.WriteLine();
    Console.Write("Digite o id da postagem: ");
    int id = int.Parse(Console.ReadLine());
    Console.WriteLine();
    Console.Write("Comente: ");
    string comentario = Console.ReadLine();

    //u1.Comentar(id, comentario);
  }

  public static void CurtirP () {
    Console.WriteLine("-------------CURTINDO UMA POSTAGEM-------------");
    Console.Write("Digite uma ID: ");
    int x = int.Parse(Console.ReadLine());
    b1.Curtir(x);
  }

  public static void AddAmigos () {
    Console.WriteLine("-------------ADICIONANDO UM AMIGO-------------");
    Console.Write("Digite uma ID: ");
    int id = int.Parse(Console.ReadLine());

    u1.AddAmigo(id);
  }

  public static void ExcluirA () {
    Console.WriteLine("-------------EXCLUINDO AMIGO-------------");
    Console.Write("informe o ID: ");
    int ID_User_Del = int.Parse(Console.ReadLine());
    Usuario user_del = u1.GetAmigo(ID_User_Del);
    u1.ExcluirAmigo(user_del);
  }

  public static void Sair () {
    usuarioLogin = null;
  }
}