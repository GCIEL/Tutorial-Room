using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace VRTK
{
    public class Sphere : VRTK_InteractableObject
    {
        public GameObject roomManager;
        private bool activated = false;
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
            if (!activated && IsUsing() &&
                GetUsingObject().GetComponent<VRTK_ControllerEvents>().triggerTouched)
            {
                // Update to generealize lab manager object
                roomManager.GetComponent<LabManager>().inactiveSphereCount = -1; 
                Debug.Log(string.Format("BOOM! {0} spheres left", roomManager.GetComponent<LabManager>().inactiveSphereCount));

                // Change colors
                Renderer rend = GetComponent<Renderer>();
                rend.material.shader = Shader.Find("Standard");
                rend.material.SetColor("_EmissionColor", Color.cyan);

                activated = true;
            }
        }
    }
}
