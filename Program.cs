// See https://aka.ms/new-console-template for more information
using System.Threading.Tasks.Dataflow;

Console.WriteLine("Hello, World!");
static int Sum(Span<int> array)
{
    int sum = 0;
    foreach (int i in array)
    {
        sum += i;
    }
    return sum;
}
int[] array = { 1, 2, 3, 4, 5 };

Console.WriteLine(Sum(array));
Console.WriteLine(Sum(new Span<int>(array)));


