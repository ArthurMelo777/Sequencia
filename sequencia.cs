using System;

class SequenceEmpty : Exception {

}

class ElementNotFound : Exception {

}

class Node {
    private object element;
    private Node prev, next;

    public Node (object e, Node p, Node n) {
        element = e;
        prev = p;
        next = n;
    }

    public void setElement (object o) {
        element = o;
    }

    public object getElement () {
        return element;
    }

    public void setPrev (Node n) {
        prev = n;
    }

    public Node getPrev () {
        return prev;
    }

    public void setNext (Node n) {
        next = n;
    }

    public Node getNext () {
        return next;
    }
}

class Sequence {
    // atributos
    private Node head, tail;
    private int countSize;

    public Sequence () {
        Node n = new Node (null, null, null);
        head = new Node(null, null, n);
        tail = new Node (null, n, null);
    }

    // metodos
    public int size () {
        return countSize;
    }

    public bool isEmpty () {
        if (countSize == 0) {
            return true;
        }
        return false;
    }

    public Node atRank (int r) {
        Node n = head.getNext();

        for (int i = 0; i < r; i++) {
            n = n.getNext();
        }

        return n;
    }

    public int rankOf (Node n) {
        Node node = head.getNext();

        for (int i = 0; i < countSize; i++) {
            if (node == n) {
                return i;
            }
            node = node.getNext();
        }

        return -1;
    }

    public object elemAtRank (int r) {
        if (isEmpty()) {
            throw new SequenceEmpty();
        }
        if (r >= countSize && r != 0) {
            throw new ElementNotFound();
        }
        return atRank(r).getElement();
    }

    public object replaceAtRank (int r, object o) {
        if (isEmpty()) {
            throw new SequenceEmpty();
        }
        if (r >= countSize && r != 0) {
            throw new ElementNotFound();
        }
        Node n = atRank(r);
        object old_o = n.getElement();
        n.setElement(o);
        return old_o;
    }

    public void insertAtRank (int r, object o) {
        if (r >= countSize && r != 0) {
            throw new IndexOutOfRangeException();
        }
        if (isEmpty()) {
            Node n = new Node(o, head, tail);
            head.setNext(n);
            tail.setPrev(n);
            countSize++;
        }
        else {
            Node n = atRank(r);
            Node new_n = new Node(o, n.getPrev(), n);
            n.getPrev().setNext(new_n);
            n.setPrev(new_n);
            countSize++;
        }
    }

    public object removeAtRank (int r) {
        if (isEmpty()) {
            throw new SequenceEmpty();
        }
        if (r >= countSize && r != 0) {
            throw new ElementNotFound();
        }
        Node n = atRank(r);

        n.getPrev().setNext(n.getNext());
        n.getNext().setPrev(n.getPrev());
        countSize--;

        return n.getElement();
    }

    public Node first () {
        if (isEmpty()) {
            throw new SequenceEmpty();
        }
        return head.getNext();
    }

    public Node last () {
        if (isEmpty()) {
            throw new SequenceEmpty();
        }
        return tail.getPrev();
    }

    public Node before (Node n) {
        if (isEmpty()) {
            throw new SequenceEmpty();
        }
        if (n.getPrev() == head) {
            throw new ElementNotFound();
        }
        return n.getPrev();
    }

    public Node after (Node n) {
        if (isEmpty()) {
            throw new SequenceEmpty();
        }
        if (n.getNext() == head) {
            throw new ElementNotFound();
        }
        return n.getNext();
    }

    public void replaceElement (Node n, object o) {
        if (isEmpty()) {
            throw new SequenceEmpty();
        }
        n.setElement(o);
    }

    public void swapElements (Node n, Node q) {
        if (isEmpty()) {
            throw new SequenceEmpty();
        }
        object o = n.getElement();
        n.setElement(q.getElement());
        q.setElement(o);
    }

    public void insertBefore (Node n, object o) {
        if (isEmpty()) {
            throw new SequenceEmpty();
        }
        Node node = new Node(o, n.getPrev(), n);
        n.getPrev().setNext(node);
        n.setPrev(node);
        countSize++;
    }

    public void insertAfter (Node n, object o) {
        if (isEmpty()) {
            throw new SequenceEmpty();
        }
        Node node = new Node(o, n, n.getNext());
        n.getNext().setPrev(node);
        n.setNext(node);
        countSize++;
    }

    public void insertFirst (object o) {
        Node node = new Node (o, head, head.getNext());
        head.getNext().setPrev(node);
        head.setNext(node);
        countSize++;
    }
    
    public void insertLast (object o) {
        Node node = new Node (o, tail.getPrev(), tail);
        tail.getPrev().setNext(node);
        tail.setPrev(node);
        countSize++;
    }

    public object remove (Node n) {
        if (isEmpty()) {
            throw new SequenceEmpty();
        }
        n.getPrev().setNext(n.getNext());
        n.getNext().setPrev(n.getPrev());
        countSize--;

        return n.getElement();
    }

    public void printSequence () {
        if (isEmpty()) {
            Console.WriteLine("Sequencia vazia coleguinha!");
        }
        else {
            Node n = head.getNext();
            for (int i = 0; i < countSize; i++) {
                Console.Write($" [{n.getElement()}]");
                n = n.getNext();
            }
            Console.WriteLine();
        }
    }
}

class Program {
    public static void Main () {
        Sequence sequence = new Sequence();

        Console.WriteLine(sequence.size()); // 0
        Console.WriteLine(sequence.isEmpty()); // true

        // METODOS DE VETOR
        sequence.printSequence(); // Sequencia vazia coleguinha
        sequence.insertAtRank(0, 1); // inseriu o elemento 1 no rank 0
        sequence.printSequence(); // [1]
        Console.WriteLine(sequence.elemAtRank(0)); // 1
        Console.WriteLine(sequence.replaceAtRank(0, 0)); // 1
        sequence.printSequence(); // [0]
        Console.WriteLine(sequence.removeAtRank(0)); // 0
        sequence.printSequence(); // Sequencia vazia coleguinha

        // METODOS DE LISTA
        sequence.insertFirst(0); // insere o elemento 0 na posição 0
        sequence.printSequence(); // [0]
        sequence.insertLast(1); // insere o elemento 1 na posição 1
        sequence.printSequence(); // [0] [1]
        Console.WriteLine(sequence.first().getElement()); // 0
        Console.WriteLine(sequence.last().getElement()); // 1
        Node f = sequence.first();
        Node l = sequence.last();
        sequence.insertBefore(l, 'b'); // insere o elemento 'b' antes do elemento 1
        sequence.printSequence(); // [0] [b] [1]
        sequence.insertAfter(f, 'a'); // insere o elemento 'a' depois do elemento 0
        sequence.printSequence(); // [0] [a] [b] [1]
        Console.WriteLine(sequence.before(l).getElement()); // b
        Console.WriteLine(sequence.after(f).getElement()); // a
        sequence.swapElements(f, l); // troca de posição o primeiro e o ultimo elementos
        sequence.printSequence(); // [1] [a] [b] [0]
        sequence.replaceElement(l, 3); // troca o ultimo elemento por 3
        sequence.printSequence(); // [1] [a] [b] [3]
    }
}