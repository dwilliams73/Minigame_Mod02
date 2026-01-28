using UnityEngine;
using System.Collections;


public class BoxTrigger : MonoBehaviour
{
	[Tooltip("Tag of objects that belong in this box")]
	public string target_tag = "Untagged";

	public ScoreManager scoreManager;

	public GameObject timedObjectCorrect;
	public GameObject timedObjectWrong;
	public float activeDuration = .5f;

	void Start()
	{
		if (string.IsNullOrWhiteSpace(target_tag))
			Debug.LogError($"{gameObject.name}: target_tag is empty.");

		if (scoreManager == null)
			Debug.LogError($"{gameObject.name}: ScoreManager reference not set.");



	}



	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag(target_tag))
		{
			// Prevent double-triggering edge cases
			if (!other.gameObject.activeSelf)
				return;

			other.gameObject.SetActive(false);

			scoreManager.AddPoint();

			StartCoroutine(ActivateTemporarily());
		}
		else
		{
			// Wrong gem logic: reset to original position
			GemStartPosition gemPos = other.GetComponent<GemStartPosition>();
			if (gemPos != null)
			{
				Rigidbody rb = other.GetComponent<Rigidbody>();
				if (rb != null)
				{
					rb.velocity = Vector3.zero;       // stop motion
					rb.angularVelocity = Vector3.zero; // stop spinning
				}

				// Move gem back to start
				other.transform.position = gemPos.startPosition;
				other.transform.rotation = gemPos.startRotation;

				StartCoroutine(ActivateTemporarily2());
			}
		}




	}


	IEnumerator ActivateTemporarily()
	{
		if (timedObjectCorrect == null)
			yield break;

		timedObjectCorrect.SetActive(true);
		yield return new WaitForSeconds(activeDuration);
		timedObjectCorrect.SetActive(false);
	}


	IEnumerator ActivateTemporarily2()
	{
		if (timedObjectWrong == null)
			yield break;

		timedObjectWrong.SetActive(true);
		yield return new WaitForSeconds(activeDuration);
		timedObjectWrong.SetActive(false);
	}
}
