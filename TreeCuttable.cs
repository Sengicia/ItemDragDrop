

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TreeCuttable : ToolHit
{
    [SerializeField] private float health = 100f;
    [SerializeField] private GameObject dropPrefab;
    [SerializeField] private int minDrops = 1;
    [SerializeField] private int maxDrops = 5;
    [SerializeField] private float respawnTime = 5f;

    public Player_Skills playerSkills;  // Ensure this is of type PlayerSkills

    private bool isCut = false;

    public override void Hit()
    {
        if (isCut) return;

        health -= 20f;
        if (health <= 0)
        {
            isCut = true;
            Debug.Log("Tree cut down!");

            int logCount = Random.Range(minDrops, maxDrops + 1);

            // Drop items
            for (int i = 0; i < logCount; i++)
            {
                Vector3 dropPosition = transform.position + new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
                Instantiate(dropPrefab, dropPosition, Quaternion.identity);
            }

            // Disable tree visual and collider components (but keep the script active for coroutines)
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;

            // Ensure playerSkills is set
            if (playerSkills != null)
            {
                playerSkills.GainXP("Woodcutting", 10f);  // Gain XP for woodcutting
                Debug.Log("Gained 10 EXP");
            }
            else
            {
                Debug.LogError("PlayerSkills reference is not set on the TreeCuttable object.");
            }

            // Call respawn coroutine
            StartCoroutine(RespawnTree());
        }
    }

    private IEnumerator RespawnTree()
    {
        // Wait for the respawn time
        yield return new WaitForSeconds(respawnTime);

        // Reactivate the tree components
        GetComponent<Renderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;

        // Reset health and state
        health = 100f;
        isCut = false;

        Debug.Log("Tree has respawned.");
    }
}
