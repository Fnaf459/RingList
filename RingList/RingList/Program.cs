using System;

class CircularLinkedList
{
    class Node
    {
        public int Data;
        public Node Next;

        public Node(int data)
        {
            Data = data;
            Next = null;
        }
    }

    private Node tail;

    public CircularLinkedList()
    {
        tail = null;
    }

    // Добавление элемента в середину списка
    public void InsertInMiddle(int data)
    {
        Node newNode = new Node(data);

        if (tail == null)
        {
            tail = newNode;
            tail.Next = tail;
        }
        else
        {
            Node slow = tail.Next, fast = tail.Next;

            // Найти середину списка
            while (fast != tail && fast.Next != tail)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            newNode.Next = slow.Next;
            slow.Next = newNode;

            // Если вставка происходит после tail, нужно обновить tail
            if (slow == tail)
            {
                tail = newNode;
            }
        }
    }

    // Удаление элемента по значению
    public void DeleteByValue(int value)
    {
        if (tail == null) return;

        Node current = tail.Next;
        Node previous = tail;

        do
        {
            if (current.Data == value)
            {
                if (current == tail.Next && current == tail)
                {
                    // Единственный элемент в списке
                    tail = null;
                }
                else
                {
                    previous.Next = current.Next;
                    if (current == tail)
                    {
                        tail = previous;
                    }
                }
                return;
            }
            previous = current;
            current = current.Next;
        } while (current != tail.Next);
    }

    // Вывод списка на экран
    public void Display()
    {
        if (tail == null)
        {
            Console.WriteLine("Список пуст");
            return;
        }

        Node current = tail.Next;
        do
        {
            Console.Write(current.Data + " ");
            current = current.Next;
        } while (current != tail.Next);
        Console.WriteLine();
    }

    static void Main()
    {
        CircularLinkedList list = new CircularLinkedList();

        // Добавление элементов в середину
        list.InsertInMiddle(10);
        Console.WriteLine("Список после вставки:");
        list.Display();

        list.InsertInMiddle(20);
        Console.WriteLine("Список после вставки:");
        list.Display();

        list.InsertInMiddle(30);
        Console.WriteLine("Список после вставки:");
        list.Display();

        list.InsertInMiddle(40);
        Console.WriteLine("Список после вставки:");
        list.Display();

        // Удаление элемента
        list.DeleteByValue(30);
        Console.WriteLine("Список после удаления 30:");
        list.Display();

        // Удаление элемента, который отсутствует
        list.DeleteByValue(50);
        Console.WriteLine("Список после попытки удаления 50:");
        list.Display();

        // Удаление оставшихся элементов
        list.DeleteByValue(10);
        list.DeleteByValue(20);
        list.DeleteByValue(40);
        Console.WriteLine("Список после удаления всех элементов:");
        list.Display();
    }
}
