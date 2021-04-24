using System;

namespace DepthFirstSearch
{
    public class Node
    {

        public int key;
        public Node left, right;

        public Node(int item)
        {
            key = item;
            left = right = null;
        }


       public class BinaryTree
        {
            // Root of Binary Tree
          public  Node root;

          public  BinaryTree() { root = null; }

            /* Given a binary tree, print
               its nodes according to the
               "bottom-up" postorder traversal. */
            public int printPostorder(Node node)
            {
                if (node == null)
                    return 0;

                // first recur on left subtree
                printPostorder(node.left);

                // then recur on right subtree
                printPostorder(node.right);

                // statıc array transfer results
                Postorder[k] = node.key;
                k++;

                // now deal with the node
                Console.Write(node.key + " ");

                // return statıc array
                return Postorder[i];
            }
            public int i = 0, m = 0, k = 0;
            /* Given a binary tree, print
               its nodes in inorder*/
           public  int printInorder(Node node)
            {
                if (node == null)
                    return 0;

                /* first recur on left child */
                printInorder(node.left);

                /* then print the data of node */
                Console.Write(node.key + " ");

                // statıc array transfer results
                Inorder[i] = node.key;
                i++;
                /* now recur on right child */
                printInorder(node.right);

                // return statıc array
                return Inorder[i];
            }

            /* Given a binary tree, print
               its nodes in preorder*/
           
            public int printPreorder(Node node)
            {
                if (node == null)
                    return 0;

                /* first print data of node */
                Console.Write(node.key + " ");

                // statıc array transfer results
                 Preorder[m] = node.key;
                m++;
                /* then recur on left sutree */
                printPreorder(node.left);

                /* now recur on right subtree */
                printPreorder(node.right);

                // return statıc array
                return Preorder[i];
            }

            
            //static array 
            public int[] Inorder = new int[100];
            //static array 
            public int[] Preorder = new int[100];
            //static array 
            public int[] Postorder = new int[100];


            // Wrappers over above recursive functions
            public int printPostorder() {
                printPostorder(root);
                return 0;

                  }
           public int printInorder() {
                printInorder(root);
                return 0;

            }
           public int printPreorder() { 
                printPreorder(root);
                return 0;
            }




        }


    }
}
