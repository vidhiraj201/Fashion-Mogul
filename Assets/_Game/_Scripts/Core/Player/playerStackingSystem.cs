using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FashionM.Control;
using FashionM.Movement;

namespace FashionM.Core 
{
    public class playerStackingSystem : MonoBehaviour
    {
        public List<GameObject> ClothObject = new List<GameObject>();
        public GameObject StackingObject;
        public GameObject Cloths;

        public GameObject paricalEffect;

        public Stores OR;        



        [Range(0,1)]
        public float PickupDileverVolume;

        void Start()
        {

        }

       
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                GameObject C = Instantiate(Cloths, StackingObject.transform.position, Quaternion.Euler(0,0,0));
                C.transform.parent = StackingObject.transform;
                C.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                //RemoveCloth(1);

                /*ClothObject[Random.Range(0, ClothObject.Count)].GetComponent<Cloths>().throwCloth();*/
            }
            if (ClothObject.Count <= 0)
                poof = false;
        }
        bool poof;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Destroy"))
            {
                resetStacking();
            }
                
        }


        public void resetStacking()
        {
            if (!poof && ClothObject.Count > 0)
            {
                Destroy(Instantiate(paricalEffect, StackingObject.transform.position, Quaternion.identity), 2);
                poof = true;
            }

            if (ClothObject.Count > 0)
            {
                for (int i = 0; i <= ClothObject.Count - 1; i++)
                {
                    if (ClothObject[i] != null)
                    {
                        Destroy(ClothObject[i]);
                    }

                    if (ClothObject[i] == null)
                    {
                        ClothObject.Remove(ClothObject[i]);
                    }
                }
            }

        }
        //StackingObject.transform.position
        public void addClothToStack(float num, Material mat, GameObject cloth)
        {
            if (ClothObject.Count <= 0)
            {
                GetComponent<playerMovement>().AM.source.PlayOneShot(GetComponent<playerMovement>().AM.PandD, PickupDileverVolume);
                GameObject o = Instantiate(cloth, StackingObject.transform.position, Quaternion.identity);
                /*o.transform.GetChild(0).GetComponent<MeshRenderer>().material = mat;*/
                o.transform.parent = StackingObject.transform;
                o.GetComponent<Cloths>().ClothIdentityNumber = num;
                o.GetComponent<Cloths>().Collector = this.gameObject;
            }

            if (ClothObject.Count > 0)
            {
                GetComponent<playerMovement>().AM.source.PlayOneShot(GetComponent<playerMovement>().AM.PandD, PickupDileverVolume);
                GameObject o = Instantiate(cloth, ClothObject[ClothObject.Count-1].transform.position + new Vector3(0, 0.05f, 0), Quaternion.identity);
                /*o.transform.GetChild(0).GetComponent<MeshRenderer>().material = mat;*/
                o.transform.parent = StackingObject.transform;
                o.GetComponent<Cloths>().ClothIdentityNumber = num;
                o.GetComponent<Cloths>().Collector = this.gameObject;
            }

        }

        public void RemoveCloth(Collision other)
        {            
            if (ClothObject.Count > 0)
            {
                for (int i = 0; i <= ClothObject.Count-1;)
                {
                    if(i >= ClothObject.Count-1 && ClothObject[i].GetComponent<Cloths>().ClothIdentityNumber != other.gameObject.GetComponent<clientControl>().NeedItem)
                    {
                        return;
                    }

                    if (ClothObject[i].GetComponent<Cloths>().ClothIdentityNumber != other.gameObject.GetComponent<clientControl>().NeedItem)
                    {
                        i++;
                    }

                    if (ClothObject[i].GetComponent<Cloths>().ClothIdentityNumber == other.gameObject.GetComponent<clientControl>().NeedItem)
                    {
                        //other.gameObject.layer = 17;
                        GetComponent<playerMovement>().AM.source.PlayOneShot(GetComponent<playerMovement>().AM.PandD, PickupDileverVolume);
                        ClothObject[i].GetComponent<Cloths>().throwCloth(other.gameObject.transform);                        
                        other.gameObject.GetComponent<clientControl>().playerIsNear = true;
                        other.gameObject.GetComponent<clientControl>().clothTookFromEmpOrPlayer = true;
                        break;
                    }  

                }
            }
        }
        private void FixedUpdate()
        {
            StackingClothListing();
        }

        float x;
        public void StackingClothListing()
        {
            foreach(Transform T in StackingObject.transform)
            {
                if (!ClothObject.Contains(T.gameObject))
                {
                    T.position = new Vector3(T.transform.position.x, T.transform.position.y + 0.25f, T.transform.position.z);
                    ClothObject.Add(T.gameObject);
                }
            }

            if (ClothObject.Count > 0)
            {
                for (int i = 0; i <= ClothObject.Count - 1; i++)
                {                   
                    if (ClothObject[i] != null)
                    {
                        ClothObject[i].transform.position = new Vector3(ClothObject[i].transform.position.x, ClothObject[i].transform.position.y, ClothObject[i].transform.position.z);
                    }

                    if (ClothObject[i] == null)
                    {
                        ClothObject.Remove(ClothObject[i]);
                    }
                }
            }
        }
        private void OnCollisionStay(Collision other)
        {
            /*if (other.gameObject.CompareTag("Client"))
            {
                if (other.gameObject.GetComponent<clientControl>().NeedItem == StoreNumberStored)
                {
                    other.gameObject.GetComponent<clientControl>().startTreding = true;
                    other.gameObject.GetComponent<clientControl>().playerIsNear = true;
                    other.gameObject.GetComponent<clientControl>().tredingComplete = true;
                    //StoreNumberStored = 0;
                }
            }
*/
            if (other.gameObject.CompareTag("Racks") && GetComponent<FashionM.Movement.playerMovement>().direction.magnitude < 0.1f)
            {
                OR = other.gameObject.GetComponent<Stores>();
                if (OR != null && !OR.isRackClosed)
                    OR.playerIsNear = true;
            }
        }

    }
}

