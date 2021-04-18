function QueueElement(element, priority) {
  this.element = element;
  this.priority = priority;
}

function PriorityQueue() {
  this.items = [];
}

PriorityQueue.prototype.enqueue = function (element, priority) {
  // initialise the element
  const queueElement = new QueueElement(element, priority);
  let added = false;

  for (let i = 0; i < this.items.length; i++) {
    // check if current element's priority is higher
    if (queueElement.priority < this.items[i].priority) {
      this.items.splice(i, 0, queueElement);
      added = true;
      break;
    }
  }

  // element belongs to the end of queue
  if (!added) {
    this.items.push(queueElement);
  }
};

PriorityQueue.prototype.dequeue = function () {
  // return the element from the beginning of queue
  return this.items.shift();
};

