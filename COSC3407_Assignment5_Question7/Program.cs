
internal class Program
{
    private static void Main(string[] args)
    {
        int cylinders = 3000;
        int startingPosition = 97;
        int[] queue = { 140, 1751, 222, 47, 526, 1341, 2458, 327 };
        int result = FCFS(cylinders, startingPosition, queue);
        int result2 = SSTF(cylinders, startingPosition, queue);
        SCAN(cylinders, startingPosition, queue);
        Console.WriteLine(result);
        Console.ReadLine();
        ;
        /*        SCAN(cylinders, startingPosition, queue);
                CSCAN(cylinders, startingPosition, queue);*/
    }

    private static int CSCAN(int cylinders, int startingPosition, int[] queue, int lastInput)
    {
        throw new NotImplementedException();
    }

    private static int SCAN(int cylinders, int startingPosition, int[] queue, int lastInput) // DEV NOTE : gotta figure out a way to ge tthsi algo working
    {
        Enum direction = DIRECTION.LEFT; //used an enum for readability
        if (lastInput > startingPosition)
        {
            direction = DIRECTION.LEFT;
        }
        else
        {
            direction = DIRECTION.RIGHT;
        }

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
                    if (direction is DIRECTION.LEFT)
                    {
                        if (queue[j] < startingPosition)
                        {
                            int comparison = Math.Max(startingPosition, queue[j]) - Math.Min(startingPosition, queue[j]);
                            if (comparison < smallestDistance)
                            {
                                smallestDistance = comparison;
                                nextNumber = queue[j];
                            }
                            if(nextNumber == 0)
                            {
                                direction = DIRECTION.RIGHT;
                            }
                        }

                    }
                }
            }
        }
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