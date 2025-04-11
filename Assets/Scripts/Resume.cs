using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour {

	public Transform m_pauseMenu;

	public void ResumeGame()
	{
		m_pauseMenu.gameObject.SetActive (false);
		Time.timeScale = 1;
	}
}
