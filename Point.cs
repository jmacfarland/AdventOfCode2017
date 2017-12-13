using System;
public class Point
{
	private float _x;
	private float _y;

	public Point (float x = 0, float y = 0)
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

	public void setPos(float x, float y)
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

	public Point3d (float x = 0, float y = 0, float z = 0)
	{
		this._x = x;
		this._y = y;
		this._z = z;
	}

	public void assign(Point3d point)
	{
		this._x = point.x();
		this._y = point.y();
		this._z = point.z();
	}

	//adds the position of the argument point to the position of this point
	public void add(Point3d right)
	{
		this.changeX(right.x());
		this.changeY(right.y());
		this.changeZ(right.z());
	}

	public void setPos(float x, float y, float z)
	{
		this._x = x;
		this._y = y;
		this._z = z;
	}

	public void changePos(float x, float y, float z)
	{
		this._x += x;
		this._y += y;
		this._z += z;
	}

	public void changeX(float value)
	{
		this._x += value;
	}

	public void changeY(float value)
	{
		this._y += value;
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

	public float getLargestAbsCoordinate()
	{
		float highest = 0;

		if(Math.Abs(this._x) > highest) highest = Math.Abs(this._x);
		if(Math.Abs(this._y) > highest) highest = Math.Abs(this._y);
		if(Math.Abs(this._z) > highest) highest = Math.Abs(this._z);
	
		return highest;
	}

	override public string ToString ()
	{
		string result = "(" + this._x + ", " + this._y + ", " + this._z + ")";
		return result;
	}
}

