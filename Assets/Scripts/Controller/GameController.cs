using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField] private int _Xsize;
    [SerializeField] private int _Ysize;
    [SerializeField] private int _ChangeOfTreasure;
    [SerializeField] private int _Speed;
    private float sizeOfCeil;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float SizeOfCeil
    {
        get => sizeOfCeil;
        set => sizeOfCeil = value;
    }

    public int XSize
    {
        get => _Xsize;
    }

    public int YSize
    {
        get => _Ysize;
   }

    public int ChangeOfTreasure
    {
        get => _ChangeOfTreasure;
    }

    public int Speed
    {
        get => _Speed;
        set => _Speed = value;
    }

}
