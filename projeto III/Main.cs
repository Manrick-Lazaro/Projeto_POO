using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;


public class MainClass {
  private static NUsuario u1 = new NUsuario();
  private static NPerfil p1 = new NPerfil();
  private static Banco b1 = new Banco();
  private static Usuario usuarioLogin = null;

  public static void Main (string[] argc) {
    Thread.CurrentThread.CurrentCulture = new CultureInfo ("pt-BR");
    int opcao = 0;
    
    try {
      b1.AbrirUsuarios();
      b1.AbrirPublicacoes();
    }
    catch (Exception erro) {
      Console.WriteLine(erro.Message);
    }

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
            case 10: ExcluirComentario(); break;
            case 11: CurtirP(); break;
            case 12: RetirarCurtida(); break;
            case 13: AddAmigos(); break;
            case 14: ExcluirA(); break;
            case 15: EnviarMensagem(); break;
            case 16: Mensagens(); break;
            case 17: Comentarios(); break;
            case 18: Amigos(); break;
            case 50: Sair(); break;
          }
        }
      }
      catch (Exception erro) {
        Console.WriteLine(erro.Message);
        opcao = 100;
      }
    } while (opcao != 0);

    try {
      b1.SalvarUsuarios();
      b1.SalvarPublicacoes();
    }
    catch (Exception erro) {
      Console.WriteLine(erro.Message);
    }

    Console.WriteLine("Programa encerrado");
  }

  public static int MenuUsuarioLogado () {
    Console.WriteLine("-------------MENU-------------");
    Console.WriteLine();
    Console.WriteLine("2  - Conta");
    Console.WriteLine("3  - Editar perfil");
    Console.WriteLine("4  - Perfil");
    Console.WriteLine("5  - P??gina inicial");
    Console.WriteLine("6  - Criar uma publica????o");
    Console.WriteLine("7  - Editar publica????o");
    Console.WriteLine("8  - Excluir uma publica????o");
    Console.WriteLine("9  - Comentar na publica????o");
    Console.WriteLine("10 - Retirar comentario da publica????o");
    Console.WriteLine("11 - Curtir uma publica????o");
    Console.WriteLine("12 - Retirar curtida da publica????o");
    Console.WriteLine("13 - Adicionar amigo");
    Console.WriteLine("14 - Excluir amigo");
    Console.WriteLine("15 - Enviar Mensagem");
    Console.WriteLine("16 - Mensagens");
    Console.WriteLine("17 - Comentatios");
    Console.WriteLine("18 - Amigos");
    Console.WriteLine("50 - Sair");
    Console.WriteLine("0  - Finalizar programa");
    Console.Write("Escolha uma opcao: ");
    int opcaoMenu = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return opcaoMenu;
  }

  public static int MenuUsuarioNaoLogado () {
    Console.WriteLine("-------------TELA DE LOGIN-------------");
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

    // pegando as informa????es da nova conta do usuario
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
    usr.PerfilU = perfil1; // adiciona perfil ao usuario
  }
  public static void Login () {
    Console.Write("E-mail: ");
    string emailLogin = Console.ReadLine();
    Console.Write("Senha: ");
    string senhaLogin = Console.ReadLine();

    b1.Login(emailLogin, senhaLogin, ref u1, ref p1, ref usuarioLogin);
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
    Console.WriteLine("-------------P??GINA INICIAL-------------");
    Console.WriteLine();
    List<Publicacao> pub = new List<Publicacao>();    
    pub = b1.ListarPublicacao();
    foreach (Publicacao p in pub)
      Console.WriteLine(p);
  }

  public static void NovoPost () {
    Console.WriteLine("-------------CRIANDO UMA NOVA PUBLICA????O-------------");
    Console.Write("Digite: ");
    string postagem = Console.ReadLine();
    
    // instanciando um objeto da clase publica????o
    Publicacao p = new Publicacao(postagem);
    
    // adicionando dados da publica????o
    p.UsuarioEmail = p1.GEmail();    
    p.IDUsuario = u1.IDUsuario();
    
    b1.setPub(p);
    u1.NovoPost(p);
  }

  public static void EditarP () {
    Console.WriteLine("-------------ATUALIZANDO PUBLICA????O-------------");
    
    Console.Write("Edit: ");
    string x = Console.ReadLine();
    Console.Write("id: ");
    int y = int.Parse(Console.ReadLine());
    
    u1.AtualizarPostagem(x, y);
  }

  public static void ExcluirP () {
    Console.WriteLine("-------------EXCLUINDO PUBLICA????O-------------");
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

    Publicacao p = b1.GetPub(id);
    Comentario comentario = new Comentario();

    if (p == null) {
      Console.WriteLine("Nenhuma publica????o com esse id encontrado.");
    }
    else{
      Console.Write("Comente: ");
      string c = Console.ReadLine();
      int idc = b1.IDComentario(p);

      comentario.Email = u1.GetEmail();
      comentario.Conteudo = c;
      comentario.ID = idc;

      p.Comentar(comentario);
    }
  }

  public static void CurtirP () {
    Console.WriteLine("-------------CURTINDO UMA POSTAGEM-------------");
    Console.Write("Digite uma ID: ");
    int x = int.Parse(Console.ReadLine());
    
    b1.Curtir(x, u1.GetEmail());
  }

  public static void AddAmigos () {
    Console.WriteLine("-------------ADICIONANDO UM AMIGO-------------");
    Console.Write("Digite o email: ");
    string email = Console.ReadLine();

    Usuario uu = new Usuario ();

    uu = b1.GetUsuarioMail(email);
  
    u1.AddAmigo(uu);
  }

  public static void ExcluirA () {
    Console.WriteLine("-------------EXCLUINDO AMIGO-------------");
    Console.Write("informe o email: ");
    string email_User_Del = Console.ReadLine();
    
    Usuario user_del = u1.GetAmigo(email_User_Del);
    u1.ExcluirAmigo(user_del);
  }

  public static void Sair () {
    usuarioLogin = null;
  }

  public static void EnviarMensagem () {
    Console.WriteLine("-------------ENVIANDO MENSAGEM-------------");
    Console.Write("Pesquisar: ");
    string emailEnviarMensagem = Console.ReadLine();

    Usuario usuario = b1.GetUsuarioMail(emailEnviarMensagem);
    Mensagem mensagem = new Mensagem();

    if (usuario == null) {
      Console.WriteLine("Nenhum usuario com esse email encontrado.");
    }
    else{
      Console.Write("Envie sua mensagem: ");
      string m = Console.ReadLine();
      
      mensagem.Conteudo = m;
      mensagem.Email = u1.GetEmail();
      mensagem.ID = u1.IDUsuario();

      usuario.Mensagem(mensagem);
    }
  }

  public static void Mensagens () {
    Console.WriteLine("-------------MENSAGENS RECEBIDAS-------------");
    
    List<Mensagem> m = u1.MensagensRecebidas;

    foreach(Mensagem mensagem in m) {
      Console.WriteLine(mensagem);
    }
  } 

  public static void Comentarios () {
    Console.WriteLine("-------------COMENTARIOS DA PUBLICA????O-------------");
    Console.WriteLine("ID da publica????o");
    Console.Write("digite: ");
    int id = int.Parse(Console.ReadLine());

    Publicacao p = b1.GetPub(id);
    List<Comentario> comentarios = p.GetComentarios;

    foreach(Comentario c in comentarios) {
      Console.WriteLine(c);
    }
  } 

  public static void ExcluirComentario(){
    Console.WriteLine("-------------EXCLUINDO COMENT??RIO-------------");
    Console.WriteLine("ID da publica????o");
    Console.WriteLine("digite: ");
    int id = int.Parse(Console.ReadLine());
  
    Console.WriteLine("ID do comentario");
    Console.WriteLine("digite: ");
    int idC = int.Parse(Console.ReadLine());

    b1.ExcluirComentario(id, u1.GetEmail(), idC);
  }

  public static void RetirarCurtida(){
    Console.WriteLine("-------------EXCLUINDO COMENT??RIO-------------");
    Console.WriteLine("ID da publica????o");
    Console.Write("digite: ");
    int id = int.Parse(Console.ReadLine());

    b1.RetirarLike(id, u1.GetEmail());
  }

  public static void Amigos(){
    Console.WriteLine("-------------Amigos-------------");
    Console.WriteLine();
    List<Usuario> amg = new List<Usuario>();    
    amg = u1.ListarAmigos();
    foreach (Usuario u in amg)
      Console.WriteLine(u);
  }
}