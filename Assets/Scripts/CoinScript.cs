using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public UI UI;
    private bool triggerUp = false;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.transform.tag == "Player")
        {
            if(!triggerUp)
            UI.IncreaseCoinStat();
            Destroy(gameObject);
            triggerUp = true;
        }
    }
}
