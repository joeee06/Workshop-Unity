using UnityEngine;

public class Player : MonoBehaviour
{
    private LayerMask mask;

    void Start()
    {
        mask = LayerMask.GetMask("Interactable");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(Camera.main.transform.position, Camera.main.transform.forward * 5f, Color.yellow);
        if (Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, 5f, mask))
            {
                Debug.Log("Hit: " + hit.transform.name);
                IInteractable comp = hit.collider.gameObject.GetComponent<IInteractable>();
                comp.Interact();
            }
        }
    }

}
