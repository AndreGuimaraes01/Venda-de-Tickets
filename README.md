# 🎟️ Venda de Tickets

Plataforma de venda de ingressos construída em **C# / .NET**, com foco em **concorrência, alta disponibilidade e boas práticas de DevOps**.

> 🚧 **Projeto em desenvolvimento.** Estou construindo do zero e documentando cada etapa do aprendizado.

## O problema

Vender ingressos parece simples, até que 10 mil pessoas tentam comprar os últimos 100 ingressos ao mesmo tempo. O sistema precisa garantir que:

- **Nenhum ingresso seja vendido duas vezes**, mesmo com várias compras simultâneas (*race condition*).
- **Ingressos reservados voltem ao estoque** se o pagamento não for concluído a tempo.
- **O sistema continue no ar** durante picos de acesso, como a abertura de vendas de um show.

Resolver esses três pontos é o objetivo central do projeto.

## Regras de negócio

- **Dois tipos de usuário:**
  - **Empresa**: cria e anuncia eventos.
  - **Cliente**: compra ingressos.
- Ao iniciar uma compra, o ingresso fica **reservado por 15 minutos** para o cliente. Se o pagamento não for feito nesse prazo, o ingresso volta a ficar disponível.
- Cada evento tem um **prazo limite de venda** (por exemplo, até 1 hora após o início).
- Quando o estoque chega a zero, **nenhuma nova venda é aceita**.

## Tecnologias

| Camada | Tecnologia | Status |
|---|---|---|
| API | C# / ASP.NET Core (.NET 10) | ✅ Em uso |
| Controle de versão | Git + GitHub | ✅ Em uso |
| Banco de dados | PostgreSQL | 🔜 Planejado |
| Cache | Redis | 🔜 Planejado |
| Containers | Docker / Docker Compose | 🔜 Planejado |
| CI/CD | GitHub Actions | 🔜 Planejado |
| Infraestrutura como código | Terraform | 🔜 Planejado |
| Monitoramento | Prometheus + Grafana | 🔜 Planejado |

## Roadmap

- [x] Estrutura inicial da API
- [ ] Modelo de dados: Evento *(em andamento)*
- [ ] Modelos de Usuário, Reserva e Pedido
- [ ] Endpoints de eventos e reservas
- [ ] Banco de dados PostgreSQL
- [ ] Controle de concorrência (sem venda duplicada) + teste que prova isso
- [ ] Expiração de reservas após 15 minutos
- [ ] Autenticação e autorização (Empresa x Cliente)
- [ ] Docker e Docker Compose
- [ ] Pipeline de CI/CD
- [ ] Várias instâncias da API atrás de um load balancer
- [ ] Teste de carga
- [ ] Monitoramento e alertas
- [ ] Deploy na nuvem

## Como rodar

Pré-requisito: [.NET SDK 10](https://dotnet.microsoft.com/download)

```bash
git clone https://github.com/AndreGuimaraes01/Venda-de-Tickets.git
cd Venda-de-Tickets
dotnet run --project src/Ingressos.Api
```

A API sobe em `http://localhost:5099`.

## Estrutura do projeto

```
Venda-de-Tickets/
└── src/
    └── Ingressos.Api/        # API (ASP.NET Core)
        ├── Controllers/      # endpoints
        ├── Models/           # entidades do domínio (Evento, ...)
        └── Program.cs        # ponto de entrada da aplicação
```

## Autor

**André Guimarães**, estudante de Ciência da Computação.

[GitHub](https://github.com/AndreGuimaraes01)
