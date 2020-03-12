using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField]
    private GameObject Bomb;
    
    // Start is called before the first frame update
    void Start()
    {
        Bomb.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject _Bomb
    {
        get => Bomb;
        set => Bomb = value;
    }
}
