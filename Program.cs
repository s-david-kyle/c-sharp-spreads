using System.Runtime.CompilerServices;

int i = 42;
var span = new MySpan<int>(ref i);
span[0] = 43;
Console.WriteLine(i); // 1

var anotherSpan = new MySpan<char>("Hello".ToCharArray());
Console.WriteLine(anotherSpan[0]); // H
while (anotherSpan.Length > 0)
{
    Console.WriteLine(anotherSpan[0]);
    anotherSpan = anotherSpan.Slice(1);
}

readonly ref struct MySpan<T>
{
    private readonly ref T _reference;
    private readonly int _length;

    public int Length => _length;

    public MySpan(T[] array)
    {
        _reference = ref array[0];
        _length = array.Length;
    }

    public MySpan(ref T reference)
    {
        _reference = ref reference;
        _length = 1;
    }

    public MySpan(ref T reference, int length)
    {
        _reference = ref reference;
        _length = length;
    }

    public ref T this[int index]
    {
        get
        {
            if (index >= _length)
            {
                throw new IndexOutOfRangeException();
            }

            return ref Unsafe.Add(ref _reference, index);
        }

    }

    public MySpan<T> Slice(int offset)
    {
        if (offset > _length)
        {
            throw new IndexOutOfRangeException();
        }

        return new MySpan<T>(ref Unsafe.Add(ref _reference, offset), _length - offset);
    }


}

readonly ref struct MyReadOnlySpan<T>
{
    private readonly ref T _reference;
    private readonly int _length;

    public int Length => _length;

    public MyReadOnlySpan(T[] array)
    {
        _reference = ref array[0];
        _length = array.Length;
    }

    public MyReadOnlySpan(ref T reference)
    {
        _reference = ref reference;
        _length = 1;
    }

    public MyReadOnlySpan(ref T reference, int length)
    {
        _reference = ref reference;
        _length = length;
    }

    public ref readonly T this[int index]
    {
        get
        {
            if (index >= _length)
            {
                throw new IndexOutOfRangeException();
            }

            return ref Unsafe.Add(ref _reference, index);
        }

    }

    public MyReadOnlySpan<T> Slice(int offset)
    {
        if (offset > _length)
        {
            throw new IndexOutOfRangeException();
        }

        return new MyReadOnlySpan<T>(ref Unsafe.Add(ref _reference, offset), _length - offset);
    }
}
