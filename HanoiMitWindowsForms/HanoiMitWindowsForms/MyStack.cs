using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class MyStack
{
  private Node topElement = null;

  private class Node
  {
    public int Data;

    public Node PrevElement;

    public Node(int value, Node previous)
    {
      Data = value;
      PrevElement = previous;
    }
  }

  /// <summary>
  /// Fügt ein neues Element Hinzu
  /// </summary>
  /// <param name="value"></param>
  public void Push(int value)
  {
    Node elementToAdd = new Node(value, topElement);
    topElement = elementToAdd;
  }

  /// <summary>
  /// Ließt und löscht das oberste Element
  /// </summary>
  /// <returns></returns>
  public int Pop()
  {
    int data = topElement.Data;
    topElement = topElement.PrevElement;
    return data;
  }

  /// <summary>
  /// Ließt das oberste Element
  /// </summary>
  /// <returns></returns>
  public int Peek()
  {
    if (topElement == null)
      throw new ArgumentOutOfRangeException("Der Stapel ist Leer!");
    else
      return topElement.Data;
  }

  /// <summary>
  /// Löscht alle Elemente
  /// </summary>
  public void Clear()
  {
    topElement = null;
  }

  public bool IsEmpty
  {
    get
    {
      return topElement == null;
    }
  }

  /// <summary>
  /// Zählt alle Elemente
  /// </summary>
  /// <returns></returns>
  public int Count()
  {
    int count = 0;

    for (Node current = topElement; current != null; current = current.PrevElement)
    {
      count++;
    }
    return count;
  }

  /// <summary>
  /// Schreibt alle Elemente in ein Array
  /// </summary>
  /// <returns></returns>
  public int[] ToArray()
  {
    int[] array = new int[Count()];

    int index = 0;
    for (Node current = topElement; current != null; current = current.PrevElement)
    {
      array[index] = current.Data;
      index++;
    }
    return array;
  }
}

