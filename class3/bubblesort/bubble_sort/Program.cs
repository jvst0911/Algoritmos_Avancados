using System.Runtime.Intrinsics.X86;

sort();
static void bubblesort_string()
{
    string[] arr = { "banana", "apple", "pear", "orange", "grape" };
    int n = arr.Length;
    bool swapped = true;

    while (swapped)
    {
        swapped = false;
        for (int i = 1; i < n; i++)
        {
            if (arr[i - 1].CompareTo(arr[i]) > 0)
            {
                string temp = arr[i];
                arr[i] = arr[i - 1];
                arr[i - 1] = temp;
                swapped = true;
            }
        }
        n--;
    }
    Console.WriteLine(string.Join(",", arr));
}

static void bubblesort_numbers()
{
    var range = new List<int> { 1, 4, 6, 7, 10, 2, 3, 5, 8, 9 };
    var limit = range.Count() - 1;

    for (int i = 0; i < limit; i++)
    {
        while (range[i] > range[i + 1])
        {
            int aux = range[i];
            range[i] = range[i + 1];
            range[i + 1] = aux;
            i--;
        }
    }
    Console.WriteLine(string.Join(",", range));
}

static void quicksort()
{
    string[] arr = { "banana", "apple", "pear", "orange", "grape" };
    quicksort(arr, 0, arr.Length - 1);
    foreach (string fruit in arr)
    {
        Console.Write(fruit + " ");
    }

    void quicksort(string[] arr, int left, int right)
    {
        if (left < right)
        {
            int pivot = partition(arr, left, right);
            quicksort(arr, left, pivot - 1);
            quicksort(arr, pivot + 1, right);
        }
    }

    int partition(string[] arr, int left, int right)
    {
        string pivot = arr[right];
        int i = left - 1;
        for (int j = left; j < right; j++)
        {
            if (arr[j].CompareTo(pivot) >= 0)
            {
                i++;
                string temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }
        string temp2 = arr[i + 1];
        arr[i + 1] = arr[right];
        arr[right] = temp2;
        return i + 1;
    }
}