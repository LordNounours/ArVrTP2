using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIBehaviour : MonoBehaviour {
    TMP_Text coinText;
    TMP_Text timerText;
    int nbCoins = 0;

    IEnumerator TimerTick() {
        while (GameVariables.currentTime > 0) {
            yield return new WaitForSeconds(1);
            GameVariables.currentTime--;
            timerText.text = "Time: " + GameVariables.currentTime.ToString();
        }

        string currentSceneName = SceneManager.GetActiveScene().name;
        if (currentSceneName == "TP1Scene") {
            SceneManager.LoadScene("TP2Scene"); 
        } else {
            SceneManager.LoadScene("TP1Scene"); 
        }
    }

    void Start() {
        coinText = GameObject.Find("lblCoins").GetComponent<TMPro.TMP_Text>();
        timerText = GameObject.Find("lblTime").GetComponent<TMPro.TMP_Text>();
        GameVariables.currentTime = GameVariables.allowedTime; 
        StartCoroutine(TimerTick());
    }

    void Update() {
    }

    public void AddHit() {
        nbCoins++;
        coinText.text = "Coins: " + nbCoins;
    }
}
