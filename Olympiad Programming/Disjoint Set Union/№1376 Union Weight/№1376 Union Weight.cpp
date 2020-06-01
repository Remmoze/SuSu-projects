#include <iostream>

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
		weight[a] += w;
		return;
	}
	weight[b] += weight[a] + w;
	weight[a] = 0;
	parents[a] = b;
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


	int m, inp1, inp2;
	std::cin >> m;
	for(int i = 0; i < m; i++) {
		std::cin >> n;
		if(n == 2) {
			std::cin >> n;
			printf("%i\n", weight[find_set(n)]);
			continue;
		} else if(n == 1) {
			std::cin >> inp1;
			std::cin >> inp2;
			std::cin >> n;
			union_sets(inp1, inp2, n);
		}
	}

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