using System.IO.Pipes;

int i = 0;

// Add the /unsafe flag to enable unsafe code
// /unsafe
unsafe
{
    int* ptr = &i;
    ref int iref = ref *ptr;
}


static void Use(ref int reference, int lentgth)
{

}