using UnityEngine;

namespace PhysicalShading
{
    [AddComponentMenu("Physical Shading/Object Rotating")]
    public class ObjectRotating : MonoBehaviour
    {
        public float Angle = 60;

        private void Update()
        {
            gameObject.transform.localRotation *= Quaternion.AngleAxis(
                Angle * Time.deltaTime, Vector3.up);
        }
    }
}
