using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{

	public static ScoreUI SharedInstance;

	private int score = 0;
	public Text scoreText;

	public void UpdateScore(int newScore){score += newScore;}


	private void Awake()
	{
		SharedInstance = this;
	}


	// Update is called once per frame
	void Update()
    {
		scoreText.text = "Score: " + score;    
    }
}
