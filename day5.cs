//day 5

class Day5
{
    public static void solve()
    {
        var data = getInput();

        int nextIndex = 0;
        int currentIndex = 0;
        int counter = 0;

        while(nextIndex < data.Length && nextIndex >= 0)
        {
            currentIndex = nextIndex;
            nextIndex = currentIndex + data[currentIndex];

            if(data[currentIndex] >= 3) data[currentIndex]--;
            else data[currentIndex]++;
            
            counter++;
        }

        System.Console.WriteLine("Day 5: " + counter);
    }

    static int[] getInput()
    {
        string text = System.IO.File.ReadAllText(@"C:\Users\JMacfarland\adventOfCode2017\day5_input.txt");
        string[] temp = text.Split('\n');
        int[] data = new int[temp.Length];

        for(int i = 0; i < temp.Length; i++)
        {
            if(int.TryParse(temp[i], out data[i]) == false)
            {
                System.Console.WriteLine("Discrepancy in the file! Does it only contain numbers and newlines?");
                break;   
            }
        }

        return data;
    }
}