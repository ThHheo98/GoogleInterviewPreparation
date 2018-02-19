namespace CommonAlgo.SortingAlgo
{
    //https://ru.wikipedia.org/wiki/%D0%94%D0%B2%D0%BE%D0%B8%D1%87%D0%BD%D0%B0%D1%8F_%D0%BA%D1%83%D1%87%D0%B0 // двоичная куча

//    Двои́чная ку́ча, пирами́да[1], или сортиру́ющее де́рево — такое двоичное дерево, для которого выполнены три условия:
//    Значение в любой вершине не меньше, чем значения её потомков.
//    Глубина листьев (расстояние до корня) отличается не более чем на 1 слой.
//    Последний слой заполняется слева направо.
    public static class HeapSort
    {
        public static int[] Sort(int[] a)
        {
            /*
             *  Обший алгоритм пирамидальной сортировки,
             *  но здесь написано для массивов с нумерацией с 1
             *  Heapsort(A)
                  Build_Max_Heap(A) // построили max кучу. Теперь корнем кучи является максимальный элемент
                  for i ← A.length downto 1  // начиная с последнего элемента будем подниматься наверх
                    do Обменять A[1] ↔ A[i] // поменяем максимальный элемент с последним
                       A.heap_size ← A.heap_size-1 // уменьшим размер массива на 1
                       Heapify(A,1) // постоим кучу для N - 1 элементов
             */
            //BuildMaxHeap(a); // построили кучу
            /*
            Build-Heap(A)
             A.heap_size ← A.length
             for i ← ⌊A.length/2⌋ downto 1 // элементы gj byltrce i > N/2 не имеют потомков
               do Heapify(A, i)
            */
            for (var i = (a.Length - 2)/2; i >= 0; i--)
            {
                HeapifyMax(a, a.Length, i);
            }

            for (var i = 0; i < a.Length - 1; i++) // для всех элементов с первого
            {
                Utils.Swap(ref a[0], ref a[a.Length - 1 - i]); // меняем первый и последний элемент
                HeapifyMax(a, a.Length - 1 - i, 0); // восстанавливаем свойства кучи для массива размером N-i-1
            }
            return a;
        }

        public static int TakeKMax(int[] a, int k)
        {
            var i = (a.Length - 2)/2;
            while (i >= 0) HeapifyMax(a, a.Length, i--);

            for (i = 0; i < k - 1; i++)
            {
                Utils.Swap(a, 0, a.Length - i - 1); // меняем первый и последний элемент
                HeapifyMax(a, a.Length - i - 1, 0); // восстанавливаем свойства кучи для массива размером N-i-1
            }
            return a[0];
        }

        public static int TakeKMin(int[] a, int k)
        {
            //BuildMinHeap(a);
            /*
             Build-Heap(A)
              A.heap_size ← A.length
              for i ← ⌊A.length/2⌋ downto 1 // элементы gj byltrce i > N/2 не имеют потомков
                do Heapify(A, i)
             */
            for (var i = (a.Length - 2)/2; i >= 0; i--)
            {
                HeapifyMin(a, a.Length, i);
            }
            for (var i = 0; i < k - 1; i++)
            {
                Utils.Swap(ref a[0], ref a[a.Length - i - 1]); // меняем первый и последний элемент
                HeapifyMin(a, a.Length - i - 1, 0); // восстанавливаем свойства кучи для массива размером N-i-1
            }
            return a[0];
        }

        private static void HeapifyMin(int[] a, int size, int i)
        {
            /*
             Heapify(A, i)
              left ← 2i
              right ← 2i+1
              heap_size - количество элементов в куче
              largest ← i
              if left ≤ A.heap_size и A[left] > A[i]
                then largest ← left
              if right ≤ A.heap_size и A[right] > A[largest]
                then largest ← right
              if largest ≠ i
                then Обменять A[i] ↔ A[largest]
                     Heapify(A, largest)
             */
            var l = 2*i + 1;
            var r = 2*i + 2;
            var min = i;

            // если один из потомков меньше родителя, то надо поменять корневой элемент 
            // местами с минимальным потомком, и вызвать построение кучи уже для этого потомка 
            // потому что при каждом изменении элемента в куче, кучу надо перестроить
            if (l < size && a[l] < a[min])
                min = l;
            if (r < size && a[r] < a[min])
                min = r;

            if (min != i) // min was changed
            {
                Utils.Swap(a, i, min);
                HeapifyMin(a, size, min);
            }
        }

        private static void HeapifyMax(int[] a, int size, int i)
        {
            /*
             Heapify(A, i)
              left ← 2i
              right ← 2i+1
              heap_size - количество элементов в куче
              largest ← i
              if left ≤ A.heap_size и A[left] > A[i]
                then largest ← left
              if right ≤ A.heap_size и A[right] > A[largest]
                then largest ← right
              if largest ≠ i
                then Обменять A[i] ↔ A[largest]
                     Heapify(A, largest)
             */
            var l = 2*i + 1;
            var r = 2*i + 2;
            var max = i;

            // если один из потомков больше родителя, то надо поменять корневой элемент 
            // местами с максимальным потомком, и вызвать построение кучи уже для этого потомка 
            // потому что при каждом изменении элемента в куче, кучу надо перестроить
            if (l < size && a[max] < a[l])
                max = l;
            if (r < size && a[max] < a[r])
                max = r;
            if (max != i) // max was changed
            {
                Utils.Swap(ref a[i], ref a[max]);
                HeapifyMax(a, size, max);
            }
        }
    }
}