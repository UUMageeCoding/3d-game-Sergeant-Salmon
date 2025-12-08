using UnityEngine;

public class SimpleDoorTeleport : MonoBehaviour
{
    public Transform teleportTarget;
    private bool playerInRange = false;

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                // Disable CharacterController to avoid repeated teleport
                CharacterController cc = player.GetComponent<CharacterController>();
                if (cc != null) cc.enabled = false;

                // Teleport
                player.transform.position = teleportTarget.position;
                player.transform.rotation = teleportTarget.rotation;

                // Re-enable CharacterController
                if (cc != null) cc.enabled = true;

                // Optional: reset playerInRange to prevent immediate retrigger
                playerInRange = false;

                // Sync physics transforms
                Physics.SyncTransforms();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInRange = false;
    }
}