namespace linkedList {
    class Node {
        public int value;
        public Node next;
        public Node(int value) {
            this.value = value;
        }
    }
    class LinkedList{
        Node head;
        Node tail;
        public void Add(Node node) {
            if (this.head == null) {
                this.head = node;
            }

            if (this.tail == null) {
                this.tail = node;
            }
            
            if (this.head == this.tail) {
                return;
            }

            this.tail.next = node;
            this.tail = node;
        }
    }
}

myList = new LinkedList();
myList.add(new Node(1));
//[1]
myList.add(new Node(20));
//[1, 20]
