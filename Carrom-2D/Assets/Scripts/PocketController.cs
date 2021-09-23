using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BSWCarrom 
{
    public class PocketController : MonoBehaviour
    {
        public Transform strikerTransform;
        private bool isRedCoin = false;
        private bool isCoinAfterRed = false;
        private ScoreController scoreController;


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Coin"))// || collision.gameObject.tag == "Striker")
            {
                Debug.Log(collision.name);
                Destroy(collision.gameObject);
                //scoreController.IncreaseScore(10);
            }
            else if (collision.gameObject.CompareTag("Striker"))
            {
                Debug.Log(this.name);
                strikerTransform.position = new Vector3(0, -1.73f, 0);
            }
            else if (collision.gameObject.CompareTag("RedCoin"))
            {
                Debug.Log(this.name);

                collision.gameObject.SetActive(false);
                isRedCoin = true;

                if (collision.gameObject.CompareTag("Coin"))
                {
                    isCoinAfterRed = true;
                    collision.gameObject.SetActive(false);
                }
                else if (isCoinAfterRed == true)
                {
                    collision.gameObject.SetActive(false);
                }
                else
                {
                    collision.gameObject.SetActive(true);
                }
            }
        }
    }
}