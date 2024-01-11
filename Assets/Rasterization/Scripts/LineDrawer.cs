using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
	[SerializeField] private List<Vector2Int> m_points;
	[SerializeField] private Vector2Int m_point0;
	[SerializeField] private Vector2Int m_point1;
	[SerializeField] private Vector2Int m_point2;
	[SerializeField] private Vector2Int m_point3;

	[SerializeField] private GameObject m_point;

	void Start()
	{
		// DrawLine(m_point0, m_point1, Color.black);
		// DrawLine(m_point2, m_point3, Color.black);

		DrawWireframeTriangle(m_points[0], m_points[1], m_points[2], Color.black);
		DrawFilledTriangle(m_points[0], m_points[1], m_points[2], Color.cyan);
	}

	private void DrawLine(Vector2Int p0, Vector2Int p1, Color color)
	{
		int x0 = p0.x;
		int y0 = p0.y;
		int x1 = p1.x;
		int y1 = p1.y;

		if (Mathf.Abs(x1 - x0) > Mathf.Abs(y1 - y0))
		{
			if (x0 > x1)
			{
				(x0, x1) = (x1, x0);
				(y0, y1) = (y1, y0);
			}

			var ys = Interpolate(x0, y0, x1, y1);
			for (int x = x0; x <= x1; x++)
			{
				DrawPixel(x, ys[x - x0], color);
			}
		}
		else
		{
			if (y0 > y1)
			{
				(x0, x1) = (x1, x0);
				(y0, y1) = (y1, y0);
			}

			var xs = Interpolate(y0, x0, y1, x1);
			for (int y = y0; y <= y1; y++)
			{
				DrawPixel(xs[y - y0], y, color);
			}
		}
	}

	private void DrawPixel(float x, int y, Color color)
	{
		var spawnedPoint = Instantiate(m_point, new Vector3(x, 0.5f, y), new Quaternion());
		spawnedPoint.GetComponent<MeshRenderer>().material.color = color;
	}

	private List<int> Interpolate(int i0, int d0, int i1, int d1)
	{
		if (i0 == i1)
		{
			return new List<int>()
			{
				d0
			};
		}

		List<int> values = new List<int>();
		float a = (float)(d1 - d0) / (float)(i1 - i0);
		float d = d0;
		for (int i = i0; i <= i1; i++)
		{
			values.Add(Mathf.RoundToInt(d));
			d += a;
		}

		return values;
	}

	private void DrawWireframeTriangle(Vector2Int P0, Vector2Int P1, Vector2Int P2, Color color)
	{
		DrawLine(P0, P1, color);
		DrawLine(P1, P2, color);
		DrawLine(P2, P0, color);
	}

	private void DrawFilledTriangle(Vector2Int P0, Vector2Int P1, Vector2Int P2, Color color)
	{
		int x0 = P0.x;
		int y0 = P0.y;
		int x1 = P1.x;
		int y1 = P1.y;
		int x2 = P2.x;
		int y2 = P2.y;

		if (y1 < y0)
		{
			(x1, x0) = (x0, x1);
			(y1, y0) = (y0, y1);
		}

		if (y2 < y0)
		{
			(x2, x0) = (x0, x2);
			(y2, y0) = (y0, y2);
		}

		if (y2 < y1)
		{
			(x2, x1) = (x1, x2);
			(y2, y1) = (y1, y2);
		}

		var x01 = Interpolate(y0, x0, y1, x1);
		var x12 = Interpolate(y1, x1, y2, x2);
		var x02 = Interpolate(y0, x0, y2, x2);

		x01.Remove(x01.Count - 1);
		List<int> x012 = x01.ToList();
		x012.AddRange(x12);

		List<int> x_left = new();
		List<int> x_right = new();

		var m = x012.Count / 2;
		if (x02[m] < x012[m])
		{
			x_left = x02;
			x_right = x012;
		}
		else
		{
			x_left = x012;
			x_right = x02;
		}

		for (int y = y0; y <= y2; y++)
		{
			for (int x = x_left[y - y0]; x < x_right[y - y0]; x++)
			{
				DrawPixel(x, y, color);
			}
		}
	}
}