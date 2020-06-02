#include <iostream>

int main() {
	int n, inp;
	std::cin >> n;
	int numbers[2000] = {}; //all 0
	for(int i = 0; i < n; i++) {
		std::cin >> inp;
		numbers[1000 + inp]++;
	}
	std::cin >> n;
	std::cout << numbers[1000 + n];
}