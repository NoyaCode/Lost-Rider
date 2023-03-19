using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private float playerHp;
    private readonly float playerMaxHp = 3;
    public static int coinsNumber;
    public Vector3 respawnPos;
    
    public TextMeshProUGUI coinsText;
    public Image heartsImage;
    public GameObject gameOverPanel;
    public GameObject victoryPanel;
    public GameObject player;
    public SkinnedMeshRenderer playerModel; 
    void Start()
    {
        playerHp = playerMaxHp;
        coinsNumber = 0;
        respawnPos = new Vector3(0, 1.58f, 0);

        GameEvents.current.OnCoinCollected += UpdateCoinsUI;
        GameEvents.current.OnPlayerHpUpdate += UpdateHearts;
        GameEvents.current.OnCheckpointReached += UpdateRespawnPos;
        GameEvents.current.OnCrossedFinishLine += LevelCompleted;
    }
    private void OnDestroy()
    {
        GameEvents.current.OnCoinCollected -= UpdateCoinsUI;
        GameEvents.current.OnPlayerHpUpdate -= UpdateHearts;
        GameEvents.current.OnCheckpointReached -= UpdateRespawnPos;
        GameEvents.current.OnCrossedFinishLine += LevelCompleted;
    }

    public void UpdateCoinsUI()
    {
        coinsNumber += 1;
        coinsText.text = "Coins:" + coinsNumber;
        if (coinsNumber == 10)
        {
            GameEvents.current.TenCoinsTrigger();
        }
    }
    public void UpdateHearts(float hp, bool getInvincibility)
    {
        playerHp += hp;
        if (playerHp > playerMaxHp)
        {
            playerHp = playerMaxHp;
        }
        else if (playerHp <= 0)
        {
            StopAllCoroutines();
            Destroy(player);
            gameOverPanel.SetActive(true);
        }
        else if(getInvincibility)
        {
            StartCoroutine(Invincibility()); 
        }
        heartsImage.fillAmount = playerHp / playerMaxHp;  
    }

    public void UpdateRespawnPos(Vector3 newPos)
    {
        respawnPos = newPos;
    }

    public void LevelCompleted()
    {
        StopAllCoroutines();
        Destroy(player);
        victoryPanel.SetActive(true);
    }

    public IEnumerator Invincibility()
    {
        player.layer = 10; // Invincible layer. Player can only die in water.
        playerModel.enabled = false;
        yield return new WaitForSecondsRealtime(0.2f);
        playerModel.enabled = true;
        yield return new WaitForSecondsRealtime(0.2f);
        playerModel.enabled = false;
        yield return new WaitForSecondsRealtime(0.2f);
        playerModel.enabled = true;
        yield return new WaitForSecondsRealtime(0.2f);
        playerModel.enabled = false;
        yield return new WaitForSecondsRealtime(0.2f);
        playerModel.enabled = true;
        player.layer = 7; // Player layer. 
    }
}
