using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField]
    private GameObject Bomb;

    public GameObject CounterCoin;
    private int CoinStat = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        Bomb.SetActive(false);
        CounterCoin.GetComponent<Text>().text = CoinStat.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        CounterCoin.GetComponent<Text>().text = CoinStat.ToString();
    }

    public GameObject _Bomb
    {
        get => Bomb;
        set => Bomb = value;
    }

    public void IncreaseCoinStat()
    {
        CoinStat++;
    }
}
