using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

namespace GorillaCookieClicker.Buttons
{
    public class SetActive : MonoBehaviour
    {
        public GameObject Object;
        public TextMeshPro setactivetext;
        public bool IsActive = true;
        public void OnTriggerEnter(Collider other)
        {
            if (other.name == "RightHandTriggerCollider")
            {
                GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(211, false, 0.1f);
                GorillaTagger.Instance.StartVibration(false, .1f, 0.001f);
                if (IsActive)
                {
                    Object.SetActive(false);
                    IsActive = false;
                    setactivetext.text = "Turn On";
                }
                else if (!IsActive)
                {
                    Object.SetActive(true);
                    IsActive = true;
                    setactivetext.text = "Turn Off";
                }
            }
            if (other.name == "LeftHandTriggerCollider")
            {
                GorillaTagger.Instance.offlineVRRig.PlayHandTapLocal(211, true, 0.1f);
                GorillaTagger.Instance.StartVibration(true, .1f, 0.001f);
                if (IsActive)
                {
                    Object.SetActive(false);
                    IsActive = false;
                    setactivetext.text = "Turn On";
                }
                else if (!IsActive)
                {
                    Object.SetActive(true);
                    IsActive = true;
                    setactivetext.text = "Turn Off";
                }
            }
        }
    }
}
