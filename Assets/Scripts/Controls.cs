using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {

	public Transform m_controlsList;
	public Transform m_pauseMenu;
	public Transform m_colorBlocks;
	public Transform m_colorText;
	public Transform m_gameOverText;
	public Transform m_pauseButton;
	public Transform m_startButton;
	public Transform m_controlsButton;
	public Transform m_title;

	public void ViewControls()
	{
		m_controlsList.gameObject.SetActive (true);

		m_pauseMenu.gameObject.SetActive (false);
		m_colorBlocks.gameObject.SetActive (false);
		m_colorText.gameObject.SetActive (false);
		m_gameOverText.gameObject.SetActive (false);
		m_pauseButton.gameObject.SetActive (false);

	}

	public void ViewControlsStart()
	{
		m_controlsList.gameObject.SetActive (true);
		m_startButton.gameObject.SetActive (false);
		m_title.gameObject.SetActive (false);
		m_controlsButton.gameObject.SetActive (false);

	}
}
