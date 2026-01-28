using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
	public int count = 0;

	public TextMeshProUGUI countText;
	public GameObject winTextObject;
	public AudioSource audioSource;

	public int winCount = 15;

	void Start()
	{
		UpdateUI();
		if (winTextObject != null)
			winTextObject.SetActive(false);
	}

	public void AddPoint()
	{
		count++;

		if (audioSource != null)
			audioSource.Play();

		UpdateUI();

		if (count >= winCount && winTextObject != null)
			winTextObject.SetActive(true);
	}

	void UpdateUI()
	{
		if (countText != null)
			countText.text = "Points: " + count.ToString();
	}
}

