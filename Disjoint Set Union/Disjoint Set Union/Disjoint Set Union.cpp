#include <iostream>
#include <vector>
#define MAX_ISLANDS 10000
#define MAX_ROADS 50000

std::vector<int> tree[MAX_ROADS];
int parent[MAX_ISLANDS];

void make_set(int v) {
	tree[v] = std::vector<int>(1, v);
	parent[v] = v;
}

int find_set(int v) {
	return parent[v];
}

bool union_sets(int a, int b) {
	a = find_set(a);
	b = find_set(b);
	if(a == b) return false;
	if(tree[a].size() < tree[b].size())
		std::swap(a, b);
	int v = find_set(b);
	parent[v] = a;
	tree[a].push_back(v);
	return true;
}
int main() {
	int num, max;
	std::cin >> num;
	std::cin >> max;
	
	for(int i = 1; i <= num; i++) {
		make_set(i);
	}

	int inp1, inp2;
	for(int i = 0; i < max; i++) {
		std::cin >> inp1;
		std::cin >> inp2;
		if(union_sets(inp1, inp2))
			--num;
		if(num == 1)
			break;
	}

	std::cout << tree[find_set(1)].size() << std::endl;
}