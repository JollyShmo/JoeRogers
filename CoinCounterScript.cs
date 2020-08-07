using UnityEngine;
using UnityEngine.UI;

public class CoinCounterScript : MonoBehaviour
{
    Text coinText;
    public static int coinAmount;

    void Start()
    {
        coinText = GetComponent<Text>();
    }
    void Update()
    {
        coinText.text = coinAmount.ToString();
    }
}
