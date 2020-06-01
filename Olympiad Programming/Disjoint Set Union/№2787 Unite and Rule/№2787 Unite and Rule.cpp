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
	void resize();
	void add(int index, int value);
};
void Stack::init() {
	p = (int*)malloc(max * sizeof(int));
	if(p == nullptr) exit(-1);
}
void Stack::resize() {
	if(cur < max) return;
	p = (int*)realloc(p, max * growthFactor * sizeof(int));
	max *= growthFactor;
	if(p == nullptr) exit(-1);
}
void Stack::add(int index, int value) {

}
Stack stack;

int root;
int path[500000]; //because why not :D
int ind = 0;

void add(int v) {
	path[ind++] = v;
}

void clear() {
	ind = 0;
}

void make_set(int v) {
	if(parents[v] == 0)
		parents[v] = v;
}

int traversal(int v) {
	path[ind++] = v;
	if(parents[v] == v)
		return;
	traversal(parents[v]);
}

int find_set(int v) {
	if(parents[v] == v)
		return v;
	return find_set(parents[v]);
}

void union_sets(int a, int b) {
	parents[b] = a;}

int main() {
	stack.init();
	

	int N;
	std::cin >> N;

	std::string input;
	for(int i = 1; i < N; i++) {

	}
}