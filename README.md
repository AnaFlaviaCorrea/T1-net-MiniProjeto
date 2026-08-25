<div align="center">

🚗 AutoCheck .NET

Sistema de Vistoria Veicular






Aplicação Console para registrar, processar e classificar vistorias de carros, motos e caminhões.

▶️ Assistir ao vídeo de apresentação

</div>

📌 Sobre o projeto

O AutoCheck .NET é uma aplicação Console desenvolvida em C# para registrar e processar vistorias de carros, motos e caminhões.

O sistema coleta os dados do veículo, apresenta um checklist específico para cada categoria, registra o estado dos itens inspecionados e calcula uma pontuação para apoiar decisões de compra ou revenda.

Ao final da vistoria, o programa apresenta:

📊 pontuação e percentual de aprovação;

🏆 classificação final do veículo;

🔴 itens críticos;

🟡 itens que exigem atenção;

🔧 serviços recomendados para a oficina.

Este projeto foi desenvolvido para consolidar os conteúdos de C# e Programação Orientada a Objetos estudados no Módulo 01.

✨ Funcionalidades

✅ Menu interativo executado até o usuário escolher sair;

✅ Cadastro de carros, motos e caminhões;

✅ Coleta de marca, modelo, ano, quilometragem e atributos específicos;

✅ Checklist geral e checklist específico para cada tipo de veículo;

✅ Validação dos status Bom, Regular e Ruim;

✅ Armazenamento de várias vistorias em uma List<Veiculo>;

✅ Cálculo automático da pontuação e do percentual de aprovação;

✅ Classificação do estado do veículo;

✅ Separação das pendências por prioridade;

✅ Recomendação de serviços para a oficina;

✅ Emissão de relatório detalhado no terminal.

🚘 Tipos de veículo e checklists

Todos os veículos possuem dois itens gerais:

Nível de Óleo do Motor;

Bateria e Sistema Elétrico.

Cada subclasse acrescenta três itens relacionados à sua categoria.

🚗 Carro

🏍️ Moto

🚚 Caminhão

Ar Condicionado Funcional

Estado da Corrente

Funcionamento do Tacógrafo

Estepe e Macaco

Desgaste dos Pneus

Trava e Lona da Caçamba

Triângulo de Sinalização

Sistema de Freios

Sistema de Freios a Ar

Atributo: quantidade de portas

Atributo: cilindradas

Atributos: eixos e capacidade de carga

📋 Regras de negócio

Status e pontuação

Status

Pontuação

Interpretação

🟢 Bom

10 pontos

Item aprovado, sem necessidade de manutenção.

🟡 Regular

5 pontos

Item de atenção que exige revisão preventiva.

🔴 Ruim

0 pontos

Item crítico que exige reparo ou substituição.

Cada veículo possui cinco itens obrigatórios: dois gerais e três específicos. Portanto, a pontuação máxima de uma vistoria completa é de 50 pontos.

🧮 Cálculo da compatibilidade

No AutoCheck, a compatibilidade corresponde ao percentual de aprovação do veículo na vistoria:

percentual = (pontuação obtida / pontuação máxima) × 100

Se um veículo alcançar 40 de 50 pontos:

percentual = (40 / 50) × 100
percentual = 80%

Essa regra compara o resultado alcançado pelo veículo com a melhor pontuação possível. A conversão para double evita que o C# realize uma divisão inteira e descarte as casas decimais.

Antes do cálculo, o sistema verifica se a pontuação máxima é igual a zero, evitando uma divisão por zero caso nenhum item tenha sido avaliado.

🏁 Classificação final

Percentual

Classificação

Decisão recomendada

🟢 90% a 100%

Aprovado com Excelência

Liberado para compra ou revenda imediata.

🟡 60% a menos de 90%

Aprovado com Apontamentos

Exige negociação para cobrir os reparos.

🔴 Abaixo de 60%

Reprovado na Vistoria

Veículo recusado pela concessionária.

Se nenhum item tiver sido avaliado, o sistema informa que a vistoria ainda não foi realizada e não apresenta recomendação de compra ou revenda.

🔧 Priorização dos serviços

🔴 Itens com status Ruim aparecem primeiro, pois exigem reparo ou substituição imediata;

🟡 Itens com status Regular aparecem depois, pois exigem revisão preventiva;

🟢 Itens com status Bom não geram recomendações de serviço.

▶️ Como executar o projeto

Pré-requisitos

.NET SDK;

Prompt de Comando, PowerShell ou terminal do VS Code;

opcionalmente, Visual Studio Code ou Visual Studio.

1. Verificar a instalação do .NET

dotnet --version

2. Clonar o repositório

git clone https://github.com/AnaFlaviaCorrea/T1-net-MiniProjeto.git

3. Acessar a pasta clonada

cd T1-net-MiniProjeto

4. Restaurar as dependências

dotnet restore

5. Compilar o projeto

dotnet build

6. Executar a aplicação

Na raiz do repositório:

dotnet run --project src/AutoCheck.ConsoleApp/AutoCheck.ConsoleApp.csproj

Também é possível entrar na pasta do projeto e executar o comando simplificado:

cd src/AutoCheck.ConsoleApp
dotnet run

7. Utilizar o menu

1 - Realizar nova vistoria
2 - Exibir relatório das vistorias
0 - Sair

Na opção 1, escolha o veículo, informe os dados e avalie cada item como Bom, Regular ou Ruim;

Na opção 2, o sistema processa as vistorias armazenadas e exibe os relatórios;

A opção 0 encerra o programa.

🧠 Conceitos do Módulo 01 aplicados

Lógica de programação e tipos primitivos

Tipo

Utilização no projeto

string

Textos, nomes e status dos itens.

int

Ano, portas, cilindradas, eixos e pontuações.

double

Quilometragem, capacidade de carga e percentual.

bool

Controle de condições e execução do menu.

Coleções com List<T>

List<Veiculo> armazena as vistorias realizadas;

List<ItemVistoria> armazena os itens avaliados de cada veículo;

List<string> contém os nomes do checklist obrigatório.

Estruturas de controle

Estrutura

Aplicação

while

Mantém o menu em execução e repete leituras inválidas.

if/else

Calcula pontos, classifica o veículo e separa pendências.

switch

Trata as opções do menu e as recomendações.

foreach

Percorre os checklists e itens avaliados.

for

Percorre a lista de veículos e numera os relatórios.

Programação Orientada a Objetos

Classes e objetos: ItemVistoria representa um item avaliado; Veiculo reúne características comuns; Carro, Moto e Caminhao representam os tipos concretos; MotorVistoria executa cálculos, classificações e relatórios;

Propriedades e construtores: representam o estado dos objetos e garantem o preenchimento dos dados necessários. O this diferencia propriedades e parâmetros com o mesmo nome;

Encapsulamento: a alteração do status é controlada para aceitar apenas Bom, Regular ou Ruim;

Herança: Carro, Moto e Caminhao utilizam : Veiculo. Seus construtores chamam base(...) para enviar os dados gerais à classe-base;

Sobrescrita: ObterChecklistObrigatorio() é virtual em Veiculo e redefinido com override nas subclasses;

Polimorfismo: os tipos são armazenados na mesma List<Veiculo> e processados pelos métodos de MotorVistoria;

Composição: cada Veiculo possui uma List<ItemVistoria>, pois uma vistoria é formada por vários itens avaliados.

🏗️ Arquitetura

O AutoCheck é uma aplicação Console local e, nesta versão, não utiliza arquitetura cliente-servidor. A entrada de dados, o processamento, o armazenamento temporário e a exibição dos resultados acontecem no mesmo processo.

O projeto separa as entidades, as regras de negócio e a navegação. Essa organização permite uma futura evolução para uma API no servidor e uma interface Web, desktop ou móvel como cliente.
 

Models contém as entidades e suas características;

Services contém as regras de pontuação, classificação, recomendação e relatório;

Program.cs contém o menu, a entrada de dados, a navegação e os testes manuais.

🎥 Vídeo de apresentação

O vídeo demonstra o funcionamento do sistema, as principais partes do código, as validações realizadas e a organização do desenvolvimento com Git e branches.

▶️ Assistir à apresentação do AutoCheck .NET (https://youtu.be/wdzb0RGWHqQ)

🤖 Uso de Inteligência Artificial

Durante o desenvolvimento, utilizei Inteligência Artificial como ferramenta de apoio para esclarecer dúvidas e revisar trechos do código, especificamente os requisitos funcionais RF07 e RF08.

As decisões sobre as regras de negócio, a implementação, os testes e a validação do funcionamento foram realizadas e conferidas por mim.

<div align="center">

Desenvolvido para fins acadêmicos 📚



</div>
