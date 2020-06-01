#include <iostream>

#define at(ind) (*(nodes[ind]))

struct Edge {
	int weight;
	int a;
	int b;
};
struct Heap {
	int length = 0;
	Edge** nodes;
	void init(int len);
	Edge* max();
	int shuffleUp(int index);
	int shuffleDown(int index);
	void push(Edge* value);
	Edge* pop();
};
void Heap::init(int len) {
	nodes = new Edge*[len];
}
Edge* Heap::max() {
	return nodes[0];
}
int Heap::shuffleUp(int index) {
	int par = (index - 1) / 2;
	while(at(index).weight < at(par).weight) {
		std::swap(at(index), at(par));
		index = par;
		par = (index - 1) / 2;
	}
	return index;
}
int Heap::shuffleDown(int index) {
	int node = index, lchild, rchild;
	while(true) {
		lchild = index * 2 + 1;
		rchild = index * 2 + 2;

		if(lchild < length && at(lchild).weight < at(node).weight)
			node = lchild;
		if(rchild < length && at(rchild).weight < at(node).weight)
			node = rchild;

		if(index == node) return index;

		std::swap(at(index), at(node));
		index = node;
	}
}
void Heap::push(Edge* value) {
	nodes[length++] = value;
	shuffleUp(length - 1);
};
Edge* Heap::pop() {
	auto rtn = nodes[0];
	nodes[0] = nodes[length-- - 1];
	shuffleDown(0);
	return rtn;
}

int* weight;
int* parents;

void make_set(int v) {
	if(parents[v] == 0)
		parents[v] = v;
}

int find_set(int v) {
	if(parents[v] == v)
		return v;
	return parents[v] = find_set(parents[v]);
}

// a -> b
void union_sets(int a, int b, int w) {
	a = find_set(a);
	b = find_set(b);
	if(a == b) {
		return;
	}
	weight[b] += weight[a] + w;
	weight[a] = 0;
	parents[a] = b;
}

void print(struct Heap* heap) {
	for(int i = 0; i < heap->length; i++)
		printf("%i -> %i is %i\n", heap->nodes[i]->a, heap->nodes[i]->b, heap->nodes[i]->weight);
	printf("\n");
};

void Compute(struct Heap* heap) {
	Edge* temp;
	while(heap->length > 0) {
		temp = heap->pop();
		union_sets(temp->a, temp->b, temp->weight);
	}
}

int main() {
	int n;
	std::cin >> n;
	n++; //wtf i thought 6 means 0..5, not 1..6
	weight = new int[n];
	parents = new int[n];

	for(int i = 0; i < n; i++) {
		weight[i] = 0;
		parents[i] = i;
	}

	std::cin >> n;
	Heap heap;
	heap.init(n);
	for(int i = 0; i < n; i++) {
		Edge* edge = new Edge();
		std::cin >> edge->a;
		std::cin >> edge->b;
		std::cin >> edge->weight;
		heap.push(edge);
	}

	Compute(&heap);
	
	printf("\n%i\n", weight[(find_set(heap.nodes[0]->a))]);
	/*
	int num, max;
	std::cin >> num;
	std::cin >> max;

	int c1, c2;
	for(int i = 0; i < max; i++) {
		std::cin >> c1;
		make_set(c1);
		std::cin >> c2;
		make_set(c2);
		if(num > 1 && union_sets(c1, c2))
			--num;
	}
	std::cout << size[find_set(c1)] << std::endl;
	*/
}