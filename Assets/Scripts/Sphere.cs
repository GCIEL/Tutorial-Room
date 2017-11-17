using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace VRTK
{
    public class Sphere : VRTK_InteractableObject
    {
        // Use this for initialization
        void Start()
        {

        }

        public override void StartUsing(VRTK_InteractUse usingObject)
        {
            base.StartUsing(usingObject);
        }

        protected override void Update()
        {
            base.Update();
            if (IsUsing() && GetUsingObject().GetComponent<VRTK_ControllerEvents>().triggerPressed)
            {
                Debug.Log("BOOM!");
                Destroy(this.gameObject);
            }
        }
    }
}
