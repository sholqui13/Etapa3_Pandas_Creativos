using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour {

	public void ReturnTitle()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene("Start");
	}
}
