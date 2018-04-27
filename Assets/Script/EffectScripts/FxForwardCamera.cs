using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class FxForwardCamera : MonoBehaviour
{
	public Vector3 ForwadDir = new Vector3(0.0f, 0.0f, 1.0f);

	void Start()
	{
	}

	void OnWillRenderObject()
	{
		Vector3 dir = transform.TransformDirection(ForwadDir);
		Vector3 position = Camera.current.transform.position;
		Vector3 faceCameraDir = (position - transform.position).normalized;
		Vector3 normal = (faceCameraDir - Vector3.Dot(faceCameraDir, dir) * dir).normalized;
		transform.right = Vector3.Cross(dir, normal).normalized;
	}
}
