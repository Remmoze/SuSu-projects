#include <iostream>

void shift(int* ar, int size) {
	memmove(ar, ar + 1, sizeof(int) * size);
}

int main() {
	int n, k, min= 54321, val;
	std::cin >> n;
	std::cin >> k;

	if(k <= n) {
		for(int i = 0; i < n; i++) {
			std::cin >> val;
			if(min > val) {
				min = val;
			}
		}
		printf("%i ", min);
	} else {
		int* block = new int[n];
		for(int i = 0; i < n; i++) {
			std::cin >> block[i];
		}
		for(int i = 0; i < n-k; i++) {

		}
	}

	
}
/*
11 3

8 764 1 3 85 2 4 5 77 1 5
*/