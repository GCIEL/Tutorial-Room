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
            // Add appropriate error checks
            // Make abstract class for scene/room manager
            roomManager.GetComponent<LabManager>().rightController.GetComponent<VRTK_ControllerEvents>().TriggerPressed +=
                new ControllerInteractionEventHandler(Activate);
            roomManager.GetComponent<LabManager>().leftController.GetComponent<VRTK_ControllerEvents>().TriggerPressed +=
                new ControllerInteractionEventHandler(Activate);
        }

        public override void StartUsing(VRTK_InteractUse usingObject)
        {
            base.StartUsing(usingObject);
            if (!activated) ChangeColor(Color.green);
        }

        public override void StopUsing(VRTK_InteractUse usingObject)
        {
            base.StopUsing(usingObject);
            if(!activated) ChangeColor(Color.red);
        }

        protected override void Update()
        {
            base.Update();
            
        }

        private void Activate(object sender, ControllerInteractionEventArgs e)
        {
            if (!activated && IsUsing() &&
                VRTK_ControllerReference.GetControllerReference(GetUsingObject()).Equals(e.controllerReference))
            {
                // Update to generealize lab manager object
                roomManager.GetComponent<LabManager>().inactiveSphereCount = -1;
                Debug.Log(string.Format("BOOM! {0} spheres left", roomManager.GetComponent<LabManager>().inactiveSphereCount));

                // Change colors
                ChangeColor(Color.cyan);

                activated = true;
            }
        }

        private void ChangeColor(Color color)
        {
            Renderer rend = GetComponent<Renderer>();
            rend.material.shader = Shader.Find("Standard");
            rend.material.SetColor("_EmissionColor", color);
        }

        protected void DoStartUseObject(object sender, ControllerInteractionEventArgs e)
        {

        }
    }
}
