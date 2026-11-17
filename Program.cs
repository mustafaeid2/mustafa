using System;
using Cse111Task1;

StudentList list = new StudentList();

void Show(string step)
{
    Console.Write($"{step,-14}");
    list.Print();
    Console.WriteLine($"   first={list.First?.Id.ToString() ?? "null"} last={list.Last?.Id.ToString() ?? "null"} count={list.Count}");
}

Show("start");
list.AddFront(20); Show("AddFront(20)");
list.AddFront(10); Show("AddFront(10)");
list.AddEnd(30);   Show("AddEnd(30)");
list.AddEnd(40);   Show("AddEnd(40)");
list.Reverse();    Show("Reverse()");
list.Remove(20);   Show("Remove(20)");
