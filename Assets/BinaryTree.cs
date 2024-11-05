using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeNode
{
    public int value;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int value)
    {
        this.value = value;
        left = null;
        right = null;
    }
}

public class BinaryTree : MonoBehaviour
{
    private TreeNode _root;

    void Start()
    {
        _root = new TreeNode(5);
        
        Insert(4, _root);
        Insert(4, _root);
        Insert(8, _root);
        Insert(3, _root);
        Insert(1, _root);
        Insert(5, _root);
        Insert(9, _root);
        
        //PrintInOrder(_root);
        
        Debug.Log(Search(9, _root).value);
    }

    public void Insert(int value, TreeNode current)
    {
        if (value == current.value)
        {
            if (current.left == null)
                current.left = new TreeNode(value);
            else
                Insert(value, current.left);
        }
        
        if (value < current.value)
        {
            if (current.left == null)
                current.left = new TreeNode(value);
            else
                Insert(value, current.left);
        }

        if (value > current.value)
        {
            if (current.right == null)
                current.right = new TreeNode(value);
            else
                Insert(value, current.right);
        }
    }

    public TreeNode Search(int value, TreeNode current)
    {
        if (value == current.value)
            return current;

        if (value < current.value)
        {
            if (current.left == null)
                return null;
            else
                return Search(value, current.left);
        }

        if (value > current.value)
        {
            if (current.right == null)
                return null;
            else
                return Search(value, current.right);
        }

        return null;
    }

    public TreeNode Delete(int value, TreeNode current)
    {
        if (current == null)
            return current;

        if (value < current.value)
            current.left = Delete(value, current.left);
        else if (value > current.value)
            current.right = Delete(value, current.right);
        else
        {
            if (current.left == null)
                return current.right;
            
            if (current.right == null)
                return current.left;

            TreeNode successor = GetSuccessor(current);
            current.value = successor.value;
            current.right = Delete(successor.value, current.right);
        }

        return current;
    }

    public TreeNode GetSuccessor(TreeNode current)
    {
        current = current.right;

        while (current != null && current.left != null)
        {
            current = current.left;
        }

        return current;
    }
    
    void PrintInOrder(TreeNode node)
    {
        if (node == null)
            return;
        
        PrintInOrder(node.left);
        Debug.Log(node.value);
        PrintInOrder(node.right);
    }
    
    void PrintInPreOrder(TreeNode node)
    {
        if (node == null)
            return;
        
        Debug.Log(node.value);
        PrintInPreOrder(node.left);
        PrintInPreOrder(node.right);
    }
    
    void PrintInPostOrder(TreeNode node)
    {
        if (node == null)
            return;
        
        PrintInPostOrder(node.left);
        PrintInPostOrder(node.right);
        Debug.Log(node.value);
    }
}