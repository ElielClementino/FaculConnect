# FaculConnect
Projeto full-stack de uma plataforma de faculdade. Esse projeto foi feito utilizando as seguintes tecnologias:
> - C# (back-end)
> - Postgres (database)
> - Docker (Virtualização de contêineres, usado para subir o postgresql)
> - Javascript + Vue.js + Vuetify + Nuxt.js (Criação das interfaces do projeto)

## Design do projeto  
Na raiz do projeto é possível encontrar o seguinte arquivo:
1. Database.drawio.png  
> - Esse é o diagrama inicial em que o banco de dados foi visionado.
Também é possível encontrar o seguinte diretório:
2. PagesSketch  
> - Dentro desse diretório está o designer inicial das telas, feito utilizando o figma.

Gif das funcionalidades do projeto:
![FaculConnect](https://github.com/ElielClementino/FaculConnect/assets/94757087/fe7b03f0-141b-4066-be49-e040e0502d8f)

## Setup do projeto
Na raiz do projeto existe um arquivo chamado .env_sample, é necessário mudar o nome do arquivo para .env, pois o container que sobe o postgres lê as configurações desse arquivo.  
`$ cp .env_sample .env`  
Também na raiz do projeto, tem um outro arquivo chamado appsettings_sample.json, é necessário mudar o nome do arquivo para appsettings.json, pois as credenciais do entity framework se encontram lá.  
`$ cp appsettings_sample.json appsettings.json`  
Agora, antes de rodar o projeto, será necessário subir o postgres, para isso, usaremos:
### Docker
1. No terminal rode o seguinte comando:  
`$ docker-compose up`
2. Após isso, para checar se o container do postgres está de pé, utilize o comando:  
`$ docker ps`
## Instalando dependências
Antes de tentar rodar o projeto, também é necessário instalar as dependências. Na raiz do projeto, será encontrado o arquivo FaculConnect.csproj, arquivo
este que guarda as libs externas que foram usadas nesse projeto. Para configurar-las rode o seguinte comando:  
`$ dotnet restore`  
Agora será necessário baixar as dependências do front do projeto. Para isso, entre na pasta Frontend, as dependências se encontram no arquivo package-lock.json.
Para instalar as dependências, rode o seguinte comando:  
> - `$ cd Frontend/`  
> - `$ npm install`  
## Rodando o projeto
Após todas as configurações serem realizadas, podemos rodar o projeto. Para subir o back, utilize o comando:
`$ dotnet run`  
E para subir o front, utilize o comando:
`$ npm run dev`
