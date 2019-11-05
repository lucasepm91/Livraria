# Livraria
Solução prova estágio ED

# Software e extensões
Foi utilizado o Visual Studio 2019 (testado com êxito na versão 2017 também)
Asp.Net Core 2.0
Entity Framework (verificar se está instalado, caso contrário, é possível instalar através do gerenciador de pacotes NuGet.

# Comando para gerar o banco de dados
Após verificar se o Entity Framework está instalado, abrir o Console do gerenciador de pacotes do NuGet (Ferramentas -> Gerenciador de pacotes do NuGet -> Console do gerenciador de pacotes). Executar o comando update-database.

# Inicialização dos projetos em conjunto
Clique com o botão direito do mouse na solução e escolha Propriedades. Verifique se em "Projeto de inicialização" está marcada a opção "Vários projetos de inicialização". A ação do projeto LivrariaApi deve ser "Iniciar" e a ação do projeto SimpleBooks deve ser "Iniciar sem depuração".
