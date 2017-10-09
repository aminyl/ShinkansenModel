using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBehaviour
{
	[SerializeField]
	SeatGenerator seatGenerator;
	[SerializeField]
	GridManager gridManager;
	[SerializeField]
	GameObject human;
	List<int[]> orderLU = new List<int[]> ();
	List<int[]> orderLD = new List<int[]> ();
	Vector3 initialHumanPositionU = new Vector3 (1.34f, 0, 1.34f);
	Vector3 initialHumanPositionD = new Vector3 (1.34f, 0, -20.1f);

	// Use this for initialization
	void Start ()
	{
		int[] orderC = new int[]{ 4, 0, 2, 3, 1 };
		foreach (int i in orderC)
			for (int j = 9; j >= 0; j--) {
				int _j = (i == 3 || i == 1) ? 9 - j : j;
				orderLU.Add (new int[]{ i, _j });
			}

		orderC = new int[]{ 4, 0, 2, 3, 1 };
		foreach (int i in orderC)
			for (int j = 10; j <= 19; j++) {
				int _j = (i == 3 || i == 1) ? 29 - j : j;
				orderLD.Add (new int[]{ i, _j });
			}

		StartCoroutine (Generate (orderLU, initialHumanPositionU));
		StartCoroutine (Generate (orderLD, initialHumanPositionD));
	}

	IEnumerator Generate (List<int[]> order, Vector3 initialPosition)
	{
		yield return new WaitForSeconds (0.5f);
		float step = 1f / order.Count;
		int count = 0;
		foreach (int[] targetPosision in order) {
			GameObject _human = Instantiate (human);
			_human.transform.FindChild ("Head").GetComponent<Renderer> ().material.color = new Color (count * step, 1f - count * step, 0f);
			_human.transform.FindChild ("Body").GetComponent<Renderer> ().material.color = new Color (count * step, 1f - count * step, 0f);
			_human.transform.parent = transform;
			count += 1;
			SampleController sampleController = _human.GetComponent<SampleController> ();
			sampleController.Initialize (initialPosition, gridManager.GridToField (targetPosision));
			yield return new WaitForSeconds (0.4f);
		}
		for (int i = 0; i < 10; i++) {
			Vector3 terminal = initialPosition;
			terminal.z = (terminal == initialHumanPositionU) ? -30f : 10f;
			GameObject _human = Instantiate (human);
			_human.transform.FindChild ("Head").GetComponent<Renderer> ().material.color = new Color (count * step, 1f - count * step, 0f);
			_human.transform.FindChild ("Body").GetComponent<Renderer> ().material.color = new Color (count * step, 1f - count * step, 0f);
			_human.transform.parent = transform;
			SampleController sampleController = _human.GetComponent<SampleController> ();
			sampleController.Initialize (initialPosition, terminal);
			yield return new WaitForSeconds (0.4f);
		}
		yield return null;
	}
}