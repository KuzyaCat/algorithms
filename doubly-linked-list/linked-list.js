const Node = require('./node');

class LinkedList {
    constructor() {
        this._head = null;
        this._tail = null;
        this.length = 0;
    }

    append(data) {
        let node = new Node();
        node.data = data;

        if (this.length) {
            this._tail.next = node;
            node.prev = this._tail;
            this._tail = node;
        } else {
            this._head = node;
            this._tail = node;
        }

        this.length++;
        return this;
    }

    head() {
        if (this._head) {
            return this._head.data;
        } else {
            return null;
        }
    }

    tail() {
        if (this._tail) {
            return this._tail.data;
        } else {
            return null;
        }
    }

    at(index) {
        let current = this._head;

        if (this.length === 0 || index < 0 || index > this.length) {
            throw new Error('The search index does not exist');
        }

        for (let i = 0; i < index; i++) {
            current = current.next;
        }

        return current.data;
    }

    insertAt(index, data) {
        let node = new Node();
        node.data = data;

        if (index < 0) {
            throw new Error('The search index does not exist');
        }

        if (this.length === 0) {
            this._head = node;
            this._tail = node;

            return node.data;
        }

        if (index === 0) {
            this._head.prev = node;
            this.node.next = this._head;
            this.node.prev = null;
            this._head = node;
            this.length++;

            return node.data;
        }

        let current = this._head;

        for (let i = 0; i < index; i++) {
            current = current.next;
        }

        let nextNode = current,
            prevNode = current.prev;

        nextNode.prev = node;
        node.next = nextNode;
        prevNode.next = node;
        node.prev = prevNode;
        this.length++;

        return node.data;
    }

    isEmpty() {
        if (this.length == 0) {
            return true;
        } else {
            return false;
        }
    }

    clear() {
        this._head = null;
        this._tail = null;
        this.length = 0;

        return this;
    }

    deleteAt(index) {
        if (this.length === 0 || index < 0 || index > this.length) {
            throw new Error('The search index does not exist');
        }

        let current = this._head,
            nodeToDelete = null,
            nextNode = null,
            prevNode = null;
        
        if (this.length === 1) {
            this._head = null;

            return this;
        }

        if (index === 0) {
            this._head = this._head.next;
            this._head.prev = null;

            return this;
        }

        if (index === this.length - 1) {
            this._tail = this._tail.prev;
            this._tail.next = null;

            return this;
        }

        for (let i = 0; i < index; i++) {
            current = current.next;
        }

        nodeToDelete = current;
        nextNode = nodeToDelete.next;
        prevNode = nodeToDelete.prev;

        nextNode.prev = prevNode;
        prevNode.next = nextNode;
        nodeToDelete = null;

        return this;
    }

    reverse() {
        if (this.length <= 1) {
            return this;
        }

        let temp = this._head;
        this._head = this._tail;
        this._tail = temp;

        let current = this._head;

        while (current.prev !== null) {
            let x = current.next;
            current.next = current.prev;
            current.prev = x;

            current = current.next;
        }

        return this;
    }

    indexOf(data) {
        if (this.length === 0) {
            return -1;
        }
        
        let current = this._head;

        for (let index = 0; index < this.length; index++) {
            if (current.data == data) {
                return index;
            }

            current = current.next;
        }

        return -1;
    }
}

module.exports = LinkedList;
