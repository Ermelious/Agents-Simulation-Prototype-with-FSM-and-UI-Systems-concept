//Author: Lance
using UnityEngine;
using System.Collections.Generic;

public class Spawnable : MonoBehaviour
{
    [Header("Customizables")]
    [Tooltip("Is this spawnable asset respawnable via object pooling? If this is set to false, this spawnable asset will no longer despawn when r the game object is disabled.")]
    [SerializeField]
    private bool respawnable = true;
    [Header("Monitoring Purpose")]
    [SerializeField]
    private SpawnableData spawnableData = null;
    [SerializeField]
    private LinkedListNode<Spawnable> linkedListNode;

    public void Init(SpawnableData spawnableData, LinkedListNode<Spawnable> linkedListNode)
    {
        this.spawnableData = spawnableData;
        this.linkedListNode = linkedListNode;
    }

    private void OnDisable()
    {
        if (!respawnable)
            return;

        //Debug.Log("@@@@@@@@@ TRYING TO DISABLE: " + gameObject.name);
        //If this spawnable was destroyed instead of despawn, clear it from the active spawnables pool.
        if (null == this)
        {
            Debug.Log("Removing from pool: " + gameObject.name);
            spawnableData.RemoveFromActivePool(linkedListNode);

            return;
        }
        spawnableData.Despawn(this, linkedListNode);
        gameObject.SetActive(false);
    }

    public SpawnableData GetSpawnableData()
    {
        return spawnableData;
    }
}