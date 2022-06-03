# Arquivos de configuração

1. AppSettings.json: arquivo de configuração da aplicação.
2. solutionName.csproj: arquivo de configuração do projeto.
3. launchSettings.json: arquivo de configuração da execução do projeto.

# Estrutura de um projeto Blazor Pages MVC:

1. Em /Pages/Shared/ temos o arquivo viewer (ex. Index.cshtml) e o arquivo Model (ex. Index.cshtml.cs).
2. wwwroot é onde colocamos todos os arquivos html, css e javascript necessários. 
3. Shared contem as partial views. Páginas usadas através de todo o site. 
4. _ViewImports é onde adicionamos tag helpers para todas as páginas(arquivos que começam com "_" são utilizados em todas as páginas da aplicação).
5. _ViewStart.cshtml here we define the masterpage.

# Roteamento no Razor Pages

1. A abordagem escolhida é mapear as URL para arquivos do disco.
2. Por isso, uma aplicação Razor Pages precisa de um diretório raiz - neste caso, a raiz é o diretório Pages.
3. index.cshtml é o arquivo padrão.

- Por exemplo:

https://domain.com vai ser mapeado para /Pages/index.cshtml
https://domain.com/Privacy será mapeado ou para /Pages/Privacy.cshtml ou para /Pages/Privacy/index.cshtml

# Tag Helpers 

1. Tag helpers permitem que o código no servidor crie e redenrize elementos html no Razor Pages.
 
# Program.cs

1. Temos o método Main _____(termo técnico para inicio da aplicação).
2. A configuração é feita por CreateHostBuilder(args)
3. CreateHostBuilder(string []args) é implementado em Program.cs e retorna IHostBuilder.
4. Em CreateHostBuilder() temos CreateDefaulBuilder(args) que lida com a configuração do WebServer, arquivos, roteamento, etc. 
5. Aqui temos a configuração do arquivo Startup.cs em webBuilder.UseStartup<Startup>();

# Startup.cs

1. 
´´


























