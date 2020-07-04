using System.Collections.Generic;

public class Node{
    public List<Node> Neighbours;
    public int Id;
    public Node(int id)
    {
        Neighbours = new List<Node>();
        Id = id;
    }
}