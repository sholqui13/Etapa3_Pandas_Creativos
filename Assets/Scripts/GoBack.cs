using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBack : MonoBehaviour {

	public Transform m_controlsList;
	public Transform m_pauseMenu;
	public Transform m_colorBlocks;
	public Transform m_colorText;
	public Transform m_gameOverText;
	public Transform m_pauseButton;

	public void Back()
	{
		m_controlsList.gameObject.SetActive (false);

		m_pauseMenu.gameObject.SetActive (true);
		m_colorBlocks.gameObject.SetActive (true);
		m_colorText.gameObject.SetActive (true);
		m_gameOverText.gameObject.SetActive (true);
		m_pauseButton.gameObject.SetActive (true);
	}

	public void BacktoStart()
	{
		SceneManager.LoadScene("Start");
	}
}

