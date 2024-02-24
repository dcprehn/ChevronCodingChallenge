using System;
using System.Collections.Generic;

public class MinHeap<T> where T : IComparable<T>
{
    private List<T> heap = new();

    public int Count => heap.Count;

    public void Add(T item)
    {
        heap.Add(item);
        HeapifyUp(heap.Count - 1);
    }

    public T ExtractMin()
    {
        if (heap.Count == 0)
            throw new InvalidOperationException("Heap is empty");

        T min = heap[0];
        int lastIndex = heap.Count - 1;
        heap[0] = heap[lastIndex];
        heap.RemoveAt(lastIndex);
        HeapifyDown(0);
        return min;
    }

    public T Peek()
    {
        if (heap.Count == 0)
            throw new InvalidOperationException("Heap is empty");
        
        return heap[0];
    }

    private void HeapifyUp(int index)
    {
        while (index > 0)
        {
            int parentIndex = (index - 1) / 2;
            if (heap[index].CompareTo(heap[parentIndex]) >= 0)
                break;
            Swap(index, parentIndex);
            index = parentIndex;
        }
    }

    private void HeapifyDown(int index)
    {
        int smallest = index;
        int leftChild = 2 * index + 1;
        int rightChild = 2 * index + 2;

        if (leftChild < heap.Count && heap[leftChild].CompareTo(heap[smallest]) < 0)
            smallest = leftChild;

        if (rightChild < heap.Count && heap[rightChild].CompareTo(heap[smallest]) < 0)
            smallest = rightChild;

        if (smallest != index)
        {
            Swap(index, smallest);
            HeapifyDown(smallest);
        }
    }

    private void Swap(int i, int j)
    {
        (heap[j], heap[i]) = (heap[i], heap[j]);
    }
}
