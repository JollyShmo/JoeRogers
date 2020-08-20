using UnityEngine;
using UnityEngine.UI;

public class CoinDestroy : MonoBehaviour
{
    public GameObject youWin;
    public Image blackFadeOut;
    public GameObject enemy;
    public GameObject TUtext;
    public Image background;
    public GameObject coins;

    private void Start()
    {
        coins.SetActive(false);
        youWin.SetActive(false);
        background.gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collition)
    {
        if (collition.gameObject.tag == "Player")
        {
            Collect();
            Winning();
        }
    }
    void Collect()
    {
        CoinCounterScript.coinAmount += 1;
        FindObjectOfType<SoundManager>().Play("coinGet");

        this.gameObject.SetActive(false);
    }
    void Winning()
    {
        if (CoinCounterScript.coinAmount == 5)
        {
            Time.timeScale = 0f;
            youWin.SetActive(true);
            gameObject.SetActive(false);           
            background.gameObject.SetActive(true);
        }
    }
}