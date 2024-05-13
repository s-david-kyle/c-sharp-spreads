int[] array = { 1, 2, 3, 4, 5 };

ReadOnlySpan<int> span = [42, 43, 44];



Console.WriteLine(Sum(array));
Console.WriteLine(Sum(new Span<int>(array)));



static int Sum(Span<int> array)
{
    int sum = 0;
    foreach (int i in array)
    {
        sum += i;
    }
    return sum;
}



