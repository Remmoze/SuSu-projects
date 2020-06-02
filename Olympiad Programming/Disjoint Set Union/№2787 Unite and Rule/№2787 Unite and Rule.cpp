#include <iostream>
#include <string>

// i'll do this later if i have time left.

#define growthFactor 1.75
#define initialSize 5

struct Stack {
	int* p;
	int cur = 0;
	int max = initialSize;
	void init();
	void resizeto(int at_least);
	void resize();
	void add(int value);
	void clear();
	int find(int value);
};
void Stack::init() {
	p = (int*)malloc(max * sizeof(int));
	if(p == nullptr) exit(-1);
}
void Stack::resize() {
	if(cur < max) return;
	max *= growthFactor;
	p = (int*)realloc(p, max * sizeof(int));
	if(p == nullptr) exit(-1);
}
void Stack::resizeto(int at_least) {
	if(at_least < max) return;
	while(at_least < max) {
		max *= growthFactor;
	}
	p = (int*)realloc(p, max * sizeof(int));
	if(p == nullptr) exit(-1);
}
void Stack::add(int value) {
	resize();
	p[cur++] = value;
}
int Stack::find(int value) {
	for(int i = 0; i < cur; i++) {
		if(p[i] == value)
			return i;
	}
	return -1;
}
void Stack::clear() {
	cur = 0;
}
Stack query;

int parents[500000] = {};


int root;
int ind = 0;

void clear() {
	ind = 0;
}

void make_set(int v) {
	if(parents[v] == 0)
		parents[v] = v;
}

void traversal(Stack* stack, int v) {
	stack->add(v);
	if(parents[v] == v || parents[v] == 0)
		return;
	traversal(stack, parents[v]);
}

int cmp_traversal(Stack* stack, int v) {
	if(stack->find(v) == -1 && (parents[v] != v && parents[v] != 0))
		return cmp_traversal(stack, parents[v]);
	return v;
}

int main() {
	query.init();
	int N, inp1, inp2;
	std::cin >> N;

	parents[1] = 1;

	std::string input;
	for(int i = 0; i < N; i++) {
		std::cin >> input;
		std::cin >> inp1;
		std::cin >> inp2;
		if(input.compare("ADD") == 0) {
			parents[inp2] = inp1;
			//printf("%i -> %i\n", inp2, inp1);
		} else {
			query.clear();
			traversal(&query, inp1);
			std::cout << cmp_traversal(&query, inp2) << std::endl;
			/*
			for(int i = 0; i < query.cur; i++) {
				printf("%i\n", query.p[i]);
			}
			*/
		}
	}
}