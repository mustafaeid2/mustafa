// Name: Mustafa Eid Ali
// Student ID: 225110333

using System;
using System.Text;

namespace Cse111Task1;

public class StudentList
{
    public Student? First { get; private set; }
    public Student? Last { get; private set; }
    public int Count { get; private set; }

    // O(1): put the student at the front.
    public void AddFront(int id)
    {
        Student node = new Student(id);
        node.Next = First;
        First = node;
        if (Last == null) Last = node; // empty line: also last
        Count++;
    }

    // O(1): put the student at the end using Last.
    public void AddEnd(int id)
    {
        Student node = new Student(id);
        if (Last == null)
        {
            First = node;
            Last = node;
        }
        else
        {
            Last.Next = node;
            Last = node;
        }
        Count++;
    }

    // O(n): drop the first match. True if someone left.
    public bool Remove(int id)
    {
        Student? prev = null;
        Student? cur = First;

        while (cur != null && cur.Id != id)
        {
            prev = cur;
            cur = cur.Next;
        }

        if (cur == null) return false; // empty or missing

        if (prev == null) First = cur.Next; // removing the first
        else prev.Next = cur.Next;          // middle or last

        if (cur == Last) Last = prev;       // removing the last (null if now empty)

        cur.Next = null;
        Count--;
        return true;
    }

    // O(n): turn the line around, no extra array.
    public void Reverse()
    {
        Student? prev = null;
        Student? cur = First;
        Last = First; // the old first becomes the last

        while (cur != null)
        {
            Student? next = cur.Next; // save Next before overwriting it
            cur.Next = prev;
            prev = cur;
            cur = next;
        }

        First = prev;
    }

    // O(n): write the ids from first to last, separated by spaces.
    public void Print()
    {
        StringBuilder sb = new StringBuilder();
        Student? cur = First;
        while (cur != null)
        {
            if (sb.Length > 0) sb.Append(' ');
            sb.Append(cur.Id);
            cur = cur.Next;
        }
        Console.WriteLine(sb.ToString());
    }
}
