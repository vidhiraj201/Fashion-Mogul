using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FashionM.Core
{
    public class DropCoin : MonoBehaviour
    {
        public int Coins = 100;

        public void detatachFromClient()
        {
            transform.parent = null;
        }
        public void Destroy()
        {
            Destroy(this.gameObject);
        }
    }
}
