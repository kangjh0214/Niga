using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
	[SerializeField] GameObject[] stage;
    public static int currentStage;
    private int openStages;

	private void Awake()
	{
		openStages = PlayerPrefs.GetInt("OpenStage", 0);
		for (int i = 0; i < stage.Length; i++)
		{
			stage[i] = Instantiate(stage[i]);
			stage[i].SetActive(false);
		}
		stage[currentStage].SetActive(true);
	}

	public void StageChange()
	{
		if (currentStage == stage.Length - 1)
		{
			if (PlayerPrefs.GetInt("Seen") == 0) SceneManager.LoadScene("ClearScene");
			else SceneManager.LoadScene("Stage");
		}
		else
		{
			++currentStage;
			for(int i = 0; i < stage.Length; i++)
			{
				stage[i].SetActive(false);
			}
			stage[currentStage].SetActive(true);
		}
	}

	public void StageClear()
	{
		if (openStages <= currentStage)
		{
			++openStages;
			PlayerPrefs.SetInt("OpenStage", openStages);
			Debug.Log(PlayerPrefs.GetInt("OpenStage"));
		}
		Debug.Log(PlayerPrefs.GetInt("OpenStage"));
	}
}
