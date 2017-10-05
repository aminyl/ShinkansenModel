using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeatGenerator : MonoBehaviour {
	public float PITCH = 1.04f;
	public float WIDTH = 0.44f;
	public float CENTER_MERGIN = 0.57f;
	public int ROW_N = 20;
	public int COL_LEFT_N = 3;
	public int COL_RIGHT_N = 2;

	public GameObject seat;

	// Use this for initialization
	void Start () {
		GenerateSeats();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void GenerateSeats(){
		for(int i = 0; i < COL_LEFT_N; i++){
			for(int j = 0; j < ROW_N; j++){
				GameObject _seat = Instantiate(seat);
				_seat.transform.position = new Vector3(i * WIDTH, 0, - j * PITCH);
			}
		}
		float _offset = CENTER_MERGIN + WIDTH * COL_LEFT_N;
		for(int i = 0; i < COL_RIGHT_N; i++){
			for(int j = 0; j < ROW_N; j++){
				GameObject _seat = Instantiate(seat) as GameObject;
					_seat.transform.position = new Vector3(i * WIDTH + _offset, 0, - j * PITCH);
			}
		}
	}
}
