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
	int i = 0;
	while(true) {
		if(1000 + n + i < 2000) {
			if(numbers[1000 + n + i] != 0) {
				printf("%i", numbers[1000 + n + i]);
				break;
			}
		}
		if(1000 + n - i > 0) {
			if(numbers[1000 + n - i] != 0) {
				printf("%i", numbers[1000 + n - i]);
				break;
			}
				
		}
		i++;
	}
}