﻿using UnityEngine;
using System.Collections;

public class SSApplication
{
	public delegate void OnLoadedDelegate(GameObject root);

	private static OnLoadedDelegate m_OnLoaded;
	private static string m_SceneName;

	public static void LoadLevelAdditive(string sceneName, bool isAsync = false, OnLoadedDelegate onLoaded = null)
	{
		m_OnLoaded = onLoaded;
		m_SceneName = sceneName;

		if (!isAsync)
		{
			Application.LoadLevelAdditive (sceneName);
		}
		else
		{
			Application.LoadLevelAdditiveAsync (sceneName);
		}
	}

	public static void OnLoaded(GameObject root)
	{
		if (m_SceneName == root.name && m_OnLoaded != null)
		{
			m_OnLoaded (root);
		}
	}
}
