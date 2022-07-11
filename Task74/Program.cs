/*Дополнительная задача 74*: 4 друга должны посетить 12 пабов, в котором выпить по британской пинте пенного напитка.
 До каждого бара идти примерно 15-20 минут, каждый пьет пинту за 15 минут.
  У первого друга лимит выпитого 1.1 литра, у второго 1.5, у третьего 2.2 литра, у 4 - 3.3 литра, это их максимум. 
  Необходимо выяснить, до скольки баров смогут дойти каждый из друзей(Пройденное расстояние (в барах)), пока не упадет. 
  И сколько всего времени будет потрачено на выпивку.*/


int RoundingPubs(double canDrink)                     // округление пинт в количество пабов
{
    int result = 0;
    for (int i = 1; i < canDrink; i++)
    {
        result = i + 1;
    }
    return result;
}

int ArrayMaxCount(int[] a)                            // нахождение максимума из массива
{
    int max = a[0];
    for (int i = 1; i < a.Length; i++)
    {
        if (a[i] > max)
            max = a[i];
    }
    return max;
}



int countFriends = 4;
int minTimeWalk = 15;
int maxTimeWalk = 20;
int timeDrink = 15;

double coefficientLitrToPint = 0.568;

double[] arrayCanDrink = new double[countFriends];

arrayCanDrink[0] = 1.1;
arrayCanDrink[1] = 1.5;
arrayCanDrink[2] = 2.2;
arrayCanDrink[3] = 3.3;

int[] arrayCountPubs = new int[countFriends];

for (int i = 0; i < arrayCountPubs.Length; i++)
{
    arrayCountPubs[i] = RoundingPubs(arrayCanDrink[i] / coefficientLitrToPint);
    Console.WriteLine($"{i + 1} friend get to the {arrayCountPubs[i]} pub ");
}

int maxPubToGet = ArrayMaxCount(arrayCountPubs);

int totalDrinkTime = maxPubToGet * timeDrink + (maxPubToGet - 1) * ((new Random().Next(minTimeWalk, maxTimeWalk+1)));

Console.WriteLine($"Total time to drink - {totalDrinkTime} min");