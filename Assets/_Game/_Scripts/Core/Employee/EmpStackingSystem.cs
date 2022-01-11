using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FashionM.Control;
using FashionM.Movement;

namespace FashionM.Core
{
    public class EmpStackingSystem : MonoBehaviour
    {
        public List<GameObject> ClothObject = new List<GameObject>();
        public GameObject StackingObject;
        public GameObject Cloths;

        public GameObject paricalEffect;
        public Stores OR;
        private bool poof;

        private FashionM.Core.GameManager gm;

        private void Start()
        {
            gm = FindObjectOfType<FashionM.Core.GameManager>();
        }


        [Range(0,1)]
        public float PickupDileverVolume = 0.5f;
        public void addClothToStack(float num, Material mat, GameObject obj)
        {
            if (ClothObject.Count <= 3)
            {
                GetComponent<empMovement>().AM.source.PlayOneShot(GetComponent<empMovement>().AM.PandD, PickupDileverVolume);
                GameObject o = Instantiate(obj, StackingObject.transform.position, Quaternion.identity);
                /*o.transform.GetChild(0).GetComponent<MeshRenderer>().material = mat;*/
                o.transform.parent = StackingObject.transform;
                o.GetComponent<Cloths>().ClothIdentityNumber = num;
                o.GetComponent<Cloths>().Collector = this.gameObject;

                GetComponent<empMovement>().isWalkingTowardStore = false;
            }            
        }

        public void RemoveCloth(Collision other)
        {
            if (ClothObject.Count > 0)
            {
                for (int i = 0; i <= ClothObject.Count - 1; i++)
                {


                    if (i >= ClothObject.Count - 1 && ClothObject[i].GetComponent<Cloths>().ClothIdentityNumber != other.gameObject.GetComponent<clientControl>().NeedItem)
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

                        GetComponent<empMovement>().AM.source.PlayOneShot(GetComponent<empMovement>().AM.PandD, PickupDileverVolume);
                        ClothObject[i].GetComponent<Cloths>().throwCloth(other.gameObject.transform);    
                        
                        other.gameObject.GetComponent<clientControl>().playerIsNear = true;
                        other.gameObject.GetComponent<clientControl>().clothTookFromEmpOrPlayer = true;

                        GetComponent<empMovement>().isWalkingTowardStore = false;
                        GetComponent<empControl>().StoreNumberStored = -1;
                        GetComponent<empMovement>().ClientNeedItem = -1;
                        Instantiate(gm.customerUI, other.transform.position + new Vector3(0, 3.5f, 0), Quaternion.identity);
                    }
                }
            }
        }
        private void FixedUpdate()
        {
            StackingClothListing();

            if (GetComponent<empControl>().Occupied && poof)
                poof = false;


            if (!GetComponent<empControl>().Occupied && ClothObject.Count > 0)
            {
                poofCloth();
            }
        }

        public void poofCloth()
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

        //float x;
        public void StackingClothListing()
        {
            foreach (Transform T in StackingObject.transform)
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
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Racks"))
            {
                OR = other.gameObject.GetComponent<Stores>();
                /*if (OR != null && !OR.isRackClosed)
                    OR.playerIsNear = true;*/
            }
        }

    }
}
