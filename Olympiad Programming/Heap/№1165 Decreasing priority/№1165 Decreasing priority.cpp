﻿#include <iostream>

#define MAX_HEAP 100

struct Heap {
	int length = 0;
	int* nodes;
};

void init(struct Heap* heap, int len = MAX_HEAP) {
	heap->nodes = new int[len];
}

int max(struct Heap* heap) {
	if(heap->length == 0)
		return 0;
	return heap->nodes[0];
}

int shuffleUp(struct Heap* heap, int index) {
	int par = (index - 1) / 2;
	int* nods = heap->nodes;
	while(nods[index] > nods[par]) {
		std::swap(nods[index], nods[par]);
		index = par;
		par = (index - 1) / 2;
	}
	return index;
}

int shuffleDown(struct Heap* heap, int index) {
	int node = index, lchild, rchild;
	int* nods = heap->nodes;
	while(true) {
		lchild = index * 2 + 1;
		rchild = index * 2 + 2;

		if(lchild < heap->length && nods[lchild] > nods[node])
			node = lchild;
		if(rchild < heap->length && nods[rchild] > nods[node])
			node = rchild;

		if(index == node) return index;

		std::swap(nods[index], nods[node]);
		index = node;
	}
}

void push(struct Heap* heap, int value) {
	heap->nodes[heap->length++] = value;
	shuffleUp(heap, heap->length-1);
};

void print(struct Heap* heap) {
	std::cout << heap->nodes[0];
	for(int i = 1; i < heap->length; i++)
		std::cout << " " << heap->nodes[i];
	std::cout << std::endl;;
};

void dec(struct Heap* heap, int index, int amount) {
	heap->nodes[index] -= amount;
}

int main() {
	int size, inp, inp2;
	std::cin >> size;

	struct Heap heap;
	init(&heap, size);

	for(int i = 0; i < size; i++) {
		std::cin >> inp;
		push(&heap, inp);
	}

	std::cin >> size;
	for(int i = 0; i < size; i++) {
		std::cin >> inp;
		std::cin >> inp2;
		heap.nodes[inp - 1] -= inp2;
		std::cout << shuffleDown(&heap, inp - 1) + 1 << std::endl;
	}
	print(&heap);
}