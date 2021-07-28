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
    Console.WriteLine("");
    Console.WriteLine("________________________________");
    Console.WriteLine();
    Console.WriteLine("1 - Criar uma conta");
    Console.WriteLine("2 - Acessar dados da conta");
    Console.WriteLine("3 - Editar perfil");
    Console.WriteLine("4 - Acessar dados do perfil");
    Console.WriteLine("0 - Finalizar programa");
    Console.Write("Escolha uma opcao: ");
    int opcaoMenu = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return opcaoMenu;
  }

  public static void PerfilEditar () {
    Console.WriteLine("________________________________");
    Console.WriteLine();
    Console.WriteLine("Edição do perfil");
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
  
    Console.WriteLine(p1);
    
  }

  public static void CriarConta () {
    Console.WriteLine("Crie sua conta");
    Console.Write("Nome de usuario:");
    string nome = Console.ReadLine();
    Console.Write("Seu ID: ");
    string ID = Console.ReadLine();

    User usuario = new User(nome, ID);
    Profile perfil1 = new Profile (usuario);

    u1.SetUsuario(usuario);
    p1.SetPerfil(perfil1);
  }
  public static void DadosConta () {
    Console.WriteLine(u1);
  }

  
}