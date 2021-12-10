using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeeCounting : MonoBehaviour
{
    public List<GameObject> Employee = new List<GameObject>();
    public int EmployeeCountData;
    public int currentEmpCount;
    public GameObject EmployeetoSpwan;
    public GameObject SavingAndLoading;
    public FashionM.Core.HRDesk HR;

    public bool spawnEmps = false;

    private void Start()
    {
        StartCoroutine(spwnDelay(0.2f));
    }

    IEnumerator spwnDelay(float t)
    {
        yield return new WaitForSeconds(t);
        if (EmployeeCountData <= 0)
        {
            spawnEmps = true;
        }

    }
    void Update()
    {
        foreach(Transform T in transform)
        {
            if (!Employee.Contains(T.gameObject))
            {
                Employee.Add(T.gameObject);
                currentEmpCount += 1;
            }
        }

        try
        {
            if (SavingAndLoading.GetComponent<SavingAndLoadingCasual>() != null)
            {
                if(SavingAndLoading.GetComponent<SavingAndLoadingCasual>().GDC.empCount < currentEmpCount)
                {
                    SavingAndLoading.GetComponent<SavingAndLoadingCasual>().GDC.empCount += 1;
                }
                if (EmployeeCountData > 0 && EmployeeCountData == SavingAndLoading.GetComponent<SavingAndLoadingCasual>().GDC.empCount && !spawnEmps)
                {
                    spwnEmployee();
                }
            }
            if (SavingAndLoading.GetComponent<SavingAndLoadingBeach>() != null)
            {
                if (SavingAndLoading.GetComponent<SavingAndLoadingBeach>().GDB.empCount < currentEmpCount)
                {
                    SavingAndLoading.GetComponent<SavingAndLoadingBeach>().GDB.empCount += 1;
                }
                if (EmployeeCountData > 0 && EmployeeCountData == SavingAndLoading.GetComponent<SavingAndLoadingBeach>().GDB.empCount && !spawnEmps)
                {
                    spwnEmployee();
                }
            }
            if (SavingAndLoading.GetComponent<SavingAndLoadingOffice>() != null)
            {
                if (SavingAndLoading.GetComponent<SavingAndLoadingOffice>().GDO.empCount < currentEmpCount)
                {
                    SavingAndLoading.GetComponent<SavingAndLoadingOffice>().GDO.empCount += 1;
                }
                if (EmployeeCountData > 0 && EmployeeCountData == SavingAndLoading.GetComponent<SavingAndLoadingOffice>().GDO.empCount && !spawnEmps)
                {
                    spwnEmployee();
                }
            }

            if(SavingAndLoading.GetComponent<SavingAndLoadingSport>() != null)
            {
                if (SavingAndLoading.GetComponent<SavingAndLoadingSport>().GDS.empCount < currentEmpCount)
                {
                    SavingAndLoading.GetComponent<SavingAndLoadingSport>().GDS.empCount += 1;
                }
                if (EmployeeCountData > 0 && EmployeeCountData == SavingAndLoading.GetComponent<SavingAndLoadingSport>().GDS.empCount && !spawnEmps)
                {
                    spwnEmployee();
                }
            }
        }
        catch
        {

        }


        if (Input.GetKeyDown(KeyCode.O))
        {
            spwnEmployee();
        }
        
    }


    IEnumerator spawn(float t)
    {
        yield return new WaitForSeconds(t);
        spwnEmployee();
    }
    public void spwnEmployee()
    {
        for(int i = 0; i <= EmployeeCountData-1; i++)
        {
            GameObject emp = Instantiate(EmployeetoSpwan, HR.SpwanPoint.position, Quaternion.identity);
            emp.transform.parent = transform;
            emp.GetComponent<FashionM.Movement.empMovement>().lv = HR.LevelManager;
            emp.GetComponent<FashionM.Movement.empMovement>().initPos = HR.SpwanPoint;
            if (i <= EmployeeCountData-1)
            {
                spawnEmps = true;
            }
        }
    }
}