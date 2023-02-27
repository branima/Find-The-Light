using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Transform player;

    public GameObject levelCompletePanel;

    public static GameManager Instance;
    void Awake() => Instance = this;

    public void NextLevel() => LoadLevel((SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings);
    public void Retry() => LoadLevel(SceneManager.GetActiveScene().buildIndex);
    void LoadLevel(int levelIndex) => SceneManager.LoadScene(Mathf.Max(0, levelIndex));

    public void LevelComplete() => levelCompletePanel.SetActive(true);

    public Transform GetPlayer() => player;
}
