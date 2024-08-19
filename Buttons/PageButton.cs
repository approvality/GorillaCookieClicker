using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace GorillaCookieClicker.Buttons
{
    public class PageButton : MonoBehaviour
    {
        public GameObject PageToGo;
        public GameObject PageToLeave;

        public void OnTriggerEnter(Collider other)
        {
            if (other.name == "RightHandTriggerCollider")
            {
                GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(211, false, 0.1f);
                GorillaTagger.Instance.StartVibration(false, .1f, 0.001f);
                PageToGo.SetActive(true);
                PageToLeave.SetActive(false);
            }
            else if (other.name == "LeftHandTriggerCollider")
            {
                GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(211, true, 0.1f);
                GorillaTagger.Instance.StartVibration(true, .1f, 0.001f);
                PageToGo.SetActive(true);
                PageToLeave.SetActive(false);
            }
        }
    }
}
