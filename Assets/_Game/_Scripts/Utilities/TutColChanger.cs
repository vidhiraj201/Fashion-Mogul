using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutColChanger : MonoBehaviour
{
    private Material whileTutorial;

    private MeshRenderer MS;
    public Material afterTutorial;


    bool changeScene;

    public bool single;
    public bool pose;
    public bool chair;
    public List<Material> materials = new List<Material>();
    private FashionM.Core.GameManager gm;
    private void Start()
    {
        gm = FindObjectOfType<FashionM.Core.GameManager>();
        whileTutorial = gm.whileTutorial;
        MS = GetComponent<MeshRenderer>();
    }

    float i = 1f;
    void Update()
    {
        if (!changeScene && gm.dayCount == 2 && gm.ChangeTheColor)
        {
            if (i >= 0)
                i -= Time.deltaTime;

            if (i <= 0)
                changeScene = true;
        }
        if (single)
        {
            
            if (gm.dayCount <= 1)
            {
                MS.material = whileTutorial;
            }
            if (changeScene)
            {
                MS.material = afterTutorial;
                Destroy(GetComponent<TutColChanger>());

            }
        }
        if (!single)
        {
            if (gm.dayCount <= 1)
            {
                var mats = MS.materials;
                mats[0] = whileTutorial;
                MS.materials = mats;
            }
            if (changeScene)
            {
                var mats = MS.materials;
                mats[0] = afterTutorial;
                MS.materials = mats;
                Destroy(GetComponent<TutColChanger>());
            }
        }

        if (pose)
        {
            if (gm.dayCount <= 1)
            {
                var mats = MS.materials;
                mats[0] = whileTutorial;
                mats[1] = whileTutorial;
                mats[2] = whileTutorial;
                mats[3] = whileTutorial;
                MS.materials = mats;
            }
            if (changeScene)
            {
                var mats = MS.materials;
                mats[0] = materials[0];
                mats[1] = materials[1];
                mats[2] = materials[2];
                mats[3] = materials[3];
                MS.materials = mats;
                Destroy(GetComponent<TutColChanger>());
            }
        }

        if (chair)
        {
            if (gm.dayCount <= 1)
            {
                var mats = MS.materials;
                mats[0] = whileTutorial;
                mats[1] = whileTutorial;
                MS.materials = mats;
            }
            if (changeScene)
            {
                var mats = MS.materials;
                mats[0] = materials[0];
                mats[1] = materials[1];
                MS.materials = mats;
                Destroy(GetComponent<TutColChanger>());
            }
        }       
    }

}
