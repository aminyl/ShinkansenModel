using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleController : MonoBehaviour
{
	Vector3 targetPosition;
	float SPEED = 10.0f;
	Vector3 velocity = new Vector3 (1, 0, -1);
	bool pLargerX, pLargerZ;

	public void Initialize (Vector3 _position, Vector3 _targetPosition)
	{
		transform.position = _position;
		targetPosition = _targetPosition;
		pLargerX = transform.position.x > targetPosition.x;
		pLargerZ = transform.position.z > targetPosition.z;
		if (pLargerX) {
			velocity.x *= -1;
		}
		if (!pLargerZ) {
			velocity.z *= -1;
		}
		velocity *= SPEED;
		StartCoroutine (Move ());
	}

	IEnumerator Move ()
	{
		while (true) {
			bool _pLargerX = transform.position.x > targetPosition.x;
			bool _pLargerZ = transform.position.z > targetPosition.z;
			if (_pLargerZ == pLargerZ) {
				transform.position += Vector3.Scale (velocity, Vector3.forward) * Time.deltaTime;
				Vector3 _p = transform.position;
				_p.z = pLargerZ ? Mathf.Max (_p.z, targetPosition.z) : Mathf.Min (_p.z, targetPosition.z + 0.001f);
				transform.position = _p;
			} else {
				if (_pLargerX == pLargerX) {
					transform.position += Vector3.Scale (velocity, Vector3.right) * Time.deltaTime;
					Vector3 _p = transform.position;
					_p.x = pLargerX ? Mathf.Max (_p.x, targetPosition.x) : Mathf.Min (_p.x, targetPosition.x);
					transform.position = _p;
				} else {
				}
			}
			yield return null;
		}
	}
}