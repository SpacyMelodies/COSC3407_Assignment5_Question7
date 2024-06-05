
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("reference set 1 = { 140, 1751, 222, 47, 526, 1341, 2458, 327 }");
        Console.WriteLine("FCFS with reference set 1 total moves = " + FCFS(3000, 97, new[] { 140, 1751, 222, 47, 526, 1341, 2458, 327 }));
        Console.WriteLine("SSTF with reference set 1 total moves = " + SSTF(3000, 97, new[] { 140, 1751, 222, 47, 526, 1341, 2458, 327 }));
        Console.WriteLine("SCAN with reference set 1 total moves = " + SCAN(3000, 97, new[] { 140, 1751, 222, 47, 526, 1341, 2458, 327 }, 125));
        Console.WriteLine("CSCAN with reference set 1 total moves = " + CSCAN(3000, 97, new[] { 140, 1751, 222, 47, 526, 1341, 2458, 327 }, 125));
        Console.WriteLine();
        Console.WriteLine("reference set 2 = { 111, 1167, 19, 79, 2, 1211, 47, 999, 453, 921, 1131 }");
        Console.WriteLine("FCFS with reference set 2 total moves = " + FCFS(1250, 1051, new[] { 111, 1167, 19, 79, 2, 1211, 47, 999, 453, 921, 1131 }));
        Console.WriteLine("SSTF with reference set 1 total moves = " + SSTF(1250, 1051, new[] { 111, 1167, 19, 79, 2, 1211, 47, 999, 453, 921, 1131 }));
        Console.WriteLine("SCAN with reference set 1 total moves = " + SCAN(1250, 1051, new[] { 111, 1167, 19, 79, 2, 1211, 47, 999, 453, 921, 1131 }, 900));
        Console.WriteLine("CSCAN with reference set 1 total moves = " + CSCAN(1250, 1051, new[] { 111, 1167, 19, 79, 2, 1211, 47, 999, 453, 921, 1131 }, 900));
       
        Console.ReadLine();
    }

    private static int CSCAN(int cylinders, int startingPosition, int[] queue, int lastInput)
    {
        int loops = 0;
        bool direction;
        if (lastInput > startingPosition)
        {
            direction = false;
            loops = queue.Length;
        }
        else
        {
            direction = true;
            loops = queue.Length + 1;
        }
        int moveSum = 0;
        int endVal = 0;
        int nextNumber = 0;
        for (int i = 0; i < loops; i++)
        {
            int smallestDistance = int.MaxValue;
            nextNumber = 0;
            for (int j = 0; j < queue.Length; j++)
            {
                if (queue[j] == startingPosition)
                {
                    queue[j] = 0;
                }
                if (queue[j] != 0)
                {
                    if (direction == false) //left
                    {
                        endVal = startingPosition - 0;
                        if (queue[j] < startingPosition)
                        {
                            int comparison = Math.Max(startingPosition, queue[j]) - Math.Min(startingPosition, queue[j]);
                            if (comparison < smallestDistance)
                            {
                                smallestDistance = comparison;
                                nextNumber = queue[j];
                            }
                        }

                    }
                    else //right
                    {
                        endVal = startingPosition - 0;
                        if (queue[j] > startingPosition)
                        {
                            endVal = Math.Max(startingPosition, (cylinders - 1)) - Math.Min(startingPosition, (cylinders - 1));
                            int comparison = Math.Max(startingPosition, queue[j]) - Math.Min(startingPosition, queue[j]);
                            if (comparison < smallestDistance)
                            {
                                smallestDistance = comparison;
                                nextNumber = queue[j];
                            }
                        }
                    }
                }
            }
            if (direction == false && smallestDistance == int.MaxValue)
            {
                smallestDistance = startingPosition + queue.Max();
                nextNumber = queue.Max();
            }
            if (direction == true && nextNumber == 0)
            {
                smallestDistance = ((cylinders - 1) - startingPosition) + (cylinders - 1);
                nextNumber = (queue.Min());
            }
            moveSum += smallestDistance;
            startingPosition = nextNumber;
        }
        if (direction == false)
        {
            return moveSum;
        }
        return moveSum;
    }

    private static int SCAN(int cylinders, int startingPosition, int[] queue, int lastInput) 
    {
        bool direction;
        if (lastInput > startingPosition)
        {
            direction = false;
        }
        else
        {
            direction = true;
        }

        int moveSum = 0;
        int endVal = 0;

        for (int i = 0; i < queue.Length + 1; i++)
        {
            int smallestDistance = int.MaxValue;
            int nextNumber = 0;
            for (int j = 0; j < queue.Length; j++)
            {
                if (queue[j] == startingPosition)
                {
                    queue[j] = 0;
                }
                if (queue[j] != 0)
                {
                    if (direction == false) //left
                    {
                        endVal = startingPosition - 0;
                        if (queue[j] < startingPosition)
                        {
                            int comparison = Math.Max(startingPosition, queue[j]) - Math.Min(startingPosition, queue[j]);
                            if (comparison < smallestDistance)
                            {
                                smallestDistance = comparison;
                                nextNumber = queue[j];
                            }
                        }
                        
                    }
                    else //right
                    {
                        if (queue[j] > startingPosition)
                        {
                            endVal = startingPosition - 0;
                            int comparison = Math.Max(startingPosition, queue[j]) - Math.Min(startingPosition, queue[j]);
                            if (comparison < smallestDistance)
                            {
                                smallestDistance = comparison;
                                nextNumber = queue[j];
                            }
                        }                      
                    }                
                }
            }
            if (smallestDistance > endVal && nextNumber == 0)
            {
                if (direction == false)
                {
                    smallestDistance = endVal;
                }   
                else
                {
                    smallestDistance = startingPosition - queue.Max();
                    nextNumber = queue.Max();
                }

                direction = !direction;
            }
            moveSum += smallestDistance;
            startingPosition = nextNumber;
        }
        if (startingPosition == 0)
        {
            return moveSum - endVal;
        }
        return moveSum;
    }

    private static int SSTF(int cylinders, int startingPosition, int[] queue)
    {
        int moveSum = 0;

        for (int i = 0; i < queue.Length; i++)
        {
            int smallestDistance = int.MaxValue;
            int nextNumber = 0;
            for (int j = 0; j < queue.Length; j++)
            {
                if (queue[j] == startingPosition)
                {
                    queue[j] = 0;
                }
                if (queue[j] != 0)
                {
                    int comparison = Math.Max(startingPosition, queue[j]) - Math.Min(startingPosition, queue[j]);
                    if (comparison < smallestDistance)
                    {
                        smallestDistance = comparison;
                        nextNumber = queue[j];
                    }
                }
            }
            moveSum += smallestDistance;
            startingPosition = nextNumber;
        }
        return moveSum;
    }

    private static int FCFS(int cylinders, int startingPosition, int[] queue)
    {
        int moveSum = 0;

        for (int i = 0; i < queue.Length; i++)
        {
            if (i == 0)
            {
                moveSum += Math.Max(startingPosition, queue[i]) - Math.Min(startingPosition, queue[i]);
            }
            else
            {
                moveSum += Math.Max(queue[i - 1], queue[i]) - Math.Min(queue[i - 1], queue[i]);
            }
        }
        return moveSum;
    }

}