using PBL4.Domain.Administrador;
using PBL4.Domain.Administrador.Enums;
using PBL4.Domain.Cliente;
using PBL4.Domain.Funcionario;
using PBL4.Domain.Funcionario.Enums;
using PBL4.Domain.Pessoa;
using PBL4.Enums;
using System;

List<Pessoa> pessoas = new List<Pessoa>();
Menu();
void Menu()
{
    MostrarOpcoesMenu();

    Opcao opcao = (Opcao)int.Parse(Console.ReadLine());

    switch (opcao)
    {
        case Opcao.CadastrarPessoa:
            MenuCadastro();
            break;
        case Opcao.ListarPessoas:
            ListarPessoas();
            break;
        case Opcao.BuscarPessoasPorTipo:
            MenuBuscarPessoasPorTipo();
            break;
        case Opcao.Sair:
            break;
        default:
            break;
    }
}
void MostrarOpcoesMenu()
{
    Console.WriteLine("Selecione uma das opções abaixo:");
    Console.WriteLine("1 - Cadastrar pessoa");
    Console.WriteLine("2 - Listar pessoas");
    Console.WriteLine("3 - Buscar pessoas por tipo");
    Console.WriteLine("4 - Sair");
}

#region Listar Pessoas Por Tipo
void MenuBuscarPessoasPorTipo()
{
    MostrarTiposPessoa();
    TipoPessoa tipoPessoa = (TipoPessoa)int.Parse(Console.ReadLine());

    switch (tipoPessoa)
    {
        case TipoPessoa.Cliente:
            ListarClientes();
            break;
        case TipoPessoa.Funcionario:
            ListarFuncionarios();
            break;
        case TipoPessoa.Administrador:
            ListarAdministradores();
            break;
    }

    Menu();
}

void ListarClientes()
{
    foreach (var pessoa in pessoas)
    {
        if (pessoa is Cliente cliente)
        {
            MostrarInformacoesPessoa(pessoa);
            MostrarInformacoesCliente(cliente);
        }
    }
}

void ListarFuncionarios()
{
    foreach (var pessoa in pessoas)
    {
        if (pessoa is Funcionario funcionario)
        {
            MostrarInformacoesPessoa(pessoa);
            MostrarInformacoesFuncionario(funcionario);
        }
    }
}

void ListarAdministradores()
{
    foreach (var pessoa in pessoas)
    {
        if (pessoa is Administrador administrador)
        {
            MostrarInformacoesPessoa(pessoa);
            MostrarInformacoesAdministrador(administrador);
        }
    }
}
#endregion

#region Listar Pessoas
void MostrarInformacoesPessoa(Pessoa pessoa)
{
    Console.WriteLine("--------------------------------");
    Console.WriteLine($"Nome: {pessoa.Nome}");
    Console.WriteLine($"Cpf:  {pessoa.Cpf}");
    Console.WriteLine($"Email: {pessoa.Email} ");
    Console.WriteLine($"Celular: {pessoa.Celular} ");
    Console.WriteLine($"Data Nascimento: {pessoa.DataNascimento} ");
    Console.WriteLine($"Idade: {pessoa.CalcularIdade()}");
}

void MostrarInformacoesCliente(Cliente cliente)
{
    Console.WriteLine($"Apelido: {cliente.Apelido}");
    Console.WriteLine($"Renda mensal: R${cliente.RendaMensal}");
    Console.WriteLine($"Cliente Novo: {(cliente.Novo ? "Sim" : "Não")}");
}

void MostrarInformacoesFuncionario(Funcionario funcionario)
{
    Console.WriteLine($"Setor: {((int)funcionario.Setor == 1 ? "Administrativo" : "Financeiro")}");
    Console.WriteLine($"Data admissão: {funcionario.DataAdmissao}");
    Console.WriteLine($"Primeiro emprego: {(funcionario.PrimeiroEmprego ? "Sim." : "Não.")}");
    Console.WriteLine($"Anos na empresa: {funcionario.CalcularAnosNaEmpresa()}");
}

void MostrarInformacoesAdministrador(Administrador administrador)
{
    Console.WriteLine($"Setor: {((int)administrador.Setor == 1 ? "Administrativo" : "Financeiro")}");
    Console.WriteLine($"Data Nivel: {administrador.Nivel}");
    Console.WriteLine($"Data admissão: {administrador.DataAdmissao}");
    Console.WriteLine($"Anos na empresa: {administrador.CalcularAnosNaEmpresa()}");
}

void ListarPessoas()
{
    foreach (var pessoa in pessoas)
    {
        MostrarInformacoesPessoa(pessoa);
        if (pessoa is Cliente cliente)
            MostrarInformacoesCliente(cliente);
        else if (pessoa is Funcionario funcionario)
            MostrarInformacoesFuncionario(funcionario);
        else if (pessoa is Administrador administrador)
            MostrarInformacoesAdministrador(administrador);
    }
    Menu();
}
#endregion

#region Cadastro
void MostrarTiposPessoa()
{
    Console.WriteLine("--------------------------------");
    Console.WriteLine("Selecione uma das opções abaixo:");
    Console.WriteLine("1 - Cadastrar Cliente");
    Console.WriteLine("2 - Cadastrar Funcionário");
    Console.WriteLine("3 - Cadastrar Administrador");
    Console.WriteLine("--------------------------------");
}

void MenuCadastro()
{
    MostrarTiposPessoa();
    TipoPessoa tipoPessoa = (TipoPessoa)int.Parse(Console.ReadLine());

    Pessoa pessoa = new();
    CadastrarPessoa(pessoa);

    switch (tipoPessoa)
    {
        case TipoPessoa.Cliente:
            Cliente cliente = new(pessoa);
            CompletarCadastroCliente(cliente);
            pessoas.Add(cliente);
            break;
        case TipoPessoa.Funcionario:
            Funcionario funcionario = new(pessoa);
            CompletarCadastroFuncionario(funcionario);
            pessoas.Add(funcionario);
            break;
        case TipoPessoa.Administrador:
            Administrador administrador = new(pessoa);
            CompletarCadastroAdministrador(administrador);
            pessoas.Add(administrador);
            break;
    }
    Menu();
}

void CadastrarPessoa(Pessoa pessoa)
{
    Console.WriteLine("Informe o nome: ");
    pessoa.Nome = Console.ReadLine();
    Console.WriteLine("Informe o cpf: ");
    pessoa.Cpf = Console.ReadLine();
    Console.WriteLine("Informe o email: ");
    pessoa.Email = Console.ReadLine();
    Console.WriteLine("Informe o celular: ");
    pessoa.Celular = Console.ReadLine();
    Console.WriteLine("Informe a data de nascimento (formato dd/mm/aaaa): ");
    pessoa.DataNascimento = Convert.ToDateTime(Console.ReadLine());
}

void CompletarCadastroCliente(Cliente cliente)
{
    Console.WriteLine("Informe o apelido: ");
    cliente.Apelido = Console.ReadLine();
    Console.WriteLine("Informe a renda mensal (somente números): ");
    cliente.RendaMensal = Convert.ToDecimal(Console.ReadLine());
    Console.WriteLine("Informe se é um cliente novo: s/N");
    cliente.Novo = Console.ReadLine() == "s";
}

void CompletarCadastroFuncionario(Funcionario funcionario)
{
    Console.WriteLine("Informe o setor (1 - Administrativo, 2 - Financeiro): ");
    funcionario.Setor = (Setor)int.Parse(Console.ReadLine());
    Console.WriteLine("Informe a data de admissão (formato dd/mm/aaaa): ");
    funcionario.DataAdmissao = Convert.ToDateTime(Console.ReadLine());
    Console.WriteLine("Informe se é o primeiro emprego: s/N");
    funcionario.PrimeiroEmprego = Console.ReadLine() == "s";
}

void CompletarCadastroAdministrador(Administrador administrador)
{
    Console.WriteLine("Informe o Setor (1 - Administrativo, 2 - Financeiro): ");
    administrador.Setor = (Setor)int.Parse(Console.ReadLine());
    Console.WriteLine("Informe o nível do gestor (1, 2, 3): ");
    administrador.Nivel = (NivelGestor)int.Parse(Console.ReadLine());
    Console.WriteLine("Informe a data de admissão (formato dd/mm/aaaa): ");
    administrador.DataAdmissao = Convert.ToDateTime(Console.ReadLine());
}
#endregion