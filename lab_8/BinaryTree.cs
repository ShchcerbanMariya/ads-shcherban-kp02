using System;
using System.Collections.Generic;
using lab_8;
class BinaryTree
{
    private Node root;
    // public Node Parent;
    public bool maxHeap;
    public List<Node> nodes;
    public BinaryTree()
    {
        root = null;
        maxHeap = true;
        nodes = new List<Node>();
    }
    public void Insert(int data)
    {

        if (root == null)
        {
            root = new Node(data);
            return;
        }
        InsertRec(root, new Node(data));
    }
    private void InsertRec(Node root, Node newNode)
    {
        if (root == null)
            root = newNode;

        if (newNode.Data < root.Data)
        {
            if (root.left == null)
                root.left = newNode;
            else
                InsertRec(root.left, newNode);

        }
        else
        {
            if (root.right == null)
                root.right = newNode;
            else
                InsertRec(root.right, newNode);
        }
    }
    /* public Node BSTToMaxHeap()
     {
         return BSTToMaxHeap(root);
     }
     public static Node BSTToMaxHeap(Node root)
     {
         if (root == null)
             return null;

         root.left = BSTToMaxHeap(root.left);
         root.right = BSTToMaxHeap(root.right);

         //sift root down
         return SiftNodeDownInBST(root);
     }

     public static Node SiftNodeDownInBST(Node node)
     {
         Node right = node.right;
         Node nodeToReturn = right;
         Node left = node.left;
         while (right != null)
         {
             node.left = right.left;
             node.right = right.right;
             right.right = SiftNodeDownInBST(node);
             right.left = left;

             right = node.right;
             left = node.left;
         }
         if (left != null)
         {
             if (left.Data > node.Data)
             {
                 nodeToReturn = left;
                 Node l = left.left;
                 Node r = left.right;
                 left.right = node.right;
                 node.left = l;
                 node.right = r;
                 left.left = SiftNodeDownInBST(node);
             }
         }

         return nodeToReturn ?? node;
     }*/
    /*  public void Heapify_Min()
      {
          Heapify_Min(root);
      }
     public void Heapify_Min(Node node)
      {
          if (node == null) return;
          Heapify_Min(node.left);
          Heapify_Min(node.right);
          Node largest = node;
          if (node.left != null && node.left.Data > node.Data)
              largest = node.left;
          if (node.right != null && node.right.Data > node.Data)
              largest = node.right;

          if (largest != node)
          {
              swap(node, largest);
          }
      }

      private void swap(Node n1, Node n2)
      {
          Node temp = n1.left;
          n1.left = n2.left;
          n2.left = temp;

          temp = n1.right;
          n1.right = n2.right;
          n2.right = temp;
      }*/

    public int countNodes(Node root)
    {
        if (root == null)

            return (0);

        return (1 + countNodes(root.left) + countNodes(root.right));

    }
    public bool isCompleteUtil(Node root, int index, int numberNodes)
    {
        if (root == null)
            return true;

        if (index >= numberNodes)
            return false;

        return isCompleteUtil(root.left, 2 * index + 1, numberNodes) &&
               isCompleteUtil(root.right, 2 * index + 2, numberNodes);
    }
    public bool IsComplete()
    {
        return isCompleteUtil(root, 0, countNodes(root));
    }
    public bool isHeap()
    {
        return isHeapUtil(root);
    }

    public bool isHeapUtil(Node root)
    {
        if (root.left == null && root.right == null)

            return true;

        if (root.right == null)
        {
            return root.Data >= root.left.Data;
        }

        else
        {
            if (root.Data >= root.left.Data && root.Data >= root.right.Data)
                return isHeapUtil(root.left) && isHeapUtil(root.right);

            else
                return false;
        }


    }
    public void Print()
    {
        Print(root, 4);
    }
    private void Print(Node node, int padding)
    {
        if (node != null)
        {
            if (node.right != null)
            {
                Print(node.right, padding + 4);
            }
            if (padding > 0)
            {
                Console.Write(" ".PadLeft(padding));
            }
            if (node.right != null)
            {
                Console.Write("/\n");
                Console.Write(" ".PadLeft(padding));
            }
            Console.Write(node.Data.ToString() + "\n ");
            if (node.left != null)
            {
                Console.Write(" ".PadLeft(padding) + "\\\n");
                Print(node.left, padding + 4);
            }
        }
    }
    public void MaxHeap(Node root, Node rootkid)
    {
        if (root.Data <= rootkid.Data)
        {
            if(nodes.Contains(root) == false)
            nodes.Add(root);
            if(nodes.Contains(rootkid) == false)
            nodes.Add(rootkid);
            // Heapify_Min(root);
            maxHeap = false;
            //Swap(rootkid, root);
        }
        else
        {
            maxHeap = true;
            //nodes.Clear();
        }

    }

    /* public void Swap(Node root, Node rootkid)
     {
         Node buff = root;
         root = rootkid;
         rootkid = buff;
         /*root.Data = rootkid.Data;
         rootkid.Data = buff;
          Node temp = n1.left;
         n1.left = n2.left;
         n2.left = temp;

         temp = n1.right;
         n1.right = n2.right;
         n2.right = temp;*/


    //Console.WriteLine($"{root} <-> {rootkid}");
    // }
    public Node Find(int value)
    {
        return this.Find(value, this.root);
    }
    private Node Find(int value, Node parent)
    {
        if (parent != null)
        {
            if (value == parent.Data) return parent;
            if (value < parent.Data)
                return Find(value, parent.left);
            else
                return Find(value, parent.right);
        }

        return null;
    }

    public void preorderTraversal()
    {
        if (root != null)
        {
            RecursivePreorder(root);
        }
        else
        {
            Console.WriteLine("There is no tree to process");
        }
    }
    private void RecursivePreorder(Node root)
    {
        //Write(root.item.ToString());
        if (root.left != null)
        {
            MaxHeap(root, root.left);
            RecursivePreorder(root.left);
        }
        if (root.right != null)
        {
            MaxHeap(root, root.right);
            RecursivePreorder(root.right);
        }
    }
}