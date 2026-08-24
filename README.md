AutoCheck .NET — Sistema de Vistoria Veicular

O AutoCheck .NET é uma aplicação Console desenvolvida em C# para registrar e processar vistorias de carros, motos e caminhões. O sistema coleta os dados do veículo, apresenta um checklist específico para cada categoria, registra o estado dos itens inspecionados e calcula uma pontuação para apoiar decisões de compra ou revenda.

Ao final da vistoria, o programa apresenta a pontuação, o percentual de aprovação, a classificação do veículo, os itens críticos, os itens que exigem atenção e os serviços recomendados.

Este projeto foi desenvolvido para consolidar os conteúdos de C# e Programação Orientada a Objetos estudados no Módulo 01.

Funcionalidades

Menu interativo executado até o usuário escolher sair;

cadastro de carros, motos e caminhões;

coleta de marca, modelo, ano, quilometragem e atributos específicos;

checklist geral e checklist específico para cada tipo de veículo;

validação dos status Bom, Regular e Ruim;

armazenamento de várias vistorias em uma List<Veiculo>;

cálculo automático da pontuação e do percentual de aprovação;

classificação do estado do veículo;

separação das pendências por prioridade;

recomendação de serviços para a oficina;

emissão de relatório detalhado no terminal.

Tipos de veículo e checklists

Todos os veículos possuem dois itens gerais:

Nível de Óleo do Motor;

Bateria e Sistema Elétrico;

Cada subclasse acrescenta três itens relacionados à sua categoria.

Carro

Ar Condicionado Funcional;

Estepe e Macaco;

Triângulo de Sinalização.

O atributo específico do carro é a quantidade de portas.

Moto

Estado da Corrente;

Desgaste dos Pneus;

Sistema de Freios.

O atributo específico da moto é a quantidade de cilindradas.

Caminhão

Funcionamento do Tacógrafo;

Trava e Lona da Caçamba;

Sistema de Freios a Ar.

Os atributos específicos do caminhão são a quantidade de eixos e a capacidade de carga em toneladas.

Regras de negócio

Status e pontuação

Cada item inspecionado recebe um status:

Status

Pontuação

Interpretação

Bom

10 pontos

Item aprovado, sem necessidade de manutenção.

Regular

5 pontos

Item de atenção que exige revisão preventiva.

Ruim

0 pontos

Item crítico que exige reparo ou substituição.

Cada veículo possui cinco itens obrigatórios: dois gerais e três específicos. Portanto, a pontuação máxima de uma vistoria completa é de 50 pontos.

Cálculo da compatibilidade

No AutoCheck, a compatibilidade corresponde ao percentual de aprovação do veículo na vistoria. Ela é calculada pela fórmula:

percentual = (pontuação obtida / pontuação máxima) × 100

Por exemplo, se um veículo alcançar 40 de 50 pontos:

percentual = (40 / 50) × 100
percentual = 80%

Essa regra foi escolhida porque compara o resultado alcançado pelo veículo com a melhor pontuação possível. A conversão para double evita que o C# realize uma divisão inteira e descarte as casas decimais.

Antes do cálculo, o sistema verifica se a pontuação máxima é igual a zero. Isso impede uma divisão por zero caso nenhum item tenha sido avaliado.

Classificação final

Percentual

Classificação

Decisão recomendada

Maior ou igual a 90%

Aprovado com Excelência

Liberado para compra ou revenda imediata.

Maior ou igual a 60% e menor que 90%

Aprovado com Apontamentos

Exige negociação para cobrir os reparos.

Menor que 60%

Reprovado na Vistoria

Veículo recusado pela concessionária.

Se nenhum item tiver sido avaliado, o sistema informa que a vistoria ainda não foi realizada e não apresenta uma recomendação de compra ou revenda.

Priorização dos serviços

Os serviços recomendados são organizados conforme a gravidade dos problemas encontrados:

Itens com status Ruim aparecem primeiro, pois representam falhas críticas e exigem reparo ou substituição imediata.

Itens com status Regular aparecem depois, pois exigem revisão preventiva.

Itens com status Bom não geram recomendações de serviço.

Como executar o projeto

Pré-requisitos

.NET SDK;

Prompt de Comando, PowerShell ou terminal do VS Code;

opcionalmente, Visual Studio Code ou Visual Studio para visualizar e editar o projeto.

1. Verificar a instalação do .NET

Abra o terminal e execute:

dotnet --version

Se a instalação estiver correta, o terminal exibirá a versão instalada.

2. Clonar meu repositório
git clone (https://github.com/AnaFlaviaCorrea/T1-net-MiniProjeto.git)


3. Acessar a pasta do projeto

Entre na pasta raiz do repositório:

cd autocheck-dotnet

4. Restaurar as dependências

dotnet restore

5. Compilar o projeto

dotnet build

6. Executar a aplicação

Na raiz do repositório, execute:

dotnet run --project src/AutoCheck.ConsoleApp/AutoCheck.ConsoleApp.csproj

Também é possível entrar na pasta do projeto e executar o comando simplificado

7. Utilizar o menu

O programa apresenta as seguintes opções:

1 - Realizar nova vistoria
2 - Exibir relatório das vistorias
0 - Sair

Na opção 1, escolha o tipo de veículo, informe os dados solicitados e atribua o status Bom, Regular ou Ruim a cada item. Na opção 2, o sistema processa as vistorias armazenadas e exibe os relatórios. A opção 0 encerra o programa.

Conceitos do Módulo 01 aplicados

Lógica de programação e tipos primitivos

O projeto utiliza string para textos e status; int para ano, portas, cilindradas, eixos e pontuações; double para quilometragem, capacidade de carga e percentual; e bool para controlar condições do programa.

Coleções com List<T>

List<Veiculo> armazena as vistorias realizadas;

List<ItemVistoria> armazena os itens avaliados de cada veículo;

List<string> contém os nomes dos itens do checklist obrigatório.

Estruturas de controle

while mantém o menu em execução e repete leituras inválidas;

if/else calcula pontos, classifica o veículo e separa pendências;

switch trata as opções do menu e as recomendações;

foreach percorre checklists e itens avaliados;

for percorre a lista de veículos e numera os relatórios.

Programação Orientada a Objetos

Classes e objetos: ItemVistoria representa um item avaliado; Veiculo reúne características comuns; Carro, Moto e Caminhao representam os tipos concretos; e MotorVistoria executa cálculos, classificações e relatórios.

Propriedades e construtores: representam o estado dos objetos e garantem que os dados necessários sejam informados durante sua criação. O this diferencia propriedades e parâmetros com o mesmo nome.

Encapsulamento: a alteração do status de um item é controlada para aceitar apenas Bom, Regular ou Ruim.

Herança: Carro, Moto e Caminhao utilizam : Veiculo para reutilizar características e comportamentos. Seus construtores chamam base(...) para enviar os dados gerais ao construtor da classe-base.

Sobrescrita: ObterChecklistObrigatorio() é declarado como virtual em Veiculo e redefinido com override nas subclasses, que aproveitam os itens gerais por meio de base.ObterChecklistObrigatorio().

Polimorfismo: os diferentes tipos são armazenados em uma mesma List<Veiculo> e processados pelos métodos de MotorVistoria, mantendo seus atributos e checklists específicos.

Composição: cada Veiculo possui uma List<ItemVistoria>, pois uma vistoria é formada por vários itens avaliados.

Arquitetura

O AutoCheck é uma aplicação Console local, portanto não utiliza arquitetura cliente-servidor. A entrada de dados, o processamento, o armazenamento temporário e a exibição dos resultados acontecem no mesmo processo.

Estrutura do projeto

Models contém as entidades e suas características;

Services contém as regras de pontuação, classificação, recomendação e relatório;

Program.cs contém o menu, a entrada de dados, a navegação e os testes manuais da aplicação.