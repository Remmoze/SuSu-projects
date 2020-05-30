#include <iostream>

#define MAX_HEAP 100
class Heap {
public:
	Heap(int len = MAX_HEAP) {
		nodes = new int[len];
	}
	int min() {
		if(length == 0)
			return -1;
		return nodes[0];
	};
	void push(int value) {
		int par = (length - 1) / 2;
		int pos = length;
		nodes[length++] = value;
		while(pos && nodes[pos] < nodes[par]) {
			nodes[pos] += nodes[par];
			nodes[par] = nodes[pos] - nodes[par];
			nodes[pos] -= nodes[par];
			pos = par;
			par = (pos - 1) / 2;
		}
	};
	void pop() {
		int min, pos = 0, child;
		nodes[0] = nodes[--length];
		while(pos * 2 + 1 < length) {
			child = pos * 2 + 1;
			min = child + (nodes[child] < nodes[child + 1] ? 0 : 1);
			if(nodes[pos] <= nodes[min]) break;
			child = nodes[pos];
			nodes[pos] = nodes[min];
			nodes[min] = child;
			pos = min;
		}
	};
	void print() {
		for(int i = 0; i < length; i++) {
			std::cout << nodes[i] << ", ";
		}
		std::cout << std::endl;;
	};
private:
	int length = 0;
	int* nodes;
};

int main() {
	Heap heap(100);
	heap.push(1);
	heap.push(6);
	heap.push(8);
	heap.push(8);
	heap.push(7);
	heap.push(12);
	heap.push(9);
	heap.push(10);
	heap.push(5);
	heap.print();
	heap.pop();
	heap.print();
}