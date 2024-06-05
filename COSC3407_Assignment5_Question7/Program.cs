
internal class Program
{
    private static void Main(string[] args)
    {
        int cylinders = 3000;
        int startingPosition = 97;
       List<int> queue2 = new List<int> { 111, 1167, 19, 79, 2, 1211, 47, 999, 453, 921, 1131 };
        queue2.Sort();
        int[] queue = { 140, 1751, 222, 47, 526, 1341, 2458, 327 };
        int max = queue.Max();
        int result1FCFS = FCFS(cylinders, startingPosition, new[]{ 140, 1751, 222, 47, 526, 1341, 2458, 327 });
        int result1SSTF = SSTF(cylinders, startingPosition, new[] { 140, 1751, 222, 47, 526, 1341, 2458, 327 });
        int result1SCAN = SCAN(cylinders, startingPosition, new[] { 140, 1751, 222, 47, 526, 1341, 2458, 327 }, 125);
        int result1CSCAN = CSCAN(cylinders, startingPosition, new[] { 140, 1751, 222, 47, 526, 1341, 2458, 327 }, 125);
        
/*        int result2FCFS = FCFS(1250, 1051, new[] { 111, 1167, 19, 79, 2, 1211, 47, 999, 453, 921, 1131 });
        int result2SSTF = SSTF(1250, 1051, new[] { 111, 1167, 19, 79, 2, 1211, 47, 999, 453, 921, 1131 });
        int result2SCAN = SCAN(1250, 1051, new[] { 111, 1167, 19, 79, 2, 1211, 47, 999, 453, 921, 1131 }, 900);
        int result2CSCAN = CSCAN(1250, 1051, new[] { 111, 1167, 19, 79, 2, 1211, 47, 999, 453, 921, 1131 }, 900);*/
        Console.ReadLine();
        ;
        /*        SCAN(cylinders, startingPosition, queue);
                CSCAN(cylinders, startingPosition, queue);*/
    }

    private static int CSCAN(int cylinders, int startingPosition, int[] queue, int lastInput)
    {
        int moveSum = 0;
        int endVal = 0;
        bool direction = false;
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
            if (direction == false && endVal == startingPosition)
            {
                smallestDistance = startingPosition + queue.Max();              
            }
            if (direction == true && endVal == startingPosition)
            {
                smallestDistance = ((cylinders - 1) - startingPosition) + cylinders - 1;
            }
            moveSum += smallestDistance;
            startingPosition = nextNumber;
        }
        return moveSum;
    }

    private static int SCAN(int cylinders, int startingPosition, int[] queue, int lastInput) // DEV NOTE : gotta figure out a way to ge tthsi algo working
    {
        int moveSum = 0;
        int endVal = 0;
        bool direction = false;
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
                smallestDistance = endVal;
                direction = !direction;
            }
            moveSum += smallestDistance;
            startingPosition = nextNumber;
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

    enum DIRECTION
    {
        LEFT = 0,
        RIGHT = 1
    }
}