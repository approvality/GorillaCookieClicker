using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace GorillaCookieClicker
{
    public class Hover : MonoBehaviour
    {
        public static GameObject HoverObject;

        public void OnTriggerEnter(Collider other)
        {
            if (other.name == "RightHandTriggerCollider")
            {
                HoverObject.transform.localScale = new Vector3(7.901572f, 7.901572f, 7.901572f);
            }
            else if (other.name == "LeftHandTriggerCollider")
            {
                HoverObject.transform.localScale = new Vector3(7.901572f, 7.901572f, 7.901572f);
            }
        }

        public void OnTriggerExit(Collider other)
        {
            if (other.name == "RightHandTriggerCollider")
            {
                HoverObject.transform.localScale = new Vector3(7.63142f, 7.63142f, 7.63142f);
            }
            else if (other.name == "LeftHandTriggerCollider")
            {
                HoverObject.transform.localScale = new Vector3(7.63142f, 7.63142f, 7.63142f);
            }
        }
    }
}
