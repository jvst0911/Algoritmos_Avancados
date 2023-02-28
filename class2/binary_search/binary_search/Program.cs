
Print($"Select a range for element list:");
if (!int.TryParse(Console.ReadLine(), out var range))
    throw new InvalidDataException("Only numbers allowed.");

if (range > 10000000)
    throw new InvalidDataException("Data limit is 10000000");

Print("Select an element to find on the list: (the first element is 1)");

if (!long.TryParse(Console.ReadLine(), out long searchKey))
    throw new InvalidDataException("Only numbers allowed.");

if (searchKey > range)
{
    Print("Valor não encontrado.");
    return;
}

long[] data = new long[range];

for (int i = 1; i < data.Length; i++)
    data[i] = i + 1;

Print(string.Join(',', data));

Print("-====== Recursivo ======-");

int index = BinarySearch(0, data.Length - 1, searchKey);
if (index == -1)
    Print("Valor não encontrado");
else
    Print("O elemento " + searchKey + " está no índice " + index);
Print("-====== Recursivo ======-");


Print("\n-====== While ======-");
var ini = 0;
var fim = data.Length - 1;

var resultado = string.Empty;
while (ini < fim)
{
    int meio = (ini + fim) / 2;

    if (data[meio] == searchKey)
    {
        resultado = ("O elemento " + searchKey + " está no índice " + meio);
        break;
    }
    else if (data[meio] < searchKey)
        ini = meio + 1;
    else
        fim = meio - 1;
};
if (string.IsNullOrWhiteSpace(resultado))
    Print("Valor não encontrado.");
else
    Print(resultado);
Print("-====== While ======-");

int BinarySearch(int low, int high, long searchKey)
{
    if (low > high)
        return -1;

    int mid = (low + high) / 2;

    if (data[mid] == searchKey)
        return mid;
    else if (data[mid] < searchKey)
        return BinarySearch(mid + 1, high, searchKey);
    else
        return BinarySearch(low, mid - 1, searchKey);
}

void Print(object obj) => Console.WriteLine(obj);
