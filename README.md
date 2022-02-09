# Introdu��o 
Este projeto visa executar a automa��o de testes do projeto Onboarding PF da Ailos 

# Pr�-requisitos
Ter instalado as aplica��es abaixo:
- Visual Studio 2019
- Git

# Clonando o projeto
Com o [git](https://git-scm.com/downloads) instalado na m�quina, executar o comando abaixo para efetuar o clone do projeto:

	$ git clone https://Ailos@dev.azure.com/Ailos/AutomacaoTeste/_git/Ailos.Test.Automation.Web.OnboardingPF

# Executando os testes
Para executar os testes do projeto via prompt com a configura��o padr�o, basta executar o comando abaixo(� necess�rio estar com o prompt no diret�rio da solution):

	$ dotnet test

Caso queira executar os testes do projeto com uma configura��o espec�fica, basta chamar o arquivo de configura��o(extens�o `.runsettings`) no comando:

	$ dotnet test -s <arquivo de configura��o>

Ex: dotnet test -s appChrome.runsettings

# Resultado dos testes
Um report dos testes � gerado no formato HTML dentro da pasta "TestResults" existente dentro da Solution.
