#include <iostream>

int f[10] = {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1};
int s[10] = {-1,-1,-1,-1,-1,-1,-1,-1,-1,-1};

void move() {
	for(int i = 0; i < 9; i++) {
		if(f[i] != -1)
			f[i] = f[i + 1];
		if(s[i] != -1)
			s[i] = s[i + 1];
	}
}

void insert(int* player, int c1, int c2) {
	int i = 0;
	while(player[i] != -1) i++;
	player[i++] = c1;
	player[i++] = c2;
}

int compute() {
	int i = 0;
	while(f[0] != -1 && s[0] != -1) {
		int card1 = f[0];
		int card2 = s[0];
		move();

		if(card1 == 9 && card2 == 0)
			insert(s, card1, card2);
		else if(card1 == 0 && card2 == 9)
			insert(f, card1, card2);
		else if(card1 > card2)
			insert(f, card1, card2);
		else if(card1 < card2)
			insert(s, card1, card2);

		i++;
		if(i >= 10e6) return -1;
	}
	return i;
}

int main() {
	int inp;
	for(int i = 0; i < 5; i++) {
		std::cin >> inp;
		f[i] = inp;
	}
	for(int i = 0; i < 5; i++) {
		std::cin >> inp;
		s[i] = inp;
	}
	int result = compute();
	if(result == -1) {
		printf("botva");
		return 0;
	}
	printf(f[0] == -1 ? "second %i" : "first %i", result);
	/*
	for(int i = 0; i < 10; i++) {
		printf("%i, ", f[i]);
	}
	printf("\n");
	for(int i = 0; i < 10; i++) {
		printf("%i, ", s[i]);
	}
	*/
	return 0;
}