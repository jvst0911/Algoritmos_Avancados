//Alunos: João Vitor de Souza Tomio e Wilson Roberto Marutti

using System.Diagnostics;

Console.Write(Soma(new List<double> { 2, 4, 6 }) + "\n");

int count = 0;
Console.WriteLine(Count(count, new List<double> { 2, 4, 6 }) + "\n");

double max = double.MinValue;
Console.Write(Max(max, new List<double> { 2, 4, 6 }) + "\n");

//4.1
double Soma(List<double> list)
{
    if (list.Count == 0) return 0;

    return list[0] + Soma(list.GetRange(1, list.Count - 1));
}

//4.2
int Count(int count, List<double> list)
{
    if (list.Count == 0) return count;

    count++;

    return Count(count, list.GetRange(1, list.Count - 1));
}

//4.3
double Max(double max, List<double> list)
{
    if (list.Count == 0) return max;

    if (list[0] > max)
        max = list[0];

    return Max(max, list.GetRange(1, list.Count - 1));
}

//4.4
//O caso base da pesquisa binária ocorre quando a lista tem apenas um elemento. Nesse caso, se o valor procurado estiver presente na lista, ele será igual ao elemento da lista. Se o valor procurado não estiver presente, a pesquisa retorna que o valor não foi encontrado.
//O caso recursivo da pesquisa binária ocorre quando a lista tem mais de um elemento. O algoritmo divide a lista em duas metades e verifica em qual metade o valor procurado pode estar presente. Em seguida, a pesquisa é realizada recursivamente na metade escolhida até que o valor procurado seja encontrado ou seja determinado que ele não está presente na lista.

Stopwatch sw = new Stopwatch();

//4.5
PrintArrayValues(new List<double> { 2, 4, 6 });
//4.6
DuplicateArrayElements(new List<double> { 2, 4, 6 });
//4.7
DuplicateFirstElement(new List<double> { 2, 4, 6 });
//4.8
CreateMultiplicationTable(new List<double> { 2, 4, 6 });

void PrintArrayValues(List<double> list)
{
    sw.Start();
    foreach (int i in list)
        Console.Write(i + " ");
    sw.Stop();
    Console.WriteLine($"\nTempo para imprimir o array: {sw.ElapsedMilliseconds}ms\n");
}

void DuplicateArrayElements(List<double> lista)
{
    sw.Reset();
    sw.Start();
    for (int i = 0; i < lista.Count; i++)
        lista[i] *= 2;
    sw.Stop();
    Console.WriteLine($"Novo array após a duplicação: [{string.Join(",", lista)}]");
    Console.WriteLine($"Tempo para duplicar cada elemento: {sw.ElapsedMilliseconds}ms\n");
}

void DuplicateFirstElement(List<double> lista)
{
    sw.Reset();
    sw.Start();
    lista[0] *= 2;
    sw.Stop();
    Console.WriteLine($"Novo array após a duplicação do primeiro elemento: [{string.Join(",", lista)}]");
    Console.WriteLine($"Tempo para duplicar o primeiro elemento: {sw.ElapsedMilliseconds}ms\n");
}

void CreateMultiplicationTable(List<double> lista)
{
    sw.Reset();
    sw.Start();
    double[,] multTable = new double[lista.Count, lista.Count];
    for (int i = 0; i < lista.Count; i++)
        for (int j = 0; j < lista.Count; j++)
            multTable[i, j] = lista[i] * lista[j];

    sw.Stop();
    Console.WriteLine("Tabela de multiplicação:");
    for (int i = 0; i < lista.Count; i++)
    {
        for (int j = 0; j < lista.Count; j++)
            Console.Write($"{multTable[i, j]} ");
        Console.WriteLine();
    }
    Console.WriteLine($"Tempo para criar tabela de multiplicação: {sw.ElapsedMilliseconds}ms\n");
}
