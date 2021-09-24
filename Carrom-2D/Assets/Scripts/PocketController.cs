using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace BSWCarrom 
{
    public class PocketController : MonoBehaviour
    {
        /// <summary>
        /// this class handles the logic for coin collection
        /// ontrigger method is used
        /// whenever the coins or striker gets collided 
        /// the objects either destroys or setactive falls
        /// </summary>
        [SerializeField] private Transform strikerTransform;
        [SerializeField] private Transform redCoinTransform;
        //[SerializeField] private GameObject redcoin;
        private bool isRed=false;


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("BlackCoin"))
            {
                //SoundManager.Instance.PlayMusic(Sounds.CoinInPocket);
                if (collision.gameObject.CompareTag("BlackCoin") && isRed == true)
                {
                    Debug.Log(collision.name);

                    ScoreController.Instance.IncreaseScore(60);

                    isRed = false;
                }
                else if (isRed == false)
                {
                    //RedCoin.Insance.ResetRedCoin();
                    ScoreController.Instance.IncreaseScore(10);
                    Destroy(collision.gameObject);
                }

                Destroy(collision.gameObject);

            }
            else if (collision.gameObject.CompareTag("WhiteCoin"))
            {
                //SoundManager.Instance.PlayMusic(Sounds.CoinInPocket);
                if (collision.gameObject.CompareTag("WhiteCoin") && isRed == true)
                {
                    Debug.Log(collision.name);

                    ScoreController.Instance.IncreaseScore(70);

                    isRed = false;
                }
                else if (isRed == false)
                {
                    //RedCoin.Insance.ResetRedCoin();
                    //redCoinTransform.position = new Vector3(0f,0f,0f);
                    ScoreController.Instance.IncreaseScore(20);
                    Destroy(collision.gameObject);

                    Debug.Log(collision.name);

                }
                Destroy(collision.gameObject);
            }

            else if (collision.gameObject.CompareTag("RedCoin"))
            {
                //SoundManager.Instance.PlayMusic(Sounds.CoinInPocket);
                isRed = true;
                collision.gameObject.SetActive(false);
            }

            else if (collision.gameObject.CompareTag("Striker"))
            {
                //SoundManager.Instance.PlayMusic(Sounds.Foul);
                Debug.Log(this.name);
                //StrikerController.Instance.ResetSriker();
                strikerTransform.position = new Vector3(0, -1.73f, 0);
            }
        }
    }
}