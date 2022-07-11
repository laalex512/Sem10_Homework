/*Задача 73: Есть число N. Сколько групп M, можно получить при разбиении всех чисел на группы, 
так чтобы в одной группе все числа в группе друг на друга не делились? 
Найдите M при заданном N и получите одно из разбиений на группы N ≤ 10²⁰.
Например, для N = 50, M получается 6
Группа 1: 1
Группа 2: 2 3 11 13 17 19 23 29 31 37 41 43 47
Группа 3: 4 6 9 10 14 15 21 22 25 26 33 34 35 38 39 46 49
Группа 4: 8 12 18 20 27 28 30 42 44 45 50
Группа 5: 7 16 24 36 40
Группа 6: 5 32 48

Группа 1: 1
Группа 2: 2 3 5 7 11 13 17 19 23 29 31 37 41 43 47
Группа 3: 4 6 9 10 14 15 21 22 25 26 33 34 35 38 39 46 49
Группа 4: 8 12 18 20 27 28 30 42 44 45 50
Группа 5: 16 24 36 40
Группа 6: 32 48*/


long[] StringToArrayNumbers(string input)
{
    long countNumbers = 0;

    for (int i = 0; i < input.Length; i++)
    {
        if(input[i] == ' ')
        {
            countNumbers++;
        }
    }

    long[] numbers = new long[countNumbers];
    int index = 0;

    for (int i = 0; i < input.Length; i++)
    {
        string tempString = "";

        while(input[i] != ' ')
        {
            if(i != input.Length - 1)
            {
                tempString += input[i].ToString();
                i++;
            }
            else
            {
                tempString += input[i].ToString();
                break;
            }
        }
        numbers[index] = Convert.ToInt32(tempString);
        index++;
    }

    return numbers;
}

//  проверка числа на предмет его деления на числа из строки. 
//true - значит не делится ни на одно число из строки
bool NumbersAreNotDivided(string line, long num)
{

    bool flag = true;

    if (line.Length > 0)
    {
        long[] arrayNumsLine = StringToArrayNumbers(line);
        for (int i = 0; i < arrayNumsLine.Length; i++)
        {
            if (arrayNumsLine[i] > 0 && num % arrayNumsLine[i] == 0)
                flag = false;
        }
        return flag;
    }
    else return flag;
}

long n = 50;
long[] arrayN = new long[n];

for (long i = 0; i < n; i++)
{
    arrayN[i] = i + 1;
}

string[] result = new string[n];

for (int i = 0; i < result.Length; i++)
{
    string str = string.Empty;                                            // компилятор не разрешил напрямую изменять result[i]
    for (long j = 0; j < arrayN.Length; j++)
    {
        if (arrayN[j] > 0 && NumbersAreNotDivided(str, arrayN[j]))
        {
            str += Convert.ToString(arrayN[j]);
            str += ' ';
            arrayN[j] = 0;
        }

    }
    result[i] += str;
}

long m = 0;

for (int i = 0; i < result.Length; i++)
{
    if (result[i] != "")
        m++;
}

Console.WriteLine($"M = {m}");

for (int i = 0; i < m; i++)
{
        Console.WriteLine($"Group {i+1}: {result[i]}");
}