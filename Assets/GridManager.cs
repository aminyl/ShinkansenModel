using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
	public SeatGenerator seatGenerator;
	// int[,] grid;

	// Use this for initialization
	void Start ()
	{
		// grid = new int[seatGenerator.ROW_N, seatGenerator.COL_LEFT_N + seatGenerator.COL_RIGHT_N];
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public Vector3 GridToField (int i, int j)
	{
		float x, z;
		if (i < seatGenerator.COL_LEFT_N)
			x = i * seatGenerator.WIDTH;
		else
			x = seatGenerator.CENTER_MERGIN + seatGenerator.WIDTH * seatGenerator.COL_LEFT_N + (i - seatGenerator.COL_LEFT_N) * seatGenerator.WIDTH;
		z = j * seatGenerator.PITCH;
		return new Vector3 (x, 0, -z);
	}

	public Vector3 GridToField (int[] targetPosition)
	{
		int i = targetPosition [0], j = targetPosition [1];
		return GridToField (i, j);
	}
}