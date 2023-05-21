using System;

class SequenceEmpty : Exception {

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

    public Node elemAtRank (int r) {
        return atRank(r);
    }

    public object replaceAtRank (int r, object o) {
        Node n = atRank(r);
        object old_o = n.getElement();
        n.setElement(o);
        return old_o;
    }

    public void insertAtRank (int r, object o) {
        Node n = atRank(r);
        Node new_n = new Node(o, n.getPrev(), n);
        n.getPrev().setNext(new_n);
        n.setPrev(new_n);
    }

    public object removeAtRank (int r) {
        Node n = atRank(r);

        n.getPrev().setNext(n.getNext());
        n.getNext().setPrev(n.getPrev());

        return n.getElement();
    }

    public Node first () {
        return head.getNext();
    }

    public Node last () {
        return tail.getPrev();
    }

    public Node before (Node n) {
        return n.getPrev();
    }

    public Node after (Node n) {
        return n.getNext();
    }

    public void replaceElement (Node n, object o) {
        n.setElement(o);
    }

    public void swapElements (Node n, Node q) {
        object o = n.getElement();
        n.setElement(q.getElement());
        q.setElement(o);
    }

    public void insertBefore (Node n, object o) {
        Node node = new Node(o, n.getPrev(), n);
        n.getPrev().setNext(node);
        n.setPrev(node);
    }

    public void insertAfter (Node n, object o) {
        Node node = new Node(o, n, n.getNext());
        n.getNext().setPrev(node);
        n.setNext(node);
    }

    public void insertFirst (object o) {
        Node node = new Node (o, head, head.getNext());
        head.getNext().setPrev(node);
        head.setNext(node);
    }
    
    public void insertLast (object o) {
        Node node = new Node (o, tail.getPrev(), tail);
        tail.getPrev().setNext(node);
        tail.setPrev(node);
    }

    public object remove (Node n) {
        n.getPrev().setNext(n.getNext());
        n.getNext().setPrev(n.getPrev());

        return n.getElement();
    }
}

class Program {
    public static void Main () {

    }
}