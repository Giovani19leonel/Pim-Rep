- Passos para rodar a PIM.API.

- PIM.API
    - Passo 1
        - arrumar o arquivo "launghSettings.json" que fica na Properties dentro da PIM.API
            - trocar o valor da applicationUrl para "https://localhost:7211"
    - Passo 2
        - abrir o arquivo "Startup.cs" que fica na PIM.API
            - colocar a sua string de conexão (SQL_SERVER) dentro da services.AddHttpServices("AQUI DENTRO");

Dependencias: Implementar o banco de dados