using UnityEngine;

namespace PhysicalShading
{
    [RequireComponent(typeof(Camera))]
    [DisallowMultipleComponent]
    [ExecuteInEditMode]
    public class Display : MonoBehaviour
    {
        public Material blitMaterial = null;

        private void OnPostRender()
        {
            if (blitMaterial) Graphics.Blit(null, blitMaterial);
        }
    }
}
