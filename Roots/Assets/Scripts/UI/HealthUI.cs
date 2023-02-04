using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
	[SerializeField]
	private Player player;
	private int health;

	[SerializeField]
	private GameObject[] healthImages;

    // Start is called before the first frame update
    void Start()
    {
		health = player.GetHealth();
		UpdateUIHealth();
	}
	
	public void UpdateUIHealth()
	{
		// Uses last known health amount and unactivates them
		for (int i = 0; i < health; i++)
		{
			healthImages[i].SetActive(false);
		}

		// Checks for current health amount and reactivates the left over lives
		health = player.GetHealth();
		for (int i = 0; i < health; i++)
		{
			healthImages[i].SetActive(true);
		}
	}
}
