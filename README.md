# ConsultaEstoque
	- Criação de CRUD simples, utilizando WPF(.Net Core) com persistência de dados em SQL Server

# Pasta Domínio
	- Cria as Models e DAO necessárias para a criação do projeto
	
# Pasta ProdutoDesktop
	- Cria as Views necessárias para rodar o projeto.

# Projeto utiliza SQL Sever, pelo gerenciador Manager Studio
	- Dentro do projeto Domínio->DAO->BaseDAO tem o método para conexão ao banco
				private static string GetStringConexao()
        {
            return @"Integrated Security=SSPI;Persist Security Info=False;" +
                   @"Initial Catalog=APS_PW;Data Source=LAPTOP-I4I6RRL5\SQLEXPRESS";
        } 
	- Para utilização substitua nesse metódo a cima colocando o Data Source da máquina que está usando.
