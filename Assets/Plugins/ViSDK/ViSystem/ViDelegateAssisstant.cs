using System;

public class ViDelegateAssisstant
{
	public delegate void Dele();
	public delegate void Dele<T0>(T0 t0);
	public delegate void Dele<T0, T1>(T0 t0, T1 t1);
	public delegate void Dele<T0, T1, T2>(T0 t0, T1 t1, T2 t2);
	public delegate void Dele<T0, T1, T2, T3>(T0 t0, T1 t1, T2 t2, T3 t3);
	public delegate RT RTDele<RT>();
	public delegate RT RTDele<RT, T0>(T0 t0);
	public delegate RT RTDele<RT, T0, T1>(T0 t0, T1 t1);
	public delegate RT RTDele<RT, T0, T1, T2>(T0 t0, T1 t1, T2 t2);
	public delegate RT RTDele<RT, T0, T1, T2, T3>(T0 t0, T1 t1, T2 t2, T3 t3);

	public static void Invoke(Dele dele)
	{
		if (dele != null)
		{
			dele();
		}
	}

	public static void Invoke<T0>(Dele<T0> dele, T0 t0)
	{
		if (dele != null)
		{
			dele(t0);
		}
	}

	public static void Invoke<T0, T1>(Dele<T0, T1> dele, T0 t0, T1 t1)
	{
		if (dele != null)
		{
			dele(t0, t1);
		}
	}

	public static void Invoke<T0, T1, T2>(Dele<T0, T1, T2> dele, T0 t0, T1 t1, T2 t2)
	{
		if (dele != null)
		{
			dele(t0, t1, t2);
		}
	}

	public static void Invoke<T0, T1, T2, T3>(Dele<T0, T1, T2, T3> dele, T0 t0, T1 t1, T2 t2, T3 t3)
	{
		if (dele != null)
		{
			dele(t0, t1, t2, t3);
		}
	}

	public static RT Invoke<RT>(RTDele<RT> dele, RT defaltRT)
	{
		if (dele != null)
		{
			return dele();
		}
		else
		{
			return defaltRT;
		}
	}

	public static RT Invoke<RT, T0>(RTDele<RT, T0> dele, RT defaltRT, T0 t0)
	{
		if (dele != null)
		{
			return dele(t0);
		}
		else
		{
			return defaltRT;
		}
	}

	public static RT Invoke<RT, T0, T1>(RTDele<RT, T0, T1> dele, RT defaltRT, T0 t0, T1 t1)
	{
		if (dele != null)
		{
			return dele(t0, t1);
		}
		else
		{
			return defaltRT;
		}
	}

	public static RT Invoke<RT, T0, T1, T2>(RTDele<RT, T0, T1, T2> dele, RT defaltRT, T0 t0, T1 t1, T2 t2)
	{
		if (dele != null)
		{
			return dele(t0, t1, t2);
		}
		else
		{
			return defaltRT;
		}
	}

	public static RT Invoke<RT, T0, T1, T2, T3>(RTDele<RT, T0, T1, T2, T3> dele, RT defaltRT, T0 t0, T1 t1, T2 t2, T3 t3)
	{
		if (dele != null)
		{
			return dele(t0, t1, t2, t3);
		}
		else
		{
			return defaltRT;
		}
	}
}
