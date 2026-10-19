# Cafeteria Dev

Aplicativo desktop em **C# / Windows Forms / .NET 10** para cadastrar vendas de cafés e consultar relatórios.

## Como executar

1. Instale o Visual Studio 2026 com o workload **Desenvolvimento para desktop com .NET** e o SDK do .NET 10.
2. Abra `CafeteriaDev.sln`.
3. Execute com **F5**, selecionando o projeto `CafeteriaDev` como projeto de inicialização.

Alternativamente, em PowerShell, a partir da raiz do repositório:

```powershell
dotnet run --project .\CafeteriaDev\CafeteriaDev.csproj
```

## Funcionalidades

- Splash com carregamento automático.
- Menu principal com navegação entre telas.
- Registro de pedido com café, quantidade e total calculado.
- Relatório com registros, faturamento e busca pelo nome do café.

**Observação:** os pedidos são mantidos somente em memória e se perdem ao encerrar o programa. O enunciado não exige banco de dados ou persistência.

## Equipe e versionamento

- Trabalho em grupo de quatro pessoas, com uma feature branch por tela.
- Ao menos três commits semânticos por tarefa/participante.
- Pull Requests de cada feature para `dev`, com code review do Tech Lead.
- Ao final, integração de `dev` para `main`.
- Nomes, RMs e URL do repositório público no arquivo `integrantes.txt`.

## Estrutura

- `CafeteriaDev/Core/`: modelos, catálogo, repositório em memória e estilo visual.
- `CafeteriaDev/Forms/`: quatro telas do aplicativo.
- `CafeteriaDev/Program.cs`: ponto de entrada e repositório compartilhado.
