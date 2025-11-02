# 💸 FraudGraphAnalyzer

**Detecção e Rastreamento de Fraudes em Transações Financeiras utilizando Grafos**

---

## 🧠 Sobre o Projeto

O **FraudGraphAnalyzer** é um aplicativo desenvolvido em **C# com Windows Forms** que demonstra, de forma prática, como a **teoria dos grafos** pode ser aplicada para **detecção e rastreamento de fraudes financeiras**.

Em sistemas bancários reais, as transações entre contas formam uma rede complexa. Usando grafos, é possível **mapear essas conexões** e **identificar padrões suspeitos**, como ciclos de lavagem de dinheiro.

Exemplo:

A → B → C → D → A

➡️ Esse tipo de ciclo pode indicar **lavagem de dinheiro**.  
O sistema detecta automaticamente tais padrões utilizando algoritmos de busca e análise de grafos.

---

## 👥 Integrantes da Equipe

- Mateus Botelho  
- Victor Alves  
- Daniel Heringer  
- Lucas Borges  
- Vitor Mendonça  

---

## ⚙️ Tecnologias Utilizadas

- **C# (.NET 8)**
- **Windows Forms**
- **Programação Orientada a Objetos**
- **Teoria dos Grafos (DFS, BFS, Centralidade, Ciclos)**
- **Visual Studio 2022**

---

## 📊 Estrutura do Projeto

```bash
FraudGraphAnalyzer/
├── Graph/
│ ├── Graph.cs # Estrutura principal do grafo
│ ├── Algorithms.cs # Algoritmos de DFS, BFS e detecção de ciclos
│ ├── GraphRenderer.cs # Renderização visual do grafo
│ └── GraphDotExporter.cs# Exporta o grafo em formato DOT (Graphviz)
│
├── Models/
│ ├── Node.cs # Representa uma conta (nó)
│ └── Edge.cs # Representa uma transação (aresta)
│
├── Data/
│ └── SampleData.cs # Dados simulados de exemplo
│
├── WinForms/
│ ├── MainForm.cs # Lógica principal da interface
│ ├── MainForm.Designer.cs # Layout e controles visuais
│
└── Program.cs # Ponto de entrada da aplicação
```

---

## 🧩 Funcionalidades

| Função | Descrição |
|--------|------------|
| 🔍 **Detectar ciclos** | Identifica possíveis redes de lavagem de dinheiro (A → B → D → A) |
| 🧭 **Buscar caminho** | Encontra a rota entre duas contas (BFS / Shortest Path) |
| 🧠 **Centralidade** | Exibe contas mais conectadas (grau de entrada e saída) |
| 🧾 **Visualização** | Mostra o grafo com conexões coloridas |
| 📤 **Exportar DOT** | Exporta o grafo para visualização no Graphviz |

---

## 🧰 Como Executar

### Pré-requisitos
- [Visual Studio 2022](https://visualstudio.microsoft.com/)
- SDK .NET 8.0 instalado

### Passos
1. Clone o repositório:
   ```bash
   git clone https://github.com/SEU-USUARIO/FraudGraphAnalyzer.git

2. Abra o arquivo FraudGraphAnalyzer.sln no Visual Studio.

3. Compile e execute (F5).

O programa abrirá uma janela com:

- Painel gráfico interativo

- Lista de contas e transações

- Caixa de logs com os resultados das análises

---

📚 Conceitos Envolvidos

- DFS (Depth-First Search): usado para detectar ciclos e fraudes potenciais.

- BFS (Breadth-First Search): usado para rastrear o caminho entre duas contas.

- Centralidade: identifica as contas mais influentes na rede.

---

🧮 Exemplo de Uso

- Clique em Detectar Ciclos para verificar se há movimentações suspeitas.

- Digite duas contas (ex: A e D) e clique em Encontrar Caminho.

- Use Centralidade para ver quais contas mais participam em transações.

- Exporte o grafo em formato DOT e visualize no Graphviz.

---

🧑‍💻 Organização do Código

| Camada       | Descrição                                                |
| ------------ | -------------------------------------------------------- |
| **Models**   | Define as estruturas de dados (Node, Edge).              |
| **Graph**    | Contém a lógica de processamento e algoritmos de grafos. |
| **WinForms** | Interface visual e interação do usuário.                 |
| **Data**     | Dados simulados e integração futura com JSON/API.        |

---

🏁 Objetivo Acadêmico

Este projeto foi desenvolvido para o Projeto Aplicativo (PA) da disciplina de Algoritmos em Grafos, com o objetivo de demonstrar a aplicabilidade prática da teoria dos grafos na segurança financeira e detecção de fraudes.

---

🧾 Licença

Este projeto é de uso acadêmico e livre para fins educacionais.




