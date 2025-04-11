using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

	public Transform m_pauseMenu;

	public void OpenPauseMenu()
	{
		m_pauseMenu.gameObject.SetActive (true);
		Time.timeScale = 0;
	}
}
