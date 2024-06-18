using System.Collections.Generic;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class BlockManager : MonoBehaviour
{
    public static BlockManager Instance;

    private Queue<BlockData> destroyedBlocks = new Queue<BlockData>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveBlock(GameObject block)
    {
        if (destroyedBlocks.Count >= 60)
        {
            destroyedBlocks.Dequeue();
        }

        BlockData blockData = new BlockData
        {
            position = block.transform.position,
            color = block.GetComponent<SpriteRenderer>().color
        };

        destroyedBlocks.Enqueue(blockData);
    }

    public void RegenerateBlocks()
    {
        foreach (BlockData blockData in destroyedBlocks)
        {
            GameObject newBlock = Instantiate(blockPrefab, blockData.position, Quaternion.identity);
            newBlock.GetComponent<SpriteRenderer>().color = blockData.color;
        }
        destroyedBlocks.Clear();
    }

    public void RegenerateButSpike()
    {
        foreach (BlockData blockData in destroyedBlocks)
        {
            GameObject newBlock = Instantiate(spike_Prefab, blockData.position, Quaternion.identity);
            //newBlock.GetComponent<SpriteRenderer>().color = blockData.color;
        }
        destroyedBlocks.Clear();
    }

    [System.Serializable]
    public class BlockData
    {
        public Vector3 position;
        public Color color;
    }

    public GameObject blockPrefab; 
    public GameObject spike_Prefab; 
}
