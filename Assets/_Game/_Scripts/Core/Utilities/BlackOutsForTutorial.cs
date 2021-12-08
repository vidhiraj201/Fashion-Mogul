using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackOutsForTutorial : MonoBehaviour
{

    public GameObject particalPoof;
    
    public GameObject particalPoofBig;

    public List<GameObject> Day2 = new List<GameObject>();
    public List<GameObject> Day3 = new List<GameObject>();
    public List<GameObject> Day4 = new List<GameObject>();

    private FashionM.Core.GameManager gm;

    public bool do1;
    public bool do2;
    public bool do3;

    public bool itrationDone_1;
    public bool itrationDone_2;
    public bool itrationDone_3;



    void Start()
    {
        gm = FindObjectOfType<FashionM.Core.GameManager>();

        itrationDone_1 = false;
        itrationDone_2 = false;
        itrationDone_3 = false;

        if (Day2.Count > 0 && !do1)
        {
            for(int i = 0; i <= Day2.Count - 1; i++)
            {
                Day2[i].SetActive(false);
            }
        }
        if (Day3.Count > 0 && !do2)
        {
            for (int i = 0; i <= Day3.Count - 1; i++)
            {
                Day3[i].SetActive(false);
            }
        }
        if (Day4.Count > 0 && !do3)
        {
            for (int i = 0; i <= Day4.Count - 1; i++)
            {
                Day4[i].GetComponent<FashionM.Core.StoreExpansion>().enabled = false;
                Day4[i].transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }
    void Update()
    {
        DO_1();
        DO_2();
        DO_3();
    }

    public void DO_1()
    {
        if (gm.dayCount == 1 && Day2.Count > 0 && !do1 && !itrationDone_1 && !gm.DayOff && gm.DayStart)
        {
            gm.Cinemachine.Play("Casual");
            try
            {
                StartCoroutine(day2(0.5f));
                FindObjectOfType<FashionM.Core.playerStackingSystem>().resetStacking();
                FindObjectOfType<FashionM.Core.EmpStackingSystem>().poofCloth();
            }
            catch
            {

            }

        }
        if (gm.dayCount >= 1 && Day2.Count > 0 && do1 && !itrationDone_1 && !gm.DayOff && gm.DayStart)
        {
            for (int i = 0; i <= Day2.Count - 1;)
            {
                try
                {
                    Day2[i].SetActive(true);
                    i++;
                    if (i == Day2.Count - 1)
                        itrationDone_1 = true;
                }
                catch
                {

                }

            }
        }
    }
    public void DO_2()
    {
        if (gm.dayCount == 2 && Day3.Count > 0 && !do2 && !itrationDone_2 && !gm.DayOff && gm.DayStart)
        {
            gm.Cinemachine.Play("Casual");
            try
            {
                StartCoroutine(day3(0.4f));
                FindObjectOfType<FashionM.Core.playerStackingSystem>().resetStacking();
                FindObjectOfType<FashionM.Core.EmpStackingSystem>().poofCloth();
            }
            catch
            {

            }

        }
        if (gm.dayCount >= 2 && Day3.Count > 0 && do2 && !itrationDone_2 && !gm.DayOff && gm.DayStart)
        {
            for (int i = 0; i <= Day3.Count - 1;)
            {
                try
                {
                    Day3[i].SetActive(true);
                    i++;
                    if (i >= 1)
                        itrationDone_2 = true;
                }
                catch
                {

                }

            }
        }
    }

    public void DO_3()
    {
        if (gm.dayCount == 3 && Day4.Count > 0 && !do3 && !itrationDone_3 && !gm.DayOff && gm.DayStart)
        {
            gm.Cinemachine.Play("4Sec");
            try
            {
                StartCoroutine(day4(0.4f));
                FindObjectOfType<FashionM.Core.playerStackingSystem>().resetStacking();
                FindObjectOfType<FashionM.Core.EmpStackingSystem>().poofCloth();
            }
            catch
            {

            }

        }
        if (gm.dayCount >= 3 && Day4.Count > 0 && do3 && !itrationDone_3 && !gm.DayOff && gm.DayStart)
        {
            for (int i = 0; i <= Day4.Count - 1;i++)
            {
                if (Day4[i] != null && !Day4[i].GetComponent<FashionM.Core.StoreExpansion>().enabled)
                {
                    Day4[i].GetComponent<FashionM.Core.StoreExpansion>().enabled = true;
                    Day4[i].transform.GetChild(0).gameObject.SetActive(true);
                }
                if (i >= Day4.Count - 1)
                    itrationDone_3 = true;
            }
        }
    }



    IEnumerator day2(float delay)
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i <= Day2.Count - 1;i++)
        {
            yield return new WaitForSeconds(delay);
            if (Day2[i] != null && !Day2[i].activeSelf)
            {
                Day2[i].SetActive(true);
                Destroy(Instantiate(particalPoof, Day2[i].transform.position + new Vector3(0,1f,0), Quaternion.Euler(90, 0, 0)), 1.5f);
                if (i == Day2.Count-1)
                    do1 = true;
            }
            
        }

    }
    IEnumerator day3(float delay)
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i <= Day3.Count - 1; i++)
        {
            yield return new WaitForSeconds(delay);
            if (Day3[i] != null && !Day3[i].activeSelf)
            {
                Day3[i].SetActive(true);
                Destroy(Instantiate(particalPoof, Day3[i].transform.localPosition + new Vector3(0, 1f, 0), Quaternion.Euler(90,0,0)), 1.5f);
                if (i >= Day3.Count-1)
                    do2 = true;
            }
            
        }
    }
    IEnumerator day4(float delay)
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i <= Day4.Count - 1; i++)
        {
            yield return new WaitForSeconds(delay);
            if (Day4[i] != null && !Day4[i].GetComponent<FashionM.Core.StoreExpansion>().enabled)
            {
                Day4[i].GetComponent<FashionM.Core.StoreExpansion>().enabled = true;
                Day4[i].transform.GetChild(0).gameObject.SetActive(true);
                //Day4[i].SetActive(true);
                Destroy(Instantiate(particalPoofBig, Day4[i].transform.localPosition + new Vector3(0, 1f, 0), Quaternion.Euler(90, 0, 0)), 1.5f);
                if (i >= Day4.Count-1)
                    do3 = true;
            }            
        }
    }

}
