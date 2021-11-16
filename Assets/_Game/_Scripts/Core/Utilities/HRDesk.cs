using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FashionM.Core
{
    public class HRDesk : MonoBehaviour
    {
        public Image waitTimerUI;
        public float UILoadWaitTimer = 1;
        public Transform SpwanPoint;
        private GameManager gm;

        private float LoadUITimer;

        private bool isPlayerNear;


        void Start()
        {

            gm = FindObjectOfType<GameManager>();
            waitTimerUI.gameObject.SetActive(false);
            LoadUITimer = UILoadWaitTimer;
        }

        // Update is called once per frame
        void Update()
        {
            OpenUI();
        }

        void OpenUI()
        {
            waitTimerUI.transform.forward = -Camera.main.transform.forward;
            if (isPlayerNear)
            {
                LoadUITimer -= Time.deltaTime;
                waitTimerUI.gameObject.SetActive(true);
                waitTimerUI.fillAmount = LoadUITimer / UILoadWaitTimer;
                if (LoadUITimer <= 0)
                {
                    isPlayerNear = false;
                    LoadUITimer = UILoadWaitTimer;
                    waitTimerUI.gameObject.SetActive(false);
                    gm.HireEmployee.SetActive(true);
                }
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                isPlayerNear = true;
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if(isPlayerNear)
            {
                isPlayerNear = false;
                waitTimerUI.gameObject.SetActive(false);
                LoadUITimer = UILoadWaitTimer;
            }

            if(gm.HireEmployee.activeSelf)
                gm.HireEmployee.GetComponent<Animator>().Play("Out");

        }
    }
}
