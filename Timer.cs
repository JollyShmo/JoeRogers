using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float time;
    public Text startText;
    public GameObject TUtext;
    public GameObject Player;

    public void Start()
    {
        TUtext.SetActive(false);
    }
    void Update()
    {
        time -= Time.deltaTime;
        startText.text = time.ToString("0.0");
        TimeLessZero();
    }
    void TimeLessZero()
    {
        if (time <= 0)
        {
            CoinCounterScript.coinAmount = 0;
            TUtext.SetActive(true);
            AudioListener.pause = true;
            Player.GetComponent<SpriteRenderer>().enabled = false;
            Time.timeScale = 0f;
        }
    }
}