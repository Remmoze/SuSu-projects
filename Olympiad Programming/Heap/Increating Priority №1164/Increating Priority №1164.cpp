#include <iostream>

#define MAX_HEAP 100
class Heap {
public:
	Heap(int len = MAX_HEAP) {
		nodes = new int[len];
	}
	int max() {
		if(length == 0)
			return 0;
		return nodes[0];
	};
	void push(int value) {
		int par = (length - 1) / 2;
		int pos = length;
		nodes[length++] = value;
		while(pos && nodes[pos] > nodes[par]) {
			nodes[pos] += nodes[par];
			nodes[par] = nodes[pos] - nodes[par];
			nodes[pos] -= nodes[par];
			pos = par;
			par = (pos - 1) / 2;
		}
	};
	void pop() {
		int max, pos = 0, child;
		nodes[0] = nodes[--length];
		while(pos * 2 + 1 < length) {
			child = pos * 2 + 1;
			max = child + (nodes[child] > nodes[child + 1] ? 0 : 1);
			if(nodes[pos] > nodes[max]) break;
			child = nodes[pos];
			nodes[pos] = nodes[max];
			nodes[max] = child;
			pos = max;
		}
	};
	int shuffleUp(int index) {
		int par = (index - 1) / 2;
		while(index && nodes[index] > nodes[par]) {
			nodes[index] += nodes[par];
			nodes[par] = nodes[index] - nodes[par];
			nodes[index] -= nodes[par];
			index = par;
			par = (index - 1) / 2;
		}
		return index;
	}
	void print() {
		std::cout << nodes[0];
		for(int i = 1; i < length; i++) {
			std::cout << " " << nodes[i];
		}
		std::cout << std::endl;;
	};
	void inc(int index, int amount) {
		nodes[index] += amount;
	}
private:
	int length = 0;
	int* nodes;
};

int main() {
	int size, input, input2;
	std::cin >> size;
	Heap heap(size);
	for(int i = 0; i < size; i++) {
		std::cin >> input;
		heap.push(input);
	}
	std::cin >> size;
	for(int i = 0; i < size; i++) {
		std::cin >> input;
		std::cin >> input2;
		heap.inc(input-1, input2);
		std::cout << heap.shuffleUp(input-1)+1 << std::endl;
	}
	heap.print();
}