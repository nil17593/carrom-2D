using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BSWCarrom
{
    public class StrikerController : MonoBehaviour
    {
        /// <summary>
        /// this class handles the logic for striker
        /// striker can be set manually
        /// used slider for setting position
        /// used line renderer for showing the shooting direction
        /// by dragging mouse will add force in opposite direction
        /// </summary>
        #region Serialized fields
        [SerializeField] private int strikerSpeed;
        [SerializeField] private LineRenderer lineRenderer;
        [SerializeField] private Slider strikerSlider;
        [SerializeField] private GameObject strikerGlow;
        #endregion

        #region Vectors & Transforms
        private Transform strikerTransform;    
        private Vector2 startPos;
        private Vector2 dir;
        private Vector3 mousePos;
        private Vector3 inverseMousePos;
        #endregion

        #region Components
        private Rigidbody2D rigidbody;
        private CircleCollider2D strikerCollider;
        #endregion

        #region Bools
        private bool hasStriked=false;
        private bool isPosSet = false;
        private bool isAbleToSet=false;
        #endregion

        public static StrikerController Instance;
        //private MakeCoinsIsKinematic MakeCoinsIsKinematic;

        private void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            strikerTransform = transform;
            startPos = transform.position;
            strikerGlow.SetActive(true);
        }

        private void FixedUpdate()
        {
            lineRenderer.enabled = false;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            inverseMousePos = new Vector3(-mousePos.x, -mousePos.y, mousePos.z);

            if (Input.GetMouseButtonDown(0) && rigidbody.velocity.magnitude == 0 && isPosSet)
            {
                ShootStriker();
            }

            if (!hasStriked)
            {
                SetStriker();
            }

            if (isPosSet && rigidbody.velocity.magnitude == 0)
            {
                SetLineRenderer();
            }
            if (rigidbody.velocity.magnitude <= 0.2f && rigidbody.velocity.magnitude != 0)
            {
                ResetSriker();
            }
        }

        //set striker for shoot
        private void SetStriker()
        {
            //MakeCoinsIsKinematic.MakeKinematic();
            //strikerCollider.isTrigger = true;
            //SoundManager.Instance.PlayMusic(Sounds.SetStriker);
            strikerTransform.position = new Vector2(strikerSlider.value, startPos.y);
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (!isPosSet)
                    {
                        isPosSet = true;
                    }
                }
            }
        }

        //shooting of striker
        private void ShootStriker()
        {
            //MakeCoinsIsKinematic.Instance.MakeDynamic();
            //MakeCoinsIsKinematic.MakeDynamic();
            //SoundManager.Instance.PlayMusic(Sounds.ShootStriker);
            //strikerCollider.isTrigger = false;
            strikerGlow.SetActive(false);
            float x = 0;
            if (isPosSet && rigidbody.velocity.magnitude == 0)
            {
                x = Vector2.Distance(transform.position, mousePos);
            }
            dir = (Vector2)(inverseMousePos - transform.position);
            dir.Normalize();
            rigidbody.AddForce(strikerSpeed * x * dir);
            hasStriked = true;
        }

        //striker will reset after every shot on its shoot position
        public void ResetSriker()
        {
            rigidbody.velocity = Vector2.zero;
            strikerGlow.SetActive(true);
            hasStriked = false;
            isPosSet = false;
            lineRenderer.enabled = true;
        }

        //sets line renderer to show striker hit direction
        private void SetLineRenderer()
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, strikerTransform.position);
            lineRenderer.SetPosition(1, inverseMousePos);
        }
    }
}