using System;

class Day11
{
    public static void solve()
    {
        string[] input = Utils.getInputString("day11_input.txt").Split(',');
        Point3d currentPosition = new Point3d();
        Point3d farthestPosition = new Point3d();

        foreach(string direction in input)
        {
            switch(direction)
            {
                case "n":
                    currentPosition.changeZ(-1);
                    currentPosition.changeY(1);
                    break;
                case "ne":
                    currentPosition.changeX(1);
                    currentPosition.changeZ(-1);
                    break;
                case "se":
                    currentPosition.changeY(-1);
                    currentPosition.changeX(1);
                    break;
                case "s":
                    currentPosition.changeZ(1);
                    currentPosition.changeY(-1);
                    break;
                case "sw":
                    currentPosition.changeX(-1);
                    currentPosition.changeZ(1);
                    break;
                case "nw":
                    currentPosition.changeY(1);
                    currentPosition.changeX(-1);
                    break;
            }

            if(currentPosition.getLargestAbsCoordinate() > farthestPosition.getLargestAbsCoordinate())
            {
                Console.WriteLine("New farthest: " + currentPosition.ToString());
                farthestPosition.assign(currentPosition);
            }
        }

        Console.WriteLine(currentPosition.ToString());
        Console.WriteLine(farthestPosition.ToString());
    }
}