📚 TechLibrary
💡 Sobre o Projeto
O TechLibrary é uma API desenvolvida durante a Next Level Week (NLW) da Rocketseat, com o objetivo de gerenciar o cadastro de usuários, login, listagem e reserva de livros em uma biblioteca. O projeto foi construído utilizando boas práticas de desenvolvimento, proporcionando uma API escalável e fácil de integrar.

⚙️ Funcionalidades
👤 Criação de Usuários e Autenticação: Cadastro de novos usuários com autenticação segura.
🔒 Criptografia de Senhas: Utilização do algoritmo BCrypt para proteger dados sensíveis.
🗄️ Integração com Banco de Dados: Persistência de dados utilizando SQLite e Entity Framework Core.
🔑 Implementação de Tokens JWT: Autenticação e autorização seguras usando JSON Web Token.
🛠️ Tratamento de Exceções Personalizadas: Respostas claras e seguras para erros do sistema.
📖 Listagem de Livros: Consulte os livros disponíveis na biblioteca.
📊 Paginação e Filtragem: Otimize a recuperação de livros utilizando filtros personalizados e paginação.
📅 Reserva de Livros: Realize reservas de livros diretamente pela API.
🗑️ Gerenciamento de Reservas: Cancele ou atualize suas reservas a qualquer momento.
🛠️ Tecnologias Utilizadas
💻 Linguagem: C#
🌐 Framework: .NET 9.0
📡 API REST
🗄️ Banco de Dados: SQLite
🔑 Autenticação: JWT (JSON Web Token)
🛡️ Criptografia de Senhas: BCrypt
🧪 Testes: xUnit
📊 Documentação: Swagger
📦 Dependências
Microsoft.EntityFrameworkCore – ORM para mapeamento do banco de dados
Microsoft.EntityFrameworkCore.Sqlite – Provedor SQLite para Entity Framework Core
FluentValidation – Validação de dados
BCrypt.Net-Next – Criptografia de senhas
Microsoft.IdentityModel.Tokens – Suporte para autenticação baseada em tokens
System.IdentityModel.Tokens.Jwt – Geração e validação de tokens JWT
Microsoft.AspNetCore.Authentication.JwtBearer – Autenticação via JWT
🛠️ Pré-requisitos
Antes de iniciar o projeto, tenha instalado em sua máquina:

💾 .NET 9.0 SDK
🗄️ SQLite
💻 Visual Studio ou Visual Studio Code
🚀 Como Rodar o Projeto
Clone o repositório:

bash
Copiar
Editar
git clone https://github.com/danielalves09/TechLibrary.git
Acesse a pasta do projeto:

bash
Copiar
Editar
cd TechLibrary
Restaure as dependências:

bash
Copiar
Editar
dotnet restore
Configure o banco de dados:
Edite o arquivo appsettings.json com o caminho do seu banco SQLite.

Aplique as migrações:

bash
Copiar
Editar
dotnet ef database update
Execute o projeto:

bash
Copiar
Editar
dotnet run --project TechLibrary.Api
Acesse a documentação Swagger:
Abra o navegador e acesse: https://localhost:5001/swagger para testar os endpoints.

📊 Endpoints Principais
POST /api/auth/register → Cadastro de novos usuários
POST /api/auth/login → Login e geração do token JWT
GET /api/books → Listagem de todos os livros disponíveis (com paginação e filtragem)
POST /api/books/reserve → Reserva de um livro
DELETE /api/books/reserve/{id} → Cancelar reserva
🤝 Contribuindo
Contribuições são sempre bem-vindas! ✨

🍴 Faça um fork do projeto
🌿 Crie uma branch (git checkout -b feature/minha-nova-feature)
✅ Commit suas alterações (git commit -m 'Adicionando nova feature')
📤 Faça o push para sua branch (git push origin feature/minha-nova-feature)
📬 Abra um Pull Request
📄 Licença
Este projeto está sob a licença MIT. Para mais detalhes, consulte o arquivo LICENSE.

📬 Contato
👤 Autor: Daniel Alves
📧 Email: danielalves@example.com
🌐 GitHub: danielalves09
🚀 Desenvolvido durante a NLW da Rocketseat 🚀
