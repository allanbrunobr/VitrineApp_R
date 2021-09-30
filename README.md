# VitrineApp_R
Grillo - Projeto Teste ASP .NET Core (paginação, busca, JSON)

Tela de consulta desenvolvida no Microsoft Visual Studio 2019, utilizando o Framework ASP.NET Core + Bootstrap. 
O projeto foi criado como uma Web Application, sem utilizar o MVC.
Foi utilizado também o Razor com o intuito de implementar um CRUD, mas como as funcionalidadse solicitadas para o teste (consulta e detalhamento) a partir de um arquivo .JSON online, a parte de inclusão, da alteração e de exclusão não foi realizada por estar fora do escopo da solicitação inicial.

Aproveitei a pagina "index" para realizar a consulta, pois não haveria a necessidade de uma tela inicial por causa do escopo do teste técnico. 

A funcionalidade de consulta foi implementada com os seguintes filtros:
- Campo de busca
- Tipo de pesquisa (nome, marca, categoria, preço e tags)
- Tipo de ordenamento (nome, preço maior e preço menor)

** ATENÇÃO **
Em andamento (buscando solução)
- As pesquisas por categoria, preço e tags não estão funcionando, apesar da implementação do código não ser diferente da pesquisa por nome e marca.
- O detalhamento não está funcionando.
- A paginação está funcionando, mas ainda não consegui implementar a redução dos índices em exibição, ,i.e., ao invés de exibir << 1 2 3 >>, ele exibe todas as mais de 75 numerações das páginas na tela.


** UTILIZAÇÃO **
Baixar / Clonar o repositório pelo Visual Studio pelo endereço
