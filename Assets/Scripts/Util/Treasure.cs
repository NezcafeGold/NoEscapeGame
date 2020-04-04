using System;
using UnityEngine;

namespace MazeGen.Util
{
    public class Treasure : MonoBehaviour
    {
        private Camera _camera;
        private bool PlayerIsNear = false;
        [SerializeField]
        private UI _UI;

        private void Start()
        {
            _camera = Camera.main;
            //TODO УДАЛИТЬ
           // _UI._Bomb.SetActive(true);
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0) && PlayerIsNear)
            {
                var mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
                RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
                if (hit.collider != null)
                {
                    if (hit.transform.tag == "Treasure")
                    {
                        _UI._Bomb.SetActive(true);
                        print("D");
                    }
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.transform.tag == "Player")
            {
                PlayerIsNear = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            PlayerIsNear = false;
        }
    }
}