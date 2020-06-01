#include <iostream>
#define MAX_ISLANDS 10000
#define MAX_ROADS 50000

int size[MAX_ISLANDS];
int parents[MAX_ROADS];

void make_set(int v) {
	if(parents[v] == 0)
		parents[v] = v;
}

int find_set(int v) {
	if(parents[v] == v)
		return v;
	return parents[v] = find_set(parents[v]);
}

bool union_sets(int a, int b) {
	a = find_set(a);
	b = find_set(b);
	if(a == b) {
		++size[a];
		return false;
	}
	if(size[a] < size[b])
		std::swap(a, b);
	parents[b] = a;
	size[a] += size[b] + 1;
	return true;
}

int main() {
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
}