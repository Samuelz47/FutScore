# FutScore - Gerenciador de Campeonatos de Futebol ⚽

## 📖 Sobre o Projeto

FutScore é uma aplicação de console desenvolvida em C# como um projeto de estudo aprofundado para simular e gerenciar campeonatos de futebol. O sistema permite o cadastro de times e jogadores, a simulação de partidas com resultados baseados na força das equipes, e a exibição de tabelas de classificação e artilharia, com todos os dados persistidos em um banco de dados.

Este projeto foi construído do zero, focando em boas práticas de programação e arquitetura de software, como o padrão Repositório, Unit of Work e a separação de responsabilidades em camadas.

---

## ✨ Funcionalidades Principais

* **Cadastro de Times:** Adicionar novos times ao campeonato com nome e um atributo de "força" (1-100).
* **Cadastro de Jogadores:** Adicionar jogadores a um time existente, com nome e posição.
* **Simulação de Partidas:**
    * Simulação de jogos individuais ou de um campeonato completo (ida e volta).
    * O resultado da partida é influenciado pela força de cada time e um fator de aleatoriedade.
    * Os gols são atribuídos aleatoriamente aos jogadores do elenco, com base na posição.
* **Persistência de Dados:** Todos os times, jogadores, partidas e estatísticas são salvos em um banco de dados SQL Server usando EF Core.
* **Exibição de Resultados:**
    * Tabela de classificação completa, ordenada por pontos e outros critérios de desempate.
    * Lista de artilheiros do campeonato.

---

## 🚀 Tecnologias Utilizadas

* **C#** e **.NET**
* **Entity Framework Core:** Para o mapeamento objeto-relacional (ORM) e comunicação com o banco de dados.
* **SQL Server:** Sistema de gerenciamento de banco de dados.
* **Arquitetura em Camadas:** O projeto é dividido em camadas de Apresentação (Console), Dados (DAL) e Domínio (Modelos).
* **Padrões de Design:** Implementação do padrão Repositório Genérico e Unit of Work para um acesso a dados limpo e eficiente.
* **Programação Orientada a Objetos (OOP):** Uso de classes, herança, encapsulamento e polimorfismo para estruturar o código.

---

## 🏁 Como Executar o Projeto

1.  Clone este repositório para a sua máquina local.
2.  Abra o arquivo de solução (`.sln`) no Visual Studio 2022.
3.  No **Console do Gerenciador de Pacotes** (Package Manager Console), com o projeto `FutScore.Data` selecionado, execute o comando `Update-Database` para criar o banco de dados e popular os dados iniciais.
4.  Defina o projeto `FutScore` (o aplicativo de console) como projeto de inicialização (clique direito > Definir como Projeto de Inicialização).
5.  Pressione `F5` ou o botão "Iniciar" para rodar a aplicação.
