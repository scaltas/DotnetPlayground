using System.Diagnostics;

const int numberOfSteps = 100_000_000;

Console.WriteLine("Function               | Elapsed Time     | Estimated Pi");
Console.WriteLine("-----------------------------------------------------------------");

Time(SerialLinqPi, nameof(SerialLinqPi));

static void Time(Func<double> estimatePi, string function)
{
    var sw = Stopwatch.StartNew();
    var pi = estimatePi();
    Console.WriteLine($"{function.PadRight(22)} | {sw.Elapsed} | {pi}");
}

//Pi = 4/1 - 4/3 + 4/5 - 4/7 + 4/9 - 4/11...

static double SerialLinqPi()
{
    double step = 1.0 / (double)numberOfSteps;
    return (from i in Enumerable.Range(0, numberOfSteps)
        let x = (i + 0.5) * step
        select 4.0 / (1.0 + x * x)).Sum() * step;
}