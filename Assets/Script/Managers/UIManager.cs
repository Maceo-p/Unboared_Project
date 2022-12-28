using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("UpdateHud")]
    [SerializeField] private TextMeshProUGUI scoreDisplay;
    [SerializeField] private TextMeshProUGUI killDisplay;
    [SerializeField] private GameObject lifegroup;

    [Header("Screens")]
    [SerializeField] private GameObject gameoverScreen;


    private int scoreCount;
    private int killCount;

    private void Start()
    {
        scoreDisplay.text = "0";
        killDisplay.text = "0";

        scoreCount = 0;
        killCount = 0;

        gameoverScreen.SetActive(false);

        Enemy.onDeathEnemy += Enemy_onDeathEnemy;
        Gold.OnCollect += Gold_OnCollect;
        PlayerMove.onDeathPlayer += DisplayGameOverScreen;
        PlayerMove.onHurtPlayer += PlayerMove_onHurtPlayer;
    }

    private void PlayerMove_onHurtPlayer(int life)
    {
        lifegroup.transform.GetChild(life).gameObject.SetActive(false);
    }

    private void Gold_OnCollect()
    {
        scoreCount++;
        UpdateHud();
    }

    private void Enemy_onDeathEnemy()
    {
        killCount++;
        UpdateHud();
    }

    private void DisplayGameOverScreen()
    {
        gameoverScreen.SetActive(true);

        gameoverScreen.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = scoreDisplay.text;
        gameoverScreen.transform.GetChild(1).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = killDisplay.text;

        scoreDisplay.transform.parent.gameObject.SetActive(false);
        killDisplay.transform.parent.gameObject.SetActive(false);
    }

    private void UpdateHud()
    {
        scoreDisplay.text = scoreCount.ToString();
        killDisplay.text = killCount.ToString();
    }

    public void OnRetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnDestroy()
    {
        Enemy.onDeathEnemy -= Enemy_onDeathEnemy;
        Gold.OnCollect -= Gold_OnCollect;
        PlayerMove.onDeathPlayer -= DisplayGameOverScreen;
        PlayerMove.onHurtPlayer -= PlayerMove_onHurtPlayer;
    }
}
