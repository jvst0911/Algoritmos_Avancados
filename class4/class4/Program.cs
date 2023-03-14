// Crie um menu interativo com as seguintes opções: 1 - Inserir elemento, 2 - Listar elementos e 3 - Sair
// Crie um algoritmo recursivo para popular listas e vetores individualmente apenas com C# nativo;

LinkedList<int> list = new LinkedList<int>();
int[] vec = new int[10];

func2();

void func1()
{
    Console.WriteLine("\n1 - Inserir elemento");
    Console.WriteLine("2 - Listar elementos");
    Console.WriteLine("3 - Sair\n");

    var op = Console.ReadLine();
    int[] vec = { 1, 2, 3 };

    if (op.Equals("1"))
    {
        Console.WriteLine("Qual valor deve ser inserido?");
        if (!int.TryParse(Console.ReadLine(), out int newValue))
            return;

        list.AddLast(newValue);
    }

    if (op.Equals("2"))
    {
        Console.Write($"{string.Join(",", list)}\n");
        func1();
    }

    if (op.Equals("3"))
        return;

    func1();
}

void func2()
{
    Console.WriteLine("\n1 - Inserir elemento");
    Console.WriteLine("2 - Listar elementos");
    Console.WriteLine("3 - Sair\n");

    var op = Console.ReadLine();

    if (op.Equals("1"))
    {
        Console.WriteLine("Qual valor deve ser inserido?");
        if (!int.TryParse(Console.ReadLine(), out int newValue))
            return;

        if (HasSlotsAvailable(vec, 0, newValue))
            func2();
        else
            newVector(vec, newValue);
    }

    if (op.Equals("2"))
    {
        Console.Write($"{string.Join(",", vec)}\n");
        func2();
    }

    if (op.Equals("3"))
        return;
}

void newVector(int[] vector, int newValue)
{
    var auxVector = new int[vector.Length + 1];
    vector.CopyTo(auxVector, 0);
    vec = new int[auxVector.Length];

    if (HasSlotsAvailable(auxVector, 0, newValue))
    {
        auxVector.CopyTo(vec, 0);
        func2();
    }
    else
        newVector(auxVector, newValue);
}

bool HasSlotsAvailable(int[] vec, int index, int newValue)
{
    if (index > vec.Length - 1)
        return false;

    if (vec[index].Equals(0))
        vec[index] = newValue;
    else
        return HasSlotsAvailable(vec, index + 1, newValue);

    return true;
}