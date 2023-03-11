using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : IHeapItem<Node>
{
    //Determines if the node is walkable or not
    public bool walkable;
    //World position of the node
    public Vector3 worldPos;
    //x position of the node relative to the grid
    public int gridX;
    //y position of the node relative to the grid
    public int gridY;

    //Distance from starting node
    public int gCost;
    //Distance from the target node
    public int hCost;
    //Parent of the node node
    public Node parent;

    int heapIndex;

    public Node(bool _walkable, Vector3 _worldPos, int _gridX, int _gridY)
    {
        walkable = _walkable;
        worldPos = _worldPos;
        gridX = _gridX;
        gridY = _gridY;
    }

    public int fCost { get {return gCost + hCost;} }

    public int HeapIndex { get { return heapIndex; } set { heapIndex = value; } }

    public int CompareTo(Node nodeToCompare)
    {
        int compare = fCost.CompareTo(nodeToCompare.fCost);

        if (compare == 0)
        {
            compare = hCost.CompareTo(nodeToCompare.hCost);
        }

        return -compare;
    }
}
