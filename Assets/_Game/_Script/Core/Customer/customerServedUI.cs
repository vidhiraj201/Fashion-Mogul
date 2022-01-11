using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace FashionM.Core
{
    public class customerServedUI : MonoBehaviour
    {
        public float speed;
        public Transform target;
        public GameObject CustomerUI;
        public Camera cam;

       /* private void Start()
        {
        }
        Vector3 targetPos;
        private void Update()
        {
            //targetPos = -cam.ScreenToWorldPoint(new Vector3(target.position.x, target.position.y, cam.transform.position.z * -1));
        }
      *//*  public void StartUIMoving(Vector3 _init)
        {
            GameObject UIObj = Instantiate(CustomerUI, transform);
            StartCoroutine(moveUI(UIObj.transform, _init, targetPos));
        }
        IEnumerator moveUI(Transform obj, Vector3 startPos, Vector3 endPos)
        {
            float time = 0;
            while (time < 1)
            {
                time += speed * Time.deltaTime;
                obj.position = Vector3.Lerp(startPos, endPos, time);
                yield return new WaitForEndOfFrame();
            }

            yield return null;
        }*/
    }
}
