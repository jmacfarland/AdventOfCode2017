using System;
using System.Collections.Generic;

class Day8
{
    public static void solve()
    {
        var data = Utils.getInput("Day8_input.txt", false);
        int highestEver = 0;
        IDictionary<string, int> registers = new Dictionary<string, int>();

        foreach(string[] strArr in data)
        {
            Console.WriteLine();
            var modRegister = Utils.sanitize(strArr[0]);
            int modValue = int.Parse(strArr[2]);
            var checkRegister = Utils.sanitize(strArr[4]);
            int checkValue = int.Parse(strArr[6]);
            int incrementOrDecrement = getIncDec(strArr[1]);

            //Console.Write(modRegister + " " + modValue + " " + checkRegister + " " + checkValue + " " + incrementOrDecrement);

            //if we haven't previously seen the referenced registers, initialize them to 0
            if(!registers.ContainsKey(modRegister)) registers.Add(modRegister, 0);
            if(!registers.ContainsKey(checkRegister)) registers.Add(checkRegister, 0);

            bool conditionIsMet = false;
            switch(strArr[5])
            {
                case "<":
                    if(registers[checkRegister] < checkValue) conditionIsMet = true;
                    break;
                case ">":
                    if(registers[checkRegister] > checkValue) conditionIsMet = true;
                    break;
                case "==":
                    if(registers[checkRegister] == checkValue) conditionIsMet = true;
                    break;
                case "!=":
                    if(registers[checkRegister] != checkValue) conditionIsMet = true;
                    break;
                case ">=":
                    if(registers[checkRegister] >= checkValue) conditionIsMet = true;
                    break;
                case "<=":
                    if(registers[checkRegister] <= checkValue) conditionIsMet = true;
                    break;
                default:
                    Console.WriteLine("Not a valid comparator!");
                    break;
            }

            if(conditionIsMet)
            {
                registers[modRegister] += modValue * incrementOrDecrement;
                if(registers[modRegister] > highestEver) highestEver = registers[modRegister];
                //Console.WriteLine(modRegister + " " + modValue + " " + incrementOrDecrement);
            }
        }
        int highest = 0;
        foreach(var entry in registers)
        {
            if(entry.Value > highest) highest = entry.Value;
        }
        Console.WriteLine(highestEver);//highest => at end of run; highestEver => highest at any point during run
    }

    //if we need to increment, just multiply the amount by 1.
    //if we need to decrement, multiply it by -1.
    static int getIncDec(string str)
    {
        str = Utils.sanitize(str);

        if(str.Equals("inc")) return 1;
        else if(str.Equals("dec")) return -1;
        else{
            Console.WriteLine("Could not determine increment or decrement!");
            return 0;
        }
    }
}