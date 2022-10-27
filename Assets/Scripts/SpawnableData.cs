//Author: Lance
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "SpawnableData", menuName = "Spawnables/SpawnableData")]
public class SpawnableData : ScriptableObject
{
    [Header("Spawn Asset with no Memory Management. Leave this as null if Memory Management is required.")]
    public Spawnable spawnable = null;

    [Header("Cache")]
    public LinkedList<Spawnable> inactiveSpawnables = new LinkedList<Spawnable>();
    public LinkedList<Spawnable> activeSpawnables = new LinkedList<Spawnable>();

    public Spawnable Spawn(Transform parent, Vector3 position, Quaternion rotation)
    {
        Spawnable freshSpawnable = SpawnContainer(parent, position, rotation);
        if (null == freshSpawnable)
        {
            ClearCache();
            freshSpawnable = SpawnContainer(parent, position, rotation);
        }
        return freshSpawnable;
    }

    private Spawnable SpawnContainer(Transform parent, Vector3 position, Quaternion rotation)
    {
        Spawnable freshSpawnable;
        if (inactiveSpawnables.Count == 0)
        {
            freshSpawnable = Instantiate(spawnable.gameObject, position, rotation, parent).GetComponent<Spawnable>();
            inactiveSpawnables.AddFirst(freshSpawnable);
        }
        freshSpawnable = inactiveSpawnables.First.Value;
        inactiveSpawnables.RemoveFirst();
        activeSpawnables.AddFirst(freshSpawnable);

        if (null != freshSpawnable)
        {
            freshSpawnable.Init(this, activeSpawnables.First);
            freshSpawnable.transform.rotation = rotation;
            freshSpawnable.transform.position = position;
            freshSpawnable.transform.SetParent(parent);
            freshSpawnable.gameObject.SetActive(true);
        }
        return freshSpawnable;
    }

    public void ClearCache()
    {
        inactiveSpawnables.Clear();
        activeSpawnables.Clear();
    }

    public void Despawn(Spawnable spawnable, LinkedListNode<Spawnable> linkedListNode)
    {
        activeSpawnables.Remove(linkedListNode);
        inactiveSpawnables.AddFirst(spawnable);
    }

    public void RemoveFromActivePool(LinkedListNode<Spawnable> linkedListNode)
    {
        activeSpawnables.Remove(linkedListNode);
    }

    public void RemoveFromInactivePool(LinkedListNode<Spawnable> linkedListNode)
    {
        inactiveSpawnables.Remove(linkedListNode);
    }

    public void DespawnAll()
    {
        while (activeSpawnables.Count != 0)
        {
            activeSpawnables.First.Value.gameObject.SetActive(false);
        }
    }
}