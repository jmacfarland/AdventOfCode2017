using System;
public class Point
{
	private float _x;
	private float _y;

	public Point (int x = 0, int y = 0)
	{
		this._x = x;
		this._y = y;
	}

	public Point (float x, float y)
	{
		this._x = x;
		this._y = y;
	}

	public Point clone()
	{
		return new Point (this._x, this._y);
	}

	//adds the position of the argument point to the position of this point
	public void add(Point right)
	{
		this.changeX(right.x());
		this.changeY(right.y());
	}

	public void setPos(int x, int y)
	{
		this._x = x;
		this._y = y;
	}

	public void changeX(float value)
	{
		this._x += value;
	}

	public void changeY(float value)
	{
		this._y += value;
	}

	public float x()
	{
		return this._x;
	}

	public float y()
	{
		return this._y;
	}

	override public string ToString ()
	{
		string result = "(" + this._x + ", " + this._y + ")";
		return result;
	}
}

public class Point3d
{
	private float _x;
	private float _y;
	private float _z;

	public Point3d (int x = 0, int y = 0, int z = 0)
	{
		this._x = x;
		this._y = y;
	}

	public Point3d (float x, float y, float z)
	{
		this._x = x;
		this._y = y;
	}

	public Point3d clone()
	{
		return new Point3d (this._x, this._y, this._z);
	}

	//adds the position of the argument point to the position of this point
	public void add(Point3d right)
	{
		this.changeX(right.x());
		this.changeY(right.y());
		this.changeZ(right.z());
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

	public void changeX(float value)
	{
		this._x += value;
	}

	public void changeY(int value)
	{
		this._y += value;
	}

	public void changeY(float value)
	{
		this._y += value;
	}

	public void changeZ(int value)
	{
		this._z += value;
	}

	public void changeZ(float value)
	{
		this._z += value;
	}

	public float x()
	{
		return this._x;
	}

	public float y()
	{
		return this._y;
	}

	public float z()
	{
		return this._z;
	}

	override public string ToString ()
	{
		string result = "(" + this._x + ", " + this._y + ", " + this._z + ")";
		return result;
	}
}

