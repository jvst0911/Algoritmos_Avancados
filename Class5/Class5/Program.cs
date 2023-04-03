// Alunos: Eduardo Augusto Ferreira, João Vitor de Souza Tomio

Dictionary<char, BinarySearchTree> letterTrees = new Dictionary<char, BinarySearchTree>();
LoadData(File.ReadAllLines(@"C:\Users\Dev\source\repos\Faculdade\Algoritmos_Avancados\Class5\Class5\dados.txt"));
string input;
do
{
    Console.WriteLine("\nEscolha uma opção:");
    Console.WriteLine("1. Inserir");
    Console.WriteLine("2. Listar");
    Console.WriteLine("3. Sair");
    Console.Write("Opção: ");
    input = Console.ReadLine();
    switch (input)
    {
        case "1":
            Console.Write("Nome: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            char firstLetter = char.ToUpper(name[0]);
            if (!letterTrees.ContainsKey(firstLetter))
            {
                letterTrees[firstLetter] = new BinarySearchTree();
            }
            letterTrees[firstLetter].Insert(name, email);
            break;
        case "2":
            Console.WriteLine("\nNomes ordenados:");
            var orderedKeys = new List<char>(letterTrees.Keys);
            orderedKeys.Sort();
            foreach (var key in orderedKeys)
            {
                Console.WriteLine($"Nomes começando com '{key}':");
                letterTrees[key].DisplayInOrder();
                Console.WriteLine();
            }
            break;
        case "3":
            break;
        default:
            Console.WriteLine("Opção inválida.");
            break;
    }
} while (input != "3");

void LoadData(string[] fileContent)
{
    foreach (var item in fileContent)
    {
        var split = item.Split(",");
        string name = split[0];
        string email = split[1];
        char firstLetter = char.ToUpper(name[0]);
        if (!letterTrees.ContainsKey(firstLetter))
        {
            letterTrees[firstLetter] = new BinarySearchTree();
        }
        letterTrees[firstLetter].Insert(name, email);
    }
}

public class Node
{
    public string Name;
    public string Email;
    public Node? Left;
    public Node? Right;

    public Node(string name, string email)
    {
        Name = name;
        Email = email;
    }
}

public class BinarySearchTree
{
    private Node? root;

    public BinarySearchTree()
    {
    }

    public void Insert(string name, string email)
    {
        if (root == null)
            root = new Node(name, email);
        else
            InsertRecursively(root, name, email);
    }
    private void InsertRecursively(Node currentNode, string name, string email)
    {
        if (string.Compare(name, currentNode.Name) < 0)
        {
            if (currentNode.Left == null)
                currentNode.Left = new Node(name, email);
            else
                InsertRecursively(currentNode.Left, name, email);
        }
        else
        {
            if (currentNode.Right == null)
                currentNode.Right = new Node(name, email);
            else
                InsertRecursively(currentNode.Right, name, email);
        }
    }
    public void DisplayInOrder()
    {
        DisplayInOrderRecursively(root);
        Console.WriteLine();
    }

    private void DisplayInOrderRecursively(Node? currentNode)
    {
        if (currentNode == null)
            return;

        DisplayInOrderRecursively(currentNode.Left);
        Console.Write($"Nome: {currentNode.Name} Email: {currentNode.Email} \n");
        DisplayInOrderRecursively(currentNode.Right);
    }
}
