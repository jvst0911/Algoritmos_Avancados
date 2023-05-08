int[] arr = { 5, 4, 3, 2, 1 };

void MergeSort(int[] arr, int left, int right)
{
    if (left >= right)
        return;

    int middle = (left + right) / 2;
    Thread leftThread = new Thread(() => MergeSort(arr, left, middle));
    leftThread.Start();

    MergeSort(arr, middle + 1, right);
    leftThread.Join();

    Merge(arr, left, middle, right);
}

void Merge(int[] arr, int left, int middle, int right)
{
    int[] temp = new int[arr.Length];
    int i, j, k;

    for (i = left, j = middle + 1, k = left; i <= middle && j <= right; k++)
    {
        if (arr[i] <= arr[j])
            temp[k] = arr[i++];
        else
            temp[k] = arr[j++];
    }

    while (i <= middle)
        temp[k++] = arr[i++];

    while (j <= right)
        temp[k++] = arr[j++];

    for (i = left; i <= right; i++)
        arr[i] = temp[i];
}

MergeSort(arr, 0, arr.Length - 1);

Console.Write(string.Join("\\d", arr));

