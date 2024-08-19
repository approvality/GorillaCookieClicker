using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

namespace GorillaCookieClicker.Shop
{
    public class BuyMultiplier : MonoBehaviour
    {
        public int Cost;
        public int Award;
        public int AddCost;

        public static GameObject Cookie;
        public TextMeshPro CostText;

        void Start()
        {
           Cookie = GameObject.Find("GorillaCookieClicker(Clone)/parent/cookieclicker");
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.name == "RightHandTriggerCollider")
            {
                Buy();
                GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(211, false, 0.1f);
                GorillaTagger.Instance.StartVibration(false, .1f, 0.001f);
            }
            else if (other.name == "LeftHandTriggerCollider")
            {
                Buy();
                GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(211, true, 0.1f);
                GorillaTagger.Instance.StartVibration(true, .1f, 0.001f);
            }
        }

        public void Buy()
        {
            if (Cookie.GetComponent<Cookie>().Cookies >= Cost)
            {
                Cookie.GetComponent<Cookie>().Cookies -= Cost;
                Cookie.GetComponent<Cookie>().Multipier += Award;
                Cookie.GetComponent<Cookie>().UpdateText();
                AddCost = Cost / 8;
                Cost += AddCost;

                CostText.text = Cost.ToString() + " Cookies";
            }
            else
            {
                Debug.Log("not enough cookies");
            }
        }
    }
}
