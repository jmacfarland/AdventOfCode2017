using System;
using System.Collections.Generic;

namespace AdventOfCodemono
{
	public class Day3
	{
		public static void solve()
		{
			IDictionary<string, int> points = new Dictionary<string, int> ();
			int targetValue = 361527;
			//int targetValue = 10;

			int value = 1;
			int currentSegmentLength = 1;
			int currentSegmentPos = 0;
			int direction = 0; //0=RIGHT, 1=UP, 2=LEFT, 3=DOWN
			Point currentPos = new Point(0, 0);
			points.Add (currentPos.ToString(), value);

			//loop while lastValue < targetValue
			while(value < targetValue)
			{
				//if we've reached a 'corner' and need to change directions
				if(currentSegmentPos == currentSegmentLength)
				{
					//increment direction
					direction = (direction + 1) % 4;

					//reset currentSegmentPos
					currentSegmentPos = 0;

					//if need be, increment currentSegmentLength
					if(direction % 2 == 0)
					{
						currentSegmentLength++;
					}
				}

				switch(direction){
				case 0:
					currentPos.changeX (1);
					break;
				case 1:
					currentPos.changeY (1);
					break;
				case 2:
					currentPos.changeX (-1);
					break;
				case 3:
					currentPos.changeY (-1);
					break;
				}
					
				value = findValue (currentPos, points);

				points.Add (currentPos.ToString(), value);
				Console.WriteLine (currentPos.ToString() + ": " + value);
					
				currentSegmentPos++;
			}
		}

		public static int findValue(Point currentPos, IDictionary<string, int> points)
		{
			//update value
			int value = 0;
			int temp = 0;
			Point tempPoint = new Point ();
			for(int x = -1; x < 2; x++)
			{
				for(int y = -1; y < 2; y++)
				{
					if(x != 0 || y != 0)
					{
						//don't process current pos, only ones around it
						tempPoint.setPos (currentPos.x() + x, currentPos.y() + y);
						//Console.WriteLine ("checking " + tempPoint.ToString ());
						if(points.TryGetValue (tempPoint.ToString (), out temp))
						{
							value += temp;
							//Console.WriteLine ("Found point at: " + tempPoint.ToString () + ", value: " + temp);
						}
					}
				}
			}

			//Console.WriteLine (value);
			return value;
		}
	}
}

