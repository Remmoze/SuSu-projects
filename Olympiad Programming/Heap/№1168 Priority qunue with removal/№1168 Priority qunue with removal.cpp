﻿#include <iostream>

struct Heap {
	int length = 0;
	int* nodes;
	int size;
};

void init(struct Heap* heap, int len) {
	heap->size = len;
	heap->nodes = new int[len];
}

int max(struct Heap* heap) {
	if(heap->length > 0)
		return heap->nodes[0];
	return -123;
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
	if(heap->length < 1) return -1;
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

int push(struct Heap* heap, int value) {
	if(heap->length < heap->size) {
		heap->nodes[heap->length++] = value;
		return shuffleUp(heap, heap->length - 1);
	}
	return -2;
};

int pop(struct Heap* heap) {
	heap->nodes[0] = heap->nodes[heap->length - 1];
	heap->length--;
	return shuffleDown(heap, 0);
}

int remove(struct Heap* heap, int index) {
	if(index >= heap->length || index < 0)
		return -123;
	int rtn = heap->nodes[index];
	heap->nodes[index] = heap->nodes[heap->length-- - 1];
	shuffleDown(heap, index);
	shuffleDown(heap, index);
	return rtn;
}

void print(struct Heap* heap) {
	for(int i = 0; i < heap->length; i++)
		printf("%i ", heap->nodes[i]);
};

int main() {
	int N;
	std::cin >> N; // length
	struct Heap heap;
	init(&heap, N);

	int M;
	std::cin >> M;

	int inp, val;

	for(int i = 0; i < M; i++) {
		std::cin >> inp;
		if(inp == 3) {
			std::cin >> inp;
			val = remove(&heap, inp - 1);
			if(val == -123) 
				val = -1;
			printf("%i\n", val);
		} else if(inp == 2) {
			std::cin >> inp;
			printf("%i\n", push(&heap, inp) + 1);
		} else if(inp == 1) {
			val = max(&heap);
			if(val == -123)
				printf("-1\n");
			else
				printf("%i %i\n", pop(&heap) + 1, val);
		}
	}
	print(&heap);
}
