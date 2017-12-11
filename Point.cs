using System;

namespace AdventOfCodemono
{
	public class Point
	{
		private int _x;
		private int _y;

		public Point (int x = 0, int y = 0)
		{
			this._x = x;
			this._y = y;
		}

		public Point clone()
		{
			return new Point (this._x, this._y);
		}

		public void setPos(int x, int y)
		{
			this._x = x;
			this._y = y;
		}

		public void changeX(int value)
		{
			this._x += value;
		}

		public void changeY(int value)
		{
			this._y += value;
		}

		public int x()
		{
			return this._x;
		}

		public int y()
		{
			return this._y;
		}

		override public string ToString ()
		{
			string result = "(" + this._x + ", " + this._y + ")";
			return result;
		}
	}
}

